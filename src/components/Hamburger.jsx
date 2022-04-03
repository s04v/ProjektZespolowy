import React from 'react'
import style from '../styles/components/hamburger.module.scss'


const Hamburger = ({onClick=null, className=null}) => {
  return (
    <label htmlFor="check" onChange={onClick} className={className}>
      <input type="checkbox" id="check" />
      <span></span>
      <span></span>
      <span></span>
    </label>
  )
}

Hamburger.propTypes = {}

export default Hamburger