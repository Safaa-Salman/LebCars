import { format } from 'date-fns';
import { Link } from 'react-router-dom';
import { Button, Icon, Item, ItemDescription, Label, Segment } from 'semantic-ui-react';
import { Ride } from '../../../app/models/ride';
import RideListItemAttendee from './RideListItemAttendee';

interface Props {
    ride: Ride;
}

export default function RideListItem({ ride }: Props) {

    return (
        <Segment.Group >
            <Segment>
                {ride.isCancelled &&
                    <Label attached='top' color='red' content='Cancelled' style={{ textAlign: 'center' }} />
                }
                <Item.Group>
                    <Item>
                        <Item.Image style={{ marginBottom: 3 }} size='tiny' src={ride.driver?.image || '/assets/user.png'} />
                        <Item.Content>
                            <Item.Header as={Link} to={`/rides/${ride.id}`}>
                                <Icon name='marker' />Departure: {ride.departure}
                            </Item.Header>
                            <br /> <br />
                            <Item.Header as={Link} to={`/rides/${ride.id}`}>
                                <Icon name='marker' />Destination: {ride.destination}
                            </Item.Header>
                            <Item.Description>Hosted by <Link to={`/profiles/${ride.driverUsername}`}>{ride.driver?.displayName}</Link></Item.Description>
                            {ride.isDriver && (
                                <ItemDescription>
                                    <Label color='orange' basic>
                                        You are hosting this ride
                                    </Label>
                                </ItemDescription>
                            )}
                            {ride.isGoing && !ride.isDriver && (
                                <ItemDescription>
                                    <Label color='green' basic>
                                        You are going to this ride
                                    </Label>
                                </ItemDescription>
                            )}
                        </Item.Content>
                    </Item>
                </Item.Group>
            </Segment>
            <Segment>
                <ItemDescription>
                    Car Model: {ride.driver?.carModel}
                </ItemDescription>
                <ItemDescription>
                    Departure date: {format(ride.departureDate!, 'dd MMM yyyy h:mm aa')} <br />
                    Return date: {format(new Date(ride.returnDate!), 'do LLL')} {format(new Date(ride.returnDate!), 'h:mm a')}
                </ItemDescription>
                <ItemDescription>
                    Cost: {ride.cost}
                </ItemDescription>
                <ItemDescription>
                    {(ride.children === 'true') ? (
                        <Label color='green' >
                            Children allowed
                        </Label>
                    ) : (
                        <Label color='red'>
                            Children not allowed
                        </Label>
                    )}
                    {(ride.smoking === 'true') ? (
                        <Label color='green' >
                            Smoking allowed
                        </Label>
                    ) : (
                        <Label color='red' >
                            Smoking not allowed
                        </Label>
                    )}
                    {(ride.animals === 'true') ? (
                        <Label color='green' >
                            Pets allowed
                        </Label>
                    ) : (
                        <Label color='red' >
                            Pets not allowed
                        </Label>
                    )}
                    {(ride.baggage === 'true') ? (
                        <Label color='green' >
                            Baggage allowed
                        </Label>
                    ) : (
                        <Label color='red' >
                            Baggages not allowed
                        </Label>
                    )}
                </ItemDescription>
                
            </Segment>
            <Segment secondary>
                <RideListItemAttendee attendees={ride.attendees!} />
            </Segment>
            <Segment clearing>
                <span>Description: {ride.description}</span>
                <Button
                    as={Link}
                    to={`/rides/${ride.id}`}
                    color='teal'
                    floated='right'
                    content='View'
                />
            </Segment>
        </Segment.Group>
    )
}