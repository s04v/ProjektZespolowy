import style from '../styles/components/offerChanger.module.scss';
import { AiOutlinePlus } from "react-icons/ai";
import React, { useEffect, useState } from 'react'
import SignForm from './SignForm';
import CompanyApi from "../api/CompanyApi";
import OfferRow from './OfferRow';

const OfferChanger = () => {

    const [offerFields, setOfferFields] = useState(false);

    const onSend = (data) => {
        console.log(data);
        /*
        CompanyApi.newOffer(data)
          .then((result) => {
            console.log(result);
            alert("result - " + result.data.data);
          })
          .catch((error) => {
          });
          */
    }

    const opened = !offerFields ? style.opened : "";

    const fields = [
        { id: '1', name: 'who', title: 'Who', type: 'text' },
        { id: '2', name: 'experience', title: 'Experience', type: 'text' },
        { id: '3', name: 'salary', title: 'Salary', type: 'text' },
        { id: '4', name: 'desc', title: 'Decription', type: 'text' },
    ]
    return (
        <div className={style.offerChanger} >
            <div className={[style.header, opened].join(" ")}  >
                <h2>Job offers</h2>
                <AiOutlinePlus size={50} onClick={() => setOfferFields(!offerFields)}/>
            </div>
            <div className={offerFields ? style.hidden : ""}>
                <SignForm
                    fields={fields}
                    onSend={onSend}
                    buttonTitle='Save' />
            </div>
            <OfferRow />
        </div>
    )
}

export default OfferChanger