import React from 'react'
import Button from './Button';

export const SignForm = ({title, fields, onSend, buttonTitle}) => {

  return (
    <div className='form-section'>
      <h1>{title}</h1>
      {fields.map((item) =>
        <div key={item.id}>
          <p>{item.title}</p>
          <input type={item.type} />
        </div>
      )}
      <Button onClick={onSend} text={buttonTitle}/>
    </div>
  )
}

export default SignForm;