import Header from "../components/Header";
import Footer from "../components/Footer";
import Background from "../components/Background";
import { useState } from "react";
import SignForm from "../components/SignForm";

const SignInPage = () => {
    const [tab, setTab] = useState(0);
    const fields = [
        { id: '1', name: 'email', title: 'Email', type: 'text' },
        { id: '2', name: 'password', title: 'Password', type: 'password' },
    ]

    const onSwitch = (whichOne) => {
        setTab(whichOne);
    }

    const onSend = (data) => {
        console.log(data);
        alert(tab);
    }

    const setTitle = (tab) => {
        const type = (tab ? 'Employer' : 'Employee');
        return type + ' login';
    }

    return (
        <>
            <Header onSwitch={onSwitch} />
            <div className="container">
                <SignForm
                    title={setTitle(tab)}
                    fields={fields}
                    onSend={onSend}
                    buttonTitle='Sign in' />
            </div>
            <Background />
            <Footer />
        </>
    )
}

export default SignInPage;