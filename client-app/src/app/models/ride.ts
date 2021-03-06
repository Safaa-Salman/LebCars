import { Profile } from "./profile";

export interface Ride {
    id: string;
    departure: string;
    destination: string;
    departureDate: Date | null;
    returnDate: Date | null;
    passengerNumber: string;
    cost: string;
    description: string;
    children: string;
    animals: string;
    smoking: string;
    baggage: string;
    baggageCost: string;
    driverUsername: string;
    isCancelled: boolean;
    isGoing:boolean;
    isDriver: boolean;
    driver?: Profile;
    attendees: Profile[];
}

export class Ride implements Ride {
  constructor(init?: RideFormValues) {
    Object.assign(this, init);
  }
}

export class RideFormValues {
  id?: string = undefined;
  departure: string = '';
  destination: string = '';
  departureDate: Date | null = null;
  returnDate: Date | null = null;
  passengerNumber: string = '';
  cost: string = '';
  description: string = '';
  children: string = '';
  smoking: string = '';
  animals: string = '';
  baggage: string = '';
  baggageCost: string = '';

  constructor(ride?: RideFormValues) {
    if (ride) {
      this.id = ride.id;
      this.departure = ride.departure;
      this.destination = ride.destination;
      this.departureDate = ride.departureDate;
      this.returnDate = ride.returnDate;
      this.passengerNumber = ride.passengerNumber;
      this.cost = ride.cost;
      this.description = ride.description;
      this.children = ride.children;
      this.smoking = ride.smoking;
      this.animals = ride.animals;
      this.baggage = ride.baggage;
      this.baggageCost = ride.baggageCost;
    }
  }
}