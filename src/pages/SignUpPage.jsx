import Header from "../components/Header";
import Footer from "../components/Footer";
import Background from "../components/Background";
import SignForm from "../components/SignForm";
import {useEffect, useState} from "react";

import { setError, setErrorText } from '../actions/mainActions';
import { connect } from 'react-redux';
import { registerAccount } from "../api/CompanyApi";

const SignUpPage = (props) => {
    const sameFields = [
        { id: '3', name:'email', title: 'Email', type: 'text' },
        { id: '4', name:'password', title: 'Password', type: 'password' },
        { id: '5', name:'repeatPassword', title: 'Repeat password', type: 'password' },
    ];

    const fieldsEmployee = [
        { id: '1', name:'firstName', title: 'First Name', type: 'text' },
        { id: '2', name:'lastName', title: 'Last Name', type: 'text' },
    ].concat(sameFields);

    const fieldsEmployer = [
        { id: '1', name:'companyName', title: 'Employer Name', type: 'text' },
        { id: '2', name: 'country', title: 'Country', type: 'text' },
    ].concat(sameFields);

    const [fields, setFields] = useState(fieldsEmployee);

    const onSend = (data) => {
        console.log(data);
        const unwrap = ({companyName, email, password}) => ({companyName, email, password});

        console.log(unwrap(data));
        registerAccount(unwrap(data))
            .then((result) => {
                if(result.data === "OK"){
                    props.setError(false);
                }
                else {
                    props.setError(true);
                    props.setErrorText(result.data);
                }
            })
            .catch((error) => {
                props.setError(true);
                // back-end returns 400 when password less then 6 or email wrong
                // To fix
                props.setErrorText('Password must contain at least 6 symbols');
            });
    }

    const setTitle = (tab) => {
        const type = (tab ? 'Employer' : 'Employee') ;
        return type + ' register';
    }

    const whichFields = (tab) => {
        return (tab? fieldsEmployer : fieldsEmployee);
    }

    useEffect(() => {
        setFields(whichFields(props.tab));
    },[props.tab]);

    return (
        <>
            <Header />
            <div className="container">
                <SignForm
                    title={setTitle(props.tab)}
                    fields={fields}
                    onSend={onSend}
                    buttonTitle='Register' />
            </div>
            <Background />
            <Footer />
        </>
    )
}

const mapStateToProps = (state) => {
    return {
        tab: state.mainReducer.tab,
        isError: state.mainReducer.isError,
        errorText: state.mainReducer.errorText
    }
}

export default connect(mapStateToProps,{ setError, setErrorText})(SignUpPage);