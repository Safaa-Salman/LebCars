import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { Grid } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import RideDetailedChat from './RideDetailedChat';
import RideDetailedHeader from './RideDetailedHeader';
import RideDetailedInfo from './RideDetailedInfo';
import RideDetailedSidebar from './RideDetailedSidebar';

export default observer(function RideDetails() {

    const { rideStore } = useStore();
    const { selectedRide: ride, loadRide, loadingInitial, clearSelectedRide } = rideStore;
    const { id } = useParams<{ id: string }>();

    useEffect(() => {
        if (id) loadRide(id);
        return () => clearSelectedRide();
    }, [id, loadRide, clearSelectedRide]);

    if (loadingInitial || !ride) return <LoadingComponent />;

    return (
        <Grid>
            <Grid.Column width={10}>
                <RideDetailedHeader ride={ride} />
                <RideDetailedInfo ride={ride} />
                <RideDetailedChat rideId={ride.id} />
            </Grid.Column>
            <Grid.Column width={6}>
                <RideDetailedSidebar ride={ride}/>
            </Grid.Column>
        </Grid>
    )
})