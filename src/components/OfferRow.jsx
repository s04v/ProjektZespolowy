import React, { useState } from 'react'
import PropTypes from 'prop-types'
import { RiDeleteBin6Line } from 'react-icons/ri'
import { MdOutlineKeyboardArrowDown, MdOutlineKeyboardArrowUp } from 'react-icons/md'
import style from '../styles/components/offerRow.module.scss'

const OfferRow = ({key}) => {
    const [expanded, setExpanded] = useState(false);
    const isHide = (!expanded) ? style.hidden : style.showed;

    const arrowClick = () => setExpanded(!expanded);

    const buttonArrow = () => {
            if (expanded) 
                return <MdOutlineKeyboardArrowUp size={20} onClick={arrowClick} />
            else
                return <MdOutlineKeyboardArrowDown size={20} onClick={arrowClick} />
    }

    return (
        <div className={style.offerRow}>
            <div className={style.info}>
                <div>
                    <p>Who:</p>
                    <input type="text" name={`who${key}`} id={`who${key}`} />
                </div>
                <div>
                    <p>Salary:</p>
                    <input type="text" name={`salary${key}`} id={`salary${key}`} />
                </div>
                <div>
                    <p>Experience:</p>
                    <input type="text" name={`experience${key}`} id={`experience${key}`} />
                </div>
                <div className={isHide}>
                    <p>Description:</p>
                    <input type="text" name={`desc${key}`} id={`desc${key}`} />
                </div>
            </div>
            {buttonArrow()}
            <RiDeleteBin6Line size={20} />
        </div>
    )
}

OfferRow.propTypes = {}

export default OfferRow