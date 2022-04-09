import Header from "../components/Header";
import Footer from "../components/Footer";
import Background from "../components/Background";
import SignForm from "../components/SignForm";
import {setError, setErrorText} from "../actions/mainActions";
import {connect} from "react-redux";
import { login } from "../api/UserApi";
import {useEffect} from "react";
import UserApi from "../api/UserApi";
import CompanyApi from "../api/CompanyApi";

const SignInPage = (props) => {
    const fields = [
        { id: '1', name: 'email', title: 'Email', type: 'text' },
        { id: '2', name: 'password', title: 'Password', type: 'password' },
    ]

    const onSend = (data) => {
        for(const key in data) {
            if(data[key] === '') {
                props.setError(true);
                props.setErrorText(key + " cannot be empty");
                return;
            }
        }

        const send = props.tab ?  CompanyApi.login : UserApi.login;

        send(data)
            .then((result) => {
                    props.setError(false);
                    props.setErrorText(result.data);
            })
            .catch((error) => {
                props.setError(true);
                props.setErrorText('Login/Password is incorrect!');
            });
    }

    const setTitle = (tab) => {
        const type = (tab ? 'Employer' : 'Employee');
        return type + ' login';
    }

    useEffect(() => {
        props.setError(false);

    },[props.tab])

    return (
        <>
            <Header />
            <div className="container">
                <SignForm
                    title={setTitle(props.tab)}
                    fields={fields}
                    onSend={onSend}
                    buttonTitle='Sign in' />
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

export default connect(mapStateToProps, { setError, setErrorText })(SignInPage);