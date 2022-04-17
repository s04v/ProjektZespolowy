import style from '../styles/components/profileInfo.module.scss';
import React, {useEffect, useState} from "react";
import {connect} from "react-redux";
import {setRole} from "../actions/MainActions";
import { AiOutlineEdit} from "react-icons/ai";


const ProfileInfo = (props) => {
    const employeeFields = [
        { id: '1', name: 'email', title: 'Email', type: 'text' },
        { id: '2', name: 'password', title: 'Password', type: 'password' },
        { id: '3', name: 'firstName', title: 'First name', type: 'text' },
        { id: '4', name: 'lastName', title: 'Last name', type: 'text' },
        { id: '5', name: 'phone', title: 'Phone', type: 'text' },
        { id: '6', name: 'location', title: 'Location', type: 'text' },
    ]

    const employerFields = [
        { id: '1', name: 'email', title: 'Email', type: 'text' },
        { id: '2', name: 'password', title: 'Password', type: 'password' },
    ]
    const [data, setData] = useState({});
    const [isOpen, setIsOpen] = useState(false);

    useEffect(() => {
        console.log(props);
    },[]);

    const onChange = (e) => {
        setData({ ...data, [e.target.name]: e.target.value });
    }

    const onOpenClick = () => {
        setIsOpen(!isOpen);
    }

    const onBlur = () => {
        console.log(data);
        setData({});
    }


    return (
        <div className={`${style.profileInfo} ${isOpen ? style.isOpen : ''}`}>
            <div className={`${style.fieldsList} ${isOpen ? style.hideItems : ''}`}>
                {employeeFields.map((item) =>
                    <div key={item.id} className={style.field}>
                        <p>{item.title}:</p>
                        <input onBlur={onBlur} autoComplete={"qwe"} name={item.name} type={item.type} onChange={onChange}/>
                        <AiOutlineEdit size={16} />
                    </div>
                )}
            </div>
            <div className={style.closeButton} onClick={onOpenClick}>Close</div>
        </div>
    )
}

const mapStateToProps = (state) => {
    return {
        role: state.mainReducer.role
    }
}

export default connect(mapStateToProps,null)(ProfileInfo);