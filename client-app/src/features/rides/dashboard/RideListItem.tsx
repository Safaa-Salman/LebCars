import { format } from 'date-fns';
import { Link } from 'react-router-dom';
import { Button, Icon, Item, ItemDescription, Label, Segment } from 'semantic-ui-react';
import { Ride } from '../../../app/models/ride';
import RideListItemAttendee from './RideListItemAttendee';

interface Props {
    ride: Ride;
}

export default function RideListItem({ride}: Props) {

    return (
        <Segment.Group>
            <Segment>
                {ride.isCancelled &&
                    <Label attached='top' color='red' content='Cancelled' style={{textAlign: 'center'}}/>
                }
                <Item.Group>
                    <Item>
                    <Item.Image style={{marginBottom: 3}} size='tiny' circular src={ride.driver?.image || '/assets/user.png'} />
                        <Item.Content>
                            <Item.Header as={Link} to={`/rides/${ride.id}`}>
                                {ride.departure} to {ride.destination}
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
                <span>
                    <Icon name='clock'/> {format(ride.departureDate!, 'dd MMM yyyy h:mm aa')}
                    <Icon name='marker'/> {ride.cost}
                </span>
            </Segment>
            <Segment secondary>
                <RideListItemAttendee attendees={ride.attendees!}/>
            </Segment>
            <Segment clearing>
                <span>{ride.description}</span>
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