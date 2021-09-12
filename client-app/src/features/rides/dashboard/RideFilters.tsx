import { observer } from 'mobx-react-lite';
import React from 'react';
import Calendar from 'react-calendar';
import { Header, Menu } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';

export default observer(function RideFilters() {
    const { rideStore: { predicate, setPredicate } } = useStore();
    return (
        <>
            <div className="ui action input" style={{ width: '100%', marginTop: 25 }}>
                <input type="text" placeholder="Search Rides..."/>
                <button className ="ui icon button teal">
                <i className="search icon"></i>
                </button>
            </div>
            <Menu vertical size='large' color="teal" style={{ width: '100%', marginTop: 25 }}>
                <Header icon='filter' attached color='teal' content='Filters' />

                <Menu.Item
                    content='All Activites'
                    active={predicate.has('all')}
                    onClick={() => setPredicate('all', 'true')}
                />
                <Menu.Item
                    content="I'm going"
                    active={predicate.has('isGoing')}
                    onClick={() => setPredicate('isGoing', 'true')}
                />
                <Menu.Item
                    content="I'm hosting"
                    active={predicate.has('isDriver')}
                    onClick={() => setPredicate('isDriver', 'true')}
                />
            </Menu>
            <Header />
            <Calendar
                onChange={(date: Date) => setPredicate('startDate', date as Date)}
                value={predicate.get('startDate') || new Date()}
            />
        </>
    )
})