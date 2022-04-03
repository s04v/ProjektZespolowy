import React, {useState} from 'react'
import Button from './Button';

export const SignForm = ({title, fields, onSend, buttonTitle}) => {
    const [data, setData] = useState({});

    const onChange = (e) => {
        setData({...data, [e.target.name]:e.target.value});
    }

  return (
    <div className='form-section'>
      <h1>{title}</h1>
      {fields.map((item) =>
        <div key={item.id}>
          <p>{item.title}</p>
          <input type={item.type} name={item.name} onChange={onChange}/>
        </div>
      )}
      <Button onClick={() => onSend(data)} text={buttonTitle}/>
    </div>
  )
}

export default SignForm;