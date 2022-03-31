import Header from "../components/Header";
import Footer from "../components/Footer";
import Background from "../components/Background";
import Button from "../components/Button";
import {useState} from "react";

const SignInPage = () => {
    const [tab, setTab] = useState(0);

    const onSwitch = (whichOne) => {
        setTab(whichOne);
    }

    const onSend = () => {
        alert(tab);
    }

    return(
        <>
            <Header onSwitch={onSwitch}  />
                <div className="container">
                <div className='form-section'>
                    <h1>Employee login</h1>
                    <div>
                        <p>Email</p>
                        <input type='text'/>
                    </div>
                    <div>
                        <p>Password</p>
                        <input type='password'/>
                    </div>
                    <Button onClick={onSend}>Send</Button>
                </div>
                </div>
            <Background />
            <Footer />
        </>
    )
}

export default SignInPage;