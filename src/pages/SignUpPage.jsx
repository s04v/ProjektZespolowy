import Header from "../components/Header";
import Footer from "../components/Footer";
import Background from "../components/Background";
import SignForm from "../components/SignForm";
import { useState } from "react";

const SignUpPage = () => {
    const sameFields = [
        { id: '3', title: 'Email', type: 'text' },
        { id: '4', title: 'Password', type: 'password' },
        { id: '5', title: 'Repeat password', type: 'password' },
    ];

    const fieldsEmployee = [
        { id: '1', title: 'First Name', type: 'text' },
        { id: '2', title: 'Last Name', type: 'text' },
    ].concat(sameFields);

    const fieldsEmployer = [
        { id: '1', title: 'Employer Name', type: 'text' },
        { id: '2', title: 'Country', type: 'text' },
    ].concat(sameFields);

    const [tab, setTab] = useState(0);
    const [fields, setFields] = useState(fieldsEmployee);


    const onSwitch = (whichOne) => {
        setTab(whichOne);
        setFields(whichFields(whichOne));
    }

    const onSend = () => {
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