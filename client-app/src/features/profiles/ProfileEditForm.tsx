import { Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import { Button } from "semantic-ui-react";
import MyTextArea from "../../app/common/form/MyTextArea";
import MyTextInput from "../../app/common/form/MyTextInput";
import { useStore } from "../../app/stores/store";
import * as Yup from 'yup';
import MySelectInput from "../../app/common/form/MySelectInput";
import { genderOptions } from "../../app/common/options/prefrenceOptions";
interface Props {
    setEditMode: (editMode: boolean) => void;
}
export default observer(function ProfileEditForm({ setEditMode }: Props) {
    const { profileStore: { profile, updateProfile } } = useStore();
    return (
        <Formik
            initialValues={{
                displayName: profile?.displayName,
                bio: profile?.bio,
                age: profile?.age,
                gender: profile?.gender,
                carModel: profile?.carModel,
                carNumber: profile?.carNumber,
                phoneNumber: profile?.phoneNumber,
            }}
            onSubmit={values => {
                updateProfile(values).then(() => {
                    setEditMode(false);
                })
            }}
            validationSchema={Yup.object({
                displayName: Yup.string().required()
            })}
        >
            {({ isSubmitting, isValid, dirty }) => (
                <Form className='ui form'>
                    <MyTextInput placeholder='Display Name'
                        name='displayName' />
                    <MyTextInput placeholder='Age'
                        name='age' />
                    <MySelectInput options={genderOptions} placeholder='Gender'  name='gender'  />
                    <MyTextInput placeholder='Car Model'
                        name='carModel' />
                    <MyTextInput placeholder='Car Number'
                        name='carNumber' />
                    <MyTextInput placeholder='Phone Number'
                        name='phoneNumber' />
                    <MyTextArea rows={3} placeholder='Add your bio'
                        name='bio' />
                    <Button
                        positive
                        type='submit'
                        loading={isSubmitting}
                        content='Update profile'
                        floated='right'
                        disabled={!isValid || !dirty}
                    />
                </Form>
            )}
        </Formik>
    )
})