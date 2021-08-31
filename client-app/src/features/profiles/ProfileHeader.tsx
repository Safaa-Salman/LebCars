import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, Divider, Grid, GridColumn, Header, Item, Reveal, Segment, Statistic, StatisticGroup } from 'semantic-ui-react';
import { Profile } from '../../app/models/profile';

interface Props {
    profile : Profile;
}
export default observer(function ProfileHeader({profile}: Props) {
    return (
        <Segment>
            <Grid>
                <GridColumn width={12}>
                    <Item.Group>
                        <Item>
                            <Item.Image avatar size='small' src={profile.image || '/assets/user.png'} />
                            <Item.Content verticalAlign='middle'>
                                <Header as='h1' content={profile.displayName} />
                            </Item.Content>
                        </Item>
                    </Item.Group>
                </GridColumn>
                <GridColumn width={4}>
                    <StatisticGroup widths={2}>
                        <Statistic label ='Followers' value='5' />
                        <Statistic label ='Following' value='42' />
                    </StatisticGroup>
                    <Divider />
                    <Reveal animated='move'>
                        <Reveal.Content visible style={{width:'100%'}}>
                            <Button fluid color='teal' content='Following' />
                        </Reveal.Content>
                        <Reveal.Content hidden style={{width:'100%'}}>
                            <Button 
                                fluid 
                                basic
                                color={true ? 'red' : 'green'} 
                                content={true ? 'Unfollow' : 'Follow'}
                            />
                        </Reveal.Content>
                    </Reveal>
                </GridColumn>
            </Grid>
        </Segment>
    )
})