import { RideFormValues } from '../models/ride';
import { format } from 'date-fns';
import { makeAutoObservable, reaction, runInAction } from "mobx";
import agent from "../api/agent";
import { Ride } from "../models/ride";
import { Profile } from '../models/profile';
import { store } from './store';
import { Pagination, PagingParams } from "../models/pagination";

export default class RideStore {
    rideRegistry = new Map<string, Ride>(); //<key, value>
    selectedRide: Ride | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = false;
    pagination: Pagination | null = null;
    pagingParams = new PagingParams();
    predicate = new Map().set('all', true);

    constructor() {
        makeAutoObservable(this);

        reaction(
            () => this.predicate.keys(),
            () => {
                this.pagingParams = new PagingParams();
                this.rideRegistry.clear();
                this.loadRides();
            }
        )
    }

    setPagingParams = (pagingParams: PagingParams) => {
        this.pagingParams = pagingParams;
    }

    setPredicate = (predicate: string, value: string | Date) => {
        const resetPredicate = () => {
            this.predicate.forEach((value, key) => {
                if (key !== 'startDate') this.predicate.delete(key);
            })
        }
        switch (predicate) {
            case 'all':
                resetPredicate();
                this.predicate.set('all', true);
                break;
            case 'isGoing':
                resetPredicate();
                this.predicate.set('isGoing', true);
                break;
            case 'isDriver':
                resetPredicate();
                this.predicate.set('isDriver', true);
                break;
            case 'startDate':
                this.predicate.delete('startDate');
                this.predicate.set('startDate', value);
        }
    } 

    get axiosParams() {
        const params = new URLSearchParams();
        params.append('pageNumber', this.pagingParams.pageNumber.toString());
        params.append('pageSize', this.pagingParams.pageSize.toString());
        this.predicate.forEach((value, key) => {
            if (key === 'startDate') {
                params.append(key, (value as Date).toISOString())
            } else {
                params.append(key, value);
            }
        })
        return params;
    }

    get ridesByDate(){
        return Array.from(this.rideRegistry.values()).sort((a, b) => 
        a.departureDate!.getTime() - b.departureDate!.getTime());
    }

    get groupedRides() {
        return Object.entries(
            this.ridesByDate.reduce((rides, ride) => {
                const departureDate = format(ride.departureDate!, 'dd MMM yyyy');
                rides[departureDate] = rides[departureDate] ? [...rides[departureDate], ride] : [ride];
                return rides;
            }, {} as {[key: string]: Ride[]})
        )
    }

    loadRides = async () => {
        this.loadingInitial = true;
        try {
            const result = await agent.Rides.list(this.axiosParams);
            result.data.forEach(ride => {
                this.setRide(ride);
            })
            this.setPagination(result.pagination);
            this.setLoadingInitial(false);
        } catch (error) {
            console.log(error);
            this.setLoadingInitial(false);
        }
    }

    setPagination = (pagination: Pagination) => {
        this.pagination = pagination;
    }

    loadRide = async (id: string) => {
        let ride = this.getRide(id);
        if (ride) {
            this.selectedRide = ride;
            return ride;
        }else {
            this.loadingInitial = true;
            try { 
                ride = await agent.Rides.details(id);
                this.setRide(ride);
                runInAction(() => {
                    this.selectedRide = ride;
                })
                this.setLoadingInitial(false);
                return ride;
            } catch (error) {
                console.log(error);
                this.setLoadingInitial(false);
            }
        }
    }


    private setRide = (ride: Ride) => {
        const user = store.userStore.user;
        if (user) {
            ride.isGoing = ride.attendees!.some(
                a => a.username === user.username
            )
            ride.isDriver = ride.driverUsername === user.username;
            ride.driver = ride.attendees?.find(x => x.username === ride.driverUsername);
        }
        ride.departureDate = new Date(ride.departureDate!);
        this.rideRegistry.set(ride.id, ride);
    }

    private getRide = (id: string) => {
        return this.rideRegistry.get(id);
    }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }

    createRide = async (ride: RideFormValues) => {
        const user = store.userStore.user;
        const attendee = new Profile(user!);

        try {
            await agent.Rides.create(ride);
            const newRide = new Ride(ride);
            newRide.driverUsername = user!.username;
            newRide.attendees = [attendee];
            this.setRide(newRide);
            runInAction(() => {
                this.selectedRide = newRide;
            })
        } catch (error) {
            console.log(error);

        }
    }

    updateRide = async (ride: RideFormValues) => {
        try {
            await agent.Rides.update(ride);
            runInAction(() => {
                if (ride.id) {
                    let updateRide = {...this.getRide(ride.id), ...ride}
                    this.rideRegistry.set(ride.id, updateRide as Ride);
                    this.selectedRide = updateRide as Ride;
                }
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    deleteRide = async (id: string) => {
        this.loading = true;
        try {
            await agent.Rides.delete(id);
            runInAction(() => {
                this.rideRegistry.delete(id);
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    updateAttendance = async() => {
        const user = store.userStore.user;
        this.loading = true;
        try {
            await agent.Rides.attend(this.selectedRide!.id);
            runInAction(() => {
                if(this.selectedRide?.isGoing) {
                    this.selectedRide.attendees = 
                        this.selectedRide.attendees?.filter(a => a.username !== user?.username);
                    this.selectedRide.isGoing = false;
                } else {
                    const attendee = new Profile(user!);
                    this.selectedRide?.attendees?.push(attendee);
                    this.selectedRide!.isGoing = true;
                }
                this.rideRegistry.set(this.selectedRide!.id, this.selectedRide!)
            })
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => this.loading = false);
        }
    }

    cancelRideToggle = async () => {
        this.loading = true;
        try {
            await agent.Rides.attend(this.selectedRide!.id);
            runInAction(() => {
                this.selectedRide!.isCancelled = !this.selectedRide!.isCancelled;
                this.rideRegistry.set(this.selectedRide!.id, this.selectedRide!);
            })
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => this.loading = false);
        }
    }

    updateAttendeeFollowing = (username: string) => {
        this.rideRegistry.forEach(ride => {
            ride.attendees.forEach(attendee => {
                if (attendee.username === username) {
                    attendee.following ? attendee.followersCount-- : attendee.followersCount++;
                    attendee.following = !attendee.following;
                }
            })
        })
    }

    clearSelectedRide = () => {
        this.selectedRide = undefined;
    }
}
