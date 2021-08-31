import { ErrorMessage, Form, Formik } from 'formik';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, Header, Label } from 'semantic-ui-react';
import MyTextInput from '../../app/common/form/MyTextInput';
import { useStore } from '../../app/stores/store';



export default observer(function LoginForm() {
    const {userStore} = useStore();
    return (
        <Formik
            initialValues={{email: '', password: '', error: null}}
            onSubmit={(values, {setErrors}) => userStore.login(values).catch(error => 
                setErrors({error: 'Invalid email or password'}))}
        >
            {({handleSubmit, isSubmitting, errors}) => (
                <Form className='ui form' onSubmit={handleSubmit} autoComplete='off' style={{margin: '5em 2em'}}>
                    <img className='ui small centered image' src='/assets/logo.png' alt='logo' style={{ marginBottom:"5em" }} />
                    <Header as='h2' content='Log-in to your account' color='teal' textAlign='center'/>
                    <MyTextInput name='email' placeholder='E-mail address' icon='user icon' />
                    <MyTextInput name='password' placeholder='Password' type='password' icon="lock icon" />
                    <ErrorMessage
                        name='error' render={() => 
                        <Label style={{marginBottom: 10}} basic color='red' content={errors.error}/>
                    }
                    />
                    <Button loading={isSubmitting} color='teal' content='Login' type='submit' fluid />
                </Form>
            )}
        </Formik>
    )
})