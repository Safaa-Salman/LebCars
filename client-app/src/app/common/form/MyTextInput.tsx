import React from 'react';
import { useField } from 'formik';
import { Form, Label } from 'semantic-ui-react';
 
 interface Props {
   placeholder: string;
   name: string;
   type?: string;
   label?: string;
   icon?: string;
 }

 export default function MyTextInput(props: Props) {
    const [field, meta] = useField(props.name);
    const icon = props.icon;
    return (
        <Form.Field error={meta.touched && !!meta.error}>
            <label>{props.label}</label>
            <div className="ui left icon input">
                <input {...field} {...props} />
                <i className={icon}></i>
            </div>
            {meta.touched && meta.error ? (
                <Label basic color='red'>{meta.error}</Label>
            ) : null}
        </Form.Field>
    )
 }