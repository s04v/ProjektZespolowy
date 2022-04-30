import style from '../styles/components/profileInfo.module.scss';
import React, {useEffect, useState} from "react";
import {connect} from "react-redux";
import {setRole} from "../actions/MainActions";
import { AiOutlineEdit} from "react-icons/ai";
import UserApi from "../api/UserApi";


const EmployeePage = () => {
    const [isOpen, setIsOpen] = useState(false);

    useEffect(() => {
        const testData = UserApi.getProfile();

        testData.then(data => {
            console.log(data);
            const info = data.data.data;
            setEmail(info.email);
            setFirstName(info.firstName);
            setLastName(info.lastName);
            setPhone(info.contactNumber);
            if(info.userAddress != null)
                setLocation(info.userAddress);

        })
    },[]);

    const onOpenClick = () => {
        setIsOpen(!isOpen);
    }

    const onBlur = (e) => {
        console.log(e.target.value);
    }

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('*********');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [phone, setPhone] = useState('');
    const [location, setLocation] = useState('');

    return (
        <>
            <h1>Profile</h1>
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
                            <p>First name:</p>
                            <div className={style.inputEdit}>
                                <input 
                                    onBlur={onBlur} 
                                    autoComplete={"qwe"} 
                                    value={firstName} 
                                    name={"firstName"} 
                                    type={'text'} 
                                    onChange={(e) => setFirstName(e.target.value)}/>
                                <AiOutlineEdit size={16} />
                            </div>
                        </div>
                        <div className={style.field}>
                            <p>Last name:</p>
                            <div className={style.inputEdit}>
                                <input 
                                    onBlur={onBlur} 
                                    autoComplete={"qwe"} 
                                    value={lastName} 
                                    name={"lastName"} 
                                    type={'text'} 
                                    onChange={(e) => setLastName(e.target.value)}/>
                                <AiOutlineEdit size={16} />
                            </div>
                        </div>
                        <div className={style.field}>
                            <p>Phone:</p>
                            <div className={style.inputEdit}>
                                <input 
                                    onBlur={onBlur} 
                                    autoComplete={"qwe"} 
                                    value={phone} 
                                    name={"phone"} 
                                    type={'text'} 
                                    onChange={(e) => setPhone(e.target.value)}/>
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
        </>
    );
}

const mapStateToProps = (state) => {
    return {
        role: state.mainReducer.role
    }
}

export default connect(mapStateToProps,null)(EmployeePage);