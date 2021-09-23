import { runInAction } from 'mobx';
import { makeAutoObservable } from 'mobx';
import { HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { GivenRating } from "../models/Rating";
import { store } from './store';

export default class RatingStore {
    ratings: GivenRating[] = [];
    hubConnection: HubConnection | null = null;

    constructor() {
        makeAutoObservable(this);
    }

    createHubConnection = (targetId: string) => {
        if (store.profileStore.profile) {
            this.hubConnection = new HubConnectionBuilder()
                .withUrl('http://localhost:5001/rating?targetId=' + targetId, {
                    accessTokenFactory: () => store.userStore.user?.token!
                })
                .withAutomaticReconnect()
                .configureLogging(LogLevel.Information)
                .build()

            this.hubConnection.start()
                .catch(error => console.log('Error establishing the connection: ', error));

            this.hubConnection.on('LoadRatings', (ratings: GivenRating[]) => {
                runInAction(() => {
                    this.ratings = ratings
                });
            })

            this.hubConnection.on('ReceiveRating', (rating: GivenRating) => {
                runInAction(() => {
                    this.ratings.push(rating)
                });
            })
        }
    }

    stopHubConnection = () => {
        this.hubConnection?.stop().catch(error => console.log('Error stopping coonnection: ', error))
    }

    clearRatings = () => {
        this.ratings = [];
        this.stopHubConnection();
    }

    addRating = async (values: any) => {
        values.targetId = store.profileStore.profile?.id;
        try {
            await this.hubConnection?.invoke('SendRating', values);
        } catch (error) {
            console.log(error);
        }
    }
}