import CheckAuth from "../utils/CheckAuth";
import Header from "../components/Header";
import Background from "../components/Background";
import Footer from "../components/Footer";
import style from '../styles/pages/EmployeeProfilePage.scss';
import EmployeePage from "./EmployeePage";
import EmployerPage from "./EmployerPage";
import {connect} from "react-redux";

const ProfilePage = (props) => {
    return (
        <>
        <Header />
        <div className="container">
            <div className="main-block">
                <div className="profile">
                    {
                        props.role == 'Company' ? <EmployerPage />: <EmployeePage />
                    }

                </div>
            </div>
        </div>
        <Background />
        <Footer />
        </>

    )
}

const mapStateToProps = (state) => {
    return {
        role: state.mainReducer.role
    }
}

export default connect(mapStateToProps, null)(ProfilePage);