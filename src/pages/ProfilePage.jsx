import CheckAuth from "../utils/CheckAuth";
import Header from "../components/Header";
import Background from "../components/Background";
import Footer from "../components/Footer";
import style from '../styles/pages/EmployeeProfilePage.scss';
import ProfileInfo from "../components/ProfileInfo";
import EmployeePage from "./EmployeePage";
import {connect} from "react-redux";

const ProfilePage = (props) => {
    return (
        <>
        <Header />
        <div className="container">
            <div className="main-block">
                <div className="profile">
                    {
                        props.role == 'Company' ? <>todo</>: <EmployeePage />
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