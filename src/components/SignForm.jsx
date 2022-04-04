import React, { useEffect, useState } from 'react'
import Button from './Button';

export const SignForm = ({title, fields, onSend, buttonTitle}) => {
  const [data, setData] = useState({});

  const onChange = (e) => {
      setData({...data, [e.target.name]:e.target.value});
  }

  useEffect(() => {
    const tempData = {};
    fields.forEach(element => {
      tempData[element.name] = '';
    });
    setData(tempData);
    return () => setData({});
  }, [JSON.stringify(fields)]);

  return (
    <div className='form-section'>
      <h1>{title}</h1>
      {fields.map((item) =>
        <div key={item.id}>
          <p>{item.title}</p>
          <input type={item.type} value={data[item.name]} name={item.name} onChange={onChange} autoComplete="off"/>
        </div>
      )}
      <Button onClick={() => onSend(data)} text={buttonTitle}/>
    </div>
  )
}

export default SignForm;