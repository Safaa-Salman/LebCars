import React, { SyntheticEvent, useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import { Tab, Grid, Header, Card, Image, TabProps } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import { UserRide } from '../../app/models/profile';
import { format } from 'date-fns';
import { useStore } from "../../app/stores/store";

const panes = [
    { menuItem: 'Future Rides', pane: { key: 'future' } },
    { menuItem: 'Past Rides', pane: { key: 'past' } },
    { menuItem: 'Hosting', pane: { key: 'hosting' } }
];

export default observer(function ProfileRides() {
    const { profileStore } = useStore();
    const {
        loadUserRides,
        profile,
        loadingRides,
        userRides
    } = profileStore;

    useEffect(() => {
        loadUserRides(profile!.username);
    }, [loadUserRides, profile]);

    const handleTabChange = (e: SyntheticEvent, data: TabProps) => {
        loadUserRides(profile!.username, panes[data.activeIndex as number].pane.key);
    };

    return (
        <Tab.Pane loading={loadingRides}>
            <Grid>
                <Grid.Column width={16}>
                    <Header floated='left' icon='calendar' content={'Rides'} />
                </Grid.Column>
                <Grid.Column width={16}>
                    <Tab
                        panes={panes}
                        menu={{ secondary: true, pointing: true }}
                        onTabChange={(e, data) => handleTabChange(e, data)}
                    />
                    <br />
                    <Card.Group itemsPerRow={4}>
                        {userRides.map((ride: UserRide) => (
                            <Card
                                as={Link}
                                to={`/rides/${ride.id}`}
                                key={ride.id}
                            >
                                <Image
                                    src={`/assets/background.png`}
                                    style={{ minHeight: 100, objectFit: 'cover' }}
                                />
                                <Card.Content>
                                    <Card.Meta textAlign='center'>
                                        <div>{ride.departure}</div>
                                    </Card.Meta>
                                    <Card.Meta textAlign='center'>
                                        <div>{ride.destination}</div>
                                    </Card.Meta>
                                    <Card.Meta textAlign='center'>
                                        <div>{format(new Date(ride.departureDate), 'do LLL')} {format(new Date(ride.departureDate), 'h:mm a')}</div>
                                    </Card.Meta>
                                    <Card.Meta textAlign='center'>
                                        <div>{format(new Date(ride.returnDate), 'do LLL')} {format(new Date(ride.returnDate), 'h:mm a')}</div>
                                    </Card.Meta>
                                </Card.Content>
                            </Card>
                        ))}
                    </Card.Group>
                </Grid.Column>
            </Grid>
        </Tab.Pane>
    );
});