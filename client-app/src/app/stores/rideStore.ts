import { RideFormValues } from '../models/ride';
import { format } from 'date-fns';
import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Ride } from "../models/ride";
import { Profile } from '../models/profile';
import { store } from './store';

export default class RideStore {
    rideRegistry = new Map<string, Ride>(); //<key, value>
    selectedRide: Ride | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = false;

    constructor() {
        makeAutoObservable(this)
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
            const rides = await agent.Rides.list();
            rides.forEach(ride => {
                this.setRide(ride);
            })
            this.setLoadingInitial(false);
        } catch (error) {
            console.error();
            this.setLoadingInitial(false);
        }
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
}
