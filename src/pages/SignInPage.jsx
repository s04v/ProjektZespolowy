import Header from "../components/Header";
import Footer from "../components/Footer";
import Background from "../components/Background";
import SignForm from "../components/SignForm";
import {setError, setErrorText} from "../actions/mainActions";
import {connect} from "react-redux";

const SignInPage = (props) => {
    const fields = [
        { id: '1', name: 'email', title: 'Email', type: 'text' },
        { id: '2', name: 'password', title: 'Password', type: 'password' },
    ]

    const onSend = (data) => {
        console.log(data);
    }

    const setTitle = (tab) => {
        const type = (tab ? 'Employer' : 'Employee');
        return type + ' login';
    }

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