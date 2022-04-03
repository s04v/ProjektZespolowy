import Header from "../components/Header";
import Footer from "../components/Footer";
import Background from "../components/Background";
import SignForm from "../components/SignForm";
import { useState } from "react";

const SignUpPage = () => {
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
        { id: '1', name:'employerName', title: 'Employer Name', type: 'text' },
        { id: '2', name: 'country', title: 'Country', type: 'text' },
    ].concat(sameFields);

    const [tab, setTab] = useState(0);
    const [fields, setFields] = useState(fieldsEmployee);

    const onSwitch = (whichOne) => {
        setTab(whichOne);
        setFields(whichFields(whichOne));
    }

    const onSend = (data) => {
        console.log(data);
        alert(tab);
    }

    const setTitle = (tab) => {
        const type = (tab ? 'Employer' : 'Employee') ;
        return type + ' register';
    }

    const whichFields = (tab) => {
        return (tab? fieldsEmployer : fieldsEmployee);
    }

    return (
        <>
            <Header onSwitch={onSwitch} />
            <div className="container">
                <SignForm
                    title={setTitle(tab)} 
                    fields={fields}
                    onSend={onSend}
                    buttonTitle='Register' />
            </div>
            <Background />
            <Footer />
        </>
    )
}

export default SignUpPage;