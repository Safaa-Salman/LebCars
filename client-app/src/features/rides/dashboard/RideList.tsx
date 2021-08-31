import { observer } from "mobx-react-lite";
import React, { Fragment } from "react";
import { Header } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import RideListItem from "./RideListItem";

export default observer(function RideList() {
    const { rideStore } = useStore();
    const { groupedRides } = rideStore;

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
})

