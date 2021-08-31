import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Grid } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import RideFilters from './RideFilters';
import RideList from './RideList';

export default observer(function RideDashboard() {
    
    const {rideStore} = useStore();
    const {loadRides, rideRegistry} = rideStore;

    useEffect(() => { 
        if(rideRegistry.size <= 1) loadRides(); 
    }, [rideRegistry.size, loadRides])
  
    if (rideStore.loadingInitial) return <LoadingComponent content='Loading rides...' />

    return (
        <Grid>
            <Grid.Column width='10'>
                <RideList/>
            </Grid.Column>
            <Grid.Column width='6'>
                <RideFilters />
            </Grid.Column>
        </Grid>
    )
})