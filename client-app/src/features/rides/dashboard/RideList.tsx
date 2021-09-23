import { observer } from "mobx-react-lite";
import React, { Fragment } from "react";
import { Header } from "semantic-ui-react";
import { Ride } from "../../../app/models/ride";
import { useStore } from "../../../app/stores/store";
import RideListItem from "./RideListItem";


interface Props {
    search: string;
  }

export default observer(function RideList({ search }: Props) {
    const { rideStore } = useStore();
    const { groupedRides } = rideStore;

    if (search === '') {
        return (
            <>
                {groupedRides.map(([group, rides]) => (
                    <Fragment key={group}>
                        <Header sub color='teal'>
                            {group}
                        </Header>
                        {rides.map(ride => (
                            <RideListItem key={ride.id} ride={ride} />
                        ))}
                    </Fragment>
                ))}
            </>
        )
    }

    else { 

        let filteredRides: Ride[];

        return (
            <>
                {groupedRides.map(([group, rides]) => (
                    <Fragment key={group}>
                        <Header sub color='teal'>
                            {group}
                        </Header>
                        {filteredRides = rides.filter(ride => ride.departure.toLocaleLowerCase() === search)}
                        {filteredRides.map(ride => (
                            <RideListItem key={ride.id} ride={ride} />
                        ))}
                    </Fragment>
                ))}
            </>
        )

    }

    
})

