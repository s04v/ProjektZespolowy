import OfferChanger from "../components/OfferChanger";
import style from '../styles/components/profileInfo.module.scss';
import React, {useEffect, useState} from "react";
import {connect} from "react-redux";
import {setRole} from "../actions/MainActions";
import { AiOutlineEdit} from "react-icons/ai";
import CompanyApi from "../api/CompanyApi";


const EmployerPage = () => {

    const [isOpen, setIsOpen] = useState(false);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('*********');
    const [name, setName] = useState('');
    const [location, setLocation] = useState('');

    useEffect(() => {
        const testData = CompanyApi.getProfile();

        testData.then(data => {
            console.log(data);
            const info = data.data.data;

            const getOffers = CompanyApi.getProfileData(info.id);

            getOffers.then(data => {
                console.log(data);
            });

            setEmail(info.email);
            setName(info.name);
            if(info.userAddress != null)
                setLocation(info.userAddress);
        });

    },[]);

    const onOpenClick = () => {
        setIsOpen(!isOpen);
    }

    const onBlur = (e) => {
        console.log(e.target.value);
    }


    return (
        <>
            <h1>Company profile</h1>
            <img src="https://thispersondoesnotexist.com/image" />
            <div className={`${style.profileInfo} ${isOpen ? style.isOpen : ''}`}>
                <div className={`${style.fieldsList} ${isOpen ? style.hideItems : ''}`}>
                        <div className={style.field}>
                            <p>E-mail:</p>
                            <div className={style.inputEdit}>
                                <input 
                                    onBlur={onBlur} 
                                    autoComplete={"qwe"} 
                                    value={email} 
                                    name={"email"} 
                                    type={"text"} 
                                    onChange={(e) => setEmail(e.target.value)}/>
                                <AiOutlineEdit size={16} />
                            </div>
                        </div>
                        <div className={style.field}>
                            <p>Password:</p>
                            <div className={style.inputEdit}>
                                <input 
                                    onBlur={onBlur} 
                                    autoComplete={"qwe"} 
                                    value={password} 
                                    name={"password"} 
                                    type={'password'} 
                                    onChange={(e) => setPassword(e.target.value)}/>
                                <AiOutlineEdit size={16} />
                            </div>
                        </div>
                        <div className={style.field}>
                            <p>Company name:</p>
                            <div className={style.inputEdit}>
                                <input 
                                    onBlur={onBlur} 
                                    autoComplete={"qwe"} 
                                    value={name} 
                                    name={"name"} 
                                    type={'text'} 
                                    onChange={(e) => setName(e.target.value)}/>
                                <AiOutlineEdit size={16} />
                            </div>
                        </div>
                        <div className={style.field}>
                            <p>Location:</p>
                            <div className={style.inputEdit}>
                                <input 
                                    onBlur={onBlur} 
                                    autoComplete={"qwe"} 
                                    value={location} 
                                    name={"location"} 
                                    type={'text'} 
                                    onChange={(e) => setLocation(e.target.value)}/>
                                <AiOutlineEdit size={16} />
                            </div>
                        </div>
                    </div>
                <div className={style.closeButton} onClick={onOpenClick}>Close</div>
            </div>
            <OfferChanger />
        </>
    );
}
const mapStateToProps = (state) => {
    return {
        role: state.mainReducer.role
    }
}

export default connect(mapStateToProps,null)(EmployerPage);