import { observer } from 'mobx-react-lite';
import React, { useEffect, useState } from 'react';
import InfiniteScroll from 'react-infinite-scroller';
import { Grid, Loader} from 'semantic-ui-react';
import { PagingParams } from '../../../app/models/pagination';
import { useStore } from '../../../app/stores/store';
import RideFilters from './RideFilters';
import RideList from './RideList';
import RideListItemPlaceholder from './RideListItemPlaceholder';

export default observer(function RideDashboard() {

    const { rideStore } = useStore();
    const { loadRides, rideRegistry, setPagingParams, pagination } = rideStore;
    const [loadingNext, setLoadingNext] = useState(false);
    const [search, setSearch] = useState('');

    function handleGetNext() {
        setLoadingNext(true);
        setPagingParams(new PagingParams(pagination!.currentPage + 1))
        loadRides().then(() => setLoadingNext(false));
    }


    useEffect(() => {
        if (rideRegistry.size <= 1) loadRides();
    }, [rideRegistry.size, loadRides])

    return (
        <Grid>
            <Grid.Column width='10'>
                {rideStore.loadingInitial && !loadingNext ? (
                    <>
                        <RideListItemPlaceholder />
                        <RideListItemPlaceholder />
                    </>
                ) : (
                    <InfiniteScroll
                        pageStart={0}
                        loadMore={handleGetNext}
                        hasMore={!loadingNext && !!pagination && pagination.currentPage < pagination.totalPages}
                        initialLoad={false}
                    >
                        <div className="ui action input" style={{ width: '100%', marginTop: 25 }}>
                            <input type="text" placeholder="Search Rides..." onChange={event => setSearch(event.target.value)} />
                            <button className="ui icon button teal">
                                <i className="search icon"></i>
                            </button>
                        </div>

                        <RideList search={search.toLowerCase()}/>
                    </InfiniteScroll>
                )}
            </Grid.Column>
            <Grid.Column width='6'>
                <RideFilters />
            </Grid.Column>
            <Grid.Column width={10}>
                <Loader active={loadingNext} />
            </Grid.Column>
        </Grid>
    )
})