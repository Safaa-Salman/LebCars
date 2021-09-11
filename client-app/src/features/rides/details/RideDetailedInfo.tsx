import { format } from 'date-fns';
import { observer } from 'mobx-react-lite';
import React from 'react'
import { Segment, Grid, Icon } from 'semantic-ui-react'
import { Ride } from "../../../app/models/ride";
import { MdSmokingRooms, MdChildFriendly, MdPets } from "react-icons/md";

interface Props {
    ride: Ride
}

export default observer(function RideDetailedInfo({ ride }: Props) {
    return (
        <Segment.Group>
            <Segment attached='top'>
                <Grid>
                    <Grid.Column width={1}>
                        <Icon size='large' color='teal' name='info' />
                    </Grid.Column>
                    <Grid.Column width={15}>
                        <p>{ride.description}</p>
                    </Grid.Column>
                </Grid>
            </Segment>
            <Segment attached>
                <Grid verticalAlign='middle'>
                    <Grid.Column width={1}>
                        <Icon name='calendar' size='large' color='teal' />
                    </Grid.Column>
                    <Grid.Column width={15}>
                        <span>
                          Departure: {format(ride.departureDate!, 'dd MMM yyyy h:mm aa')} <br /> Return: {format(ride.departureDate!, 'dd MMM yyyy h:mm aa')}
                        </span>
                    </Grid.Column>
                </Grid>
            </Segment>
            <Segment attached>
                <Grid verticalAlign='middle'>
                    <Grid.Column width={1}>
                        <Icon name='marker' size='large' color='teal' />
                    </Grid.Column>
                    <Grid.Column width={11}>
                        <span>Departure:{ride.departure} <br /> Destination: {ride.destination}</span>
                    </Grid.Column>
                </Grid>
            </Segment>
            <Segment attached>
                <Grid verticalAlign='middle'>
                    <Grid.Column width={1}>
                        <Icon name='dollar sign' size='large' color='teal' />
                    </Grid.Column>
                    <Grid.Column width={11}>
                        <span>Cost: {ride.cost}</span>
                    </Grid.Column>
                </Grid>
            </Segment>
            <Segment attached>
                <Grid verticalAlign='middle'>
                    <Grid.Column width={1}>
                        <Icon name='users' size='large' color='teal' />
                    </Grid.Column>
                    <Grid.Column width={11}>
                        <span>Number Of Passengers:{ride.passengerNumber}</span>
                    </Grid.Column>
                </Grid>
            </Segment>
            <Segment attached>
                <Grid verticalAlign='middle'>
                    <Grid.Column width={1}>
                        <MdSmokingRooms size='large' color='teal'/>
                    </Grid.Column>
                    <Grid.Column width={11}>
                    {ride.smoking ? (
                        <span>Smoking is allowed</span>
                    ) : (
                        <span>Smoking is not allowed</span>
                    )}
                    </Grid.Column>
                </Grid>
            </Segment>
            <Segment attached>
                <Grid verticalAlign='middle'>
                    <Grid.Column width={1}>
                        <MdChildFriendly size='large' color='teal'/>
                    </Grid.Column>
                    <Grid.Column width={11}>
                    {ride.children ? (
                        <span>Children are allowed</span>
                    ) : (
                        <span>Children are not allowed</span>
                    )}
                    </Grid.Column>
                </Grid>
            </Segment>
            <Segment attached>
                <Grid verticalAlign='middle'>
                    <Grid.Column width={1}>
                        <MdPets size='large' color='teal'/>
                    </Grid.Column>
                    <Grid.Column width={11}>
                    {ride.animals ? (
                        <span>Pets are allowed</span>
                    ) : (
                        <span>Pets are not allowed</span>
                    )}
                    </Grid.Column>
                </Grid>
            </Segment>
        </Segment.Group>
    )
})