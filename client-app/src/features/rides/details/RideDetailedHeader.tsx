import { format } from 'date-fns';
import { observer } from 'mobx-react-lite';
import React from 'react'
import { Link } from 'react-router-dom';
import { Button, Header, Item, Segment, Image, Label } from 'semantic-ui-react'
import { Ride } from "../../../app/models/ride";
import { useStore } from '../../../app/stores/store';

const rideImageStyle = {
    filter: 'brightness(30%)'
};

const rideImageTextStyle = {
    position: 'absolute',
    bottom: '5%',
    left: '5%',
    width: '100%',
    height: 'auto',
    color: 'white'
};

interface Props {
    ride: Ride
}

export default observer(function RideDetailedHeader({ ride }: Props) {
    const { rideStore: { updateAttendance, loading, cancelRideToggle } } = useStore();
    return (
        <Segment.Group>
            <Segment basic attached='top' style={{ padding: '0' }}>
                {ride.isCancelled &&
                    <Label style={{ position: "absolute", zIndex: 1000, left: -14, top: 20 }}
                        ribbon color='red' content='Cancelled'/>}
                <Image src={`/assets/background.png`}  style={rideImageStyle} />
                <Segment style={rideImageTextStyle} basic>
                    <Item.Group>
                        <Item>
                            <Item.Content>
                                <Header
                                    size='huge'
                                    content={`Departure: ${ride.departure} /n Destination: ${ride.destination}`}
                                    style={{ color: 'white' }}
                                />
                                <p>{format(ride.departureDate!, 'dd MMM yyyy')}</p>
                                <p>
                                    Hosted by <strong><Link to={`/profiles/${ride.driver?.username}`}>{ride.driver?.displayName}</Link></strong>
                                </p>
                            </Item.Content>
                        </Item>
                    </Item.Group>
                </Segment>
            </Segment>
            <Segment clearing attached='bottom'>
                {ride.isDriver ? (
                    <>
                        <Button
                            color={ride.isCancelled ? 'green' : 'red'}
                            floated='left'
                            basic
                            content={ride.isCancelled ? 'Re-activate Ride' : 'Cancel Ride'}
                            onClick={cancelRideToggle}
                            loading={loading}
                        />
                        <Button as={Link}
                            disabled={ride.isCancelled}
                            to={`/manage/${ride.id}`}
                            color='orange'
                            floated='right'>
                            Manage Ride
                        </Button>
                    </>
                ) : ride.isGoing ? (
                    <Button loading={loading} onClick={updateAttendance}>Cancel attendance</Button>
                ) : (
                    <Button
                        disabled={ride.isCancelled}
                        loading={loading}
                        onClick={updateAttendance}
                        color='teal'>
                        Join Ride
                    </Button>
                )}
            </Segment>
        </Segment.Group>
    )
})