import { observer } from 'mobx-react-lite';
import { useEffect, useState } from 'react';
import { Link, useHistory, useParams } from 'react-router-dom';
import { Button, Header, Segment } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import { v4 as uuid } from 'uuid';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import MyTextInput from '../../../app/common/form/MyTextInput';
import MyTextArea from '../../../app/common/form/MyTextArea';
import { prefrenceOptions } from '../../../app/common/options/prefrenceOptions';
import MySelectInput from '../../../app/common/form/MySelectInput';
import MyDateInput from '../../../app/common/form/MyDateInput';
import { RideFormValues } from '../../../app/models/ride';

export default observer(function RideForm() {
    const history = useHistory();
    const { rideStore } = useStore();
    const { createRide, updateRide, loadRide, loadingInitial } = rideStore;
    const { id } = useParams<{ id: string }>();

    const [ride, setRide] = useState<RideFormValues>(new RideFormValues());

    const validationSchema = Yup.object({
        departure: Yup.string().required('The ride departure is required'),
        destination: Yup.string().required('The ride destination is required'),
        departureDate: Yup.string().required('Date is required').nullable(),
        returnDate: Yup.string().required('Date is required').nullable(),
        passengerNumber: Yup.string().required(),
        cost: Yup.string().required(),
        description: Yup.string().required(),
        children: Yup.string().required(),
        animals: Yup.string().required(),
        smoking: Yup.string().required()
    })

    useEffect(() => {
        if (id) loadRide(id).then(ride => setRide(new RideFormValues(ride)))
    }, [id, loadRide]);

    function handleFormSubmit(ride: RideFormValues) {
        if(!ride.id) {
            let newRide = {
                ...ride,
                id: uuid()
            };
            createRide(newRide).then(() => history.push(`/rides/${newRide.id}`))
        } else {
            updateRide(ride).then(() => history.push(`/rides/${ride.id}`))
        }
    }


    if (loadingInitial) return <LoadingComponent content='Loading ride...' />

    return (
        <Segment clearing>
            <Header content='Ride Details' large color='teal' />
            <Formik 
                validationSchema={validationSchema}
                enableReinitialize 
                initialValues={ride} 
                onSubmit={values => handleFormSubmit(values)}>
                    {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                        <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                            
                            <MyTextInput placeholder='Departure'  name='departure' icon='map marker alternate icon' />
                            <MyTextInput placeholder='Destination'  name='destination' icon='location arrow icon' />
                            <MyDateInput 
                                placeholderText='Departure date'  
                                name='departureDate'
                                showTimeSelect
                                timeCaption='time'
                                dateFormat='MMMM d, yyyy h:mm aa'  
                            />
                            <MyDateInput 
                                placeholderText='Return date'  
                                name='returnDate'
                                showTimeSelect
                                timeCaption='time'
                                dateFormat='MMMM d, yyyy h:mm aa'  
                            />
                            <MyTextInput placeholder='Number Of Passengers'  name='passengerNumber' icon='users icon'  />
                            <MyTextInput placeholder='Cost'  name='cost' icon='dollar sign icon' />
                            <MyTextArea rows={3} placeholder='Description'  name='description'  />
                            <Header content='Preferences' sub color='teal' />
                            <MySelectInput options={prefrenceOptions} placeholder='Are Children Allowed?'  name='children'  />
                            <MySelectInput options={prefrenceOptions} placeholder='Is Smoking Allowed?'  name='smoking'  />
                            <MySelectInput options={prefrenceOptions} placeholder='Are Pets Allowed?'  name='animals'  />
                            <Button 
                                disabled={isSubmitting || !dirty || !isValid}
                                loading={isSubmitting} floated='right' 
                                positive type='submit' content='Submit' />
                            <Button as={Link} to='/rides' floated='right' type='submit' content='Cancel' />
                        </Form>
                    )}
            </Formik>
        </Segment>
    )
})

