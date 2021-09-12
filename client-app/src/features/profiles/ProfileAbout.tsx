import React, { useState } from 'react';
import { useStore } from "../../app/stores/store";
import { Button, Grid, Header, Segment, Tab } from "semantic-ui-react";
import ProfileEditForm from "./ProfileEditForm";
import { observer } from 'mobx-react-lite';

export default observer(function ProfileAbout() {
    const { profileStore } = useStore();
    const { isCurrentUser, profile } = profileStore;
    const [editMode, setEditMode] = useState(false);
    return (
        <Tab.Pane>
            <Grid>
                <Grid.Column width='16'>
                    <Header floated='left' icon='user' content={`About ${profile?.displayName}`} />
                    {isCurrentUser && (
                        <Button
                            floated='right'
                            basic
                            content={editMode ? 'Cancel' : 'Edit Profile'}
                            onClick={() => setEditMode(!editMode)}
                        />
                    )}
                </Grid.Column>
                <Grid.Column width='16'>
                    {editMode ? <ProfileEditForm setEditMode={setEditMode} /> :
                        <>
                            <Segment attached='top'>
                                <Grid>
                                    <Grid.Column width={3}>
                                    <Header content="Gender" color='teal' as='h4' />
                                    </Grid.Column>
                                    <Grid.Column width={9}>
                                        <p>{profile?.gender}</p>
                                    </Grid.Column>
                                </Grid>
                            </Segment>
                            <Segment attached>
                                <Grid verticalAlign='middle'>
                                    <Grid.Column width={3}>
                                    <Header content="Age" color='teal' as='h4' />
                                    </Grid.Column>
                                    <Grid.Column width={9}>
                                        <p>{profile?.age}</p>
                                    </Grid.Column>
                                </Grid>
                            </Segment>
                            <Segment attached>
                                <Grid verticalAlign='middle'>
                                    <Grid.Column width={3}>
                                    <Header content="Bio" color='teal' as='h4' />
                                    </Grid.Column>
                                    <Grid.Column width={9}>
                                        <span style={{ whiteSpace: 'pre-wrap' }}>{profile?.bio}</span>
                                    </Grid.Column>
                                </Grid>
                            </Segment>

                            <Segment attached>
                                <Grid verticalAlign='middle'>
                                    <Grid.Column width={3}>
                                    <Header content="Phone Number" color='teal' as='h4' />
                                    </Grid.Column>
                                    <Grid.Column width={9}>
                                        <p>{profile?.phoneNumber}</p>
                                    </Grid.Column>
                                </Grid>
                            </Segment>
                            <Segment attached>
                                <Grid verticalAlign='middle'>
                                    <Grid.Column width={3}>
                                    <Header content="Car Model" color='teal' as='h4' />
                                    </Grid.Column>
                                    <Grid.Column width={9}>
                                        <p>{profile?.carModel}</p>
                                    </Grid.Column>
                                </Grid>
                            </Segment>
                            <Segment attached>
                                <Grid verticalAlign='middle'>
                                    <Grid.Column width={3}>
                                    <Header content="Car Number" color='teal' as='h4' />
                                    </Grid.Column>
                                    <Grid.Column width={9}>
                                        <p>{profile?.carNumber}</p>
                                    </Grid.Column>
                                </Grid>
                            </Segment>
                        </>
                    }
                </Grid.Column>
            </Grid>
        </Tab.Pane>
    )
})