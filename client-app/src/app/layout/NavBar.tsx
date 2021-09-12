import { observer } from 'mobx-react-lite';
import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Button, Container, Dropdown, Image, Menu } from 'semantic-ui-react';
import { useStore } from '../stores/store';
import './navbar.css';

export default observer(function NavBar() {
    const { userStore: { user, logout } } = useStore();
    return (
        <div className='ui secondary pointing menu fixed'>
            <Container>
                <Menu.Item as={NavLink} exact to='/' header>
                    <img src="/assets/logo_small.png" alt="logo" className='ui small image' />
                </Menu.Item>

                <Menu.Item as={NavLink} to='/rides' name='Rides' />
                {/* <Menu.Item as={NavLink} to='/errors' name='errors' /> */}
                <Menu.Item >
                    {/* <Button className='ui inverted button' as={NavLink} to='/createRide' content='Create Ride' /> */}
                    <Button id="homeButton" as={NavLink} to='/createRide' content='Create Ride' />
                </Menu.Item>
                <Menu.Item className='right menu'>
                    <Image src={user?.image || 'assets/user.png'} avatar spaced='right' />
                    <Dropdown pointing='top left' text={user?.displayName}>
                        <Dropdown.Menu>
                            <Dropdown.Item as={Link} to={`profiles/${user?.username}`} text='My Profile' icon='user' />
                            <Dropdown.Item onClick={logout} text='Logout' icon='power' />
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
            </Container>
        </div>

    )
})