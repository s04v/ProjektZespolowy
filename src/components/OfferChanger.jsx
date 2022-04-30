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
        CompanyApi.newOffer(data)
          .then((result) => {
            console.log(result);
            alert("result - " + result.data.data);
          })
          .catch((error) => {
          });
    }

    const opened = offerFields ? style.opened : "";

    const fields = [
        { id: '1', name: 'Title', title: 'Title', type: 'text' },
        { id: '2', name: 'Description', title: 'Decription', type: 'text' },
        { id: '3', name: 'Requirements', title: 'Requirements', type: 'text' },
        { id: '4', name: 'Responsibilities', title: 'Responsibilities', type: 'text' },
        { id: '5', name: 'Salary', title: 'Salary', type: 'text' },
    ]
    return (
        <div className={style.offerChanger} >
            <div className={[style.header, style.no_rows, opened].join(" ")}  >
                <h2>Job offers</h2>
                <AiOutlinePlus size={50} onClick={() => setOfferFields(!offerFields)}/>
            </div>
            <div className={!offerFields ? style.hidden : ""}>
                <SignForm
                    fields={fields}
                    onSend={onSend}
                    buttonTitle='Save' />
            </div>
            <OfferRow key={1} />
        </div>
    )
}

export default OfferChanger