import style from '../styles/components/button.module.scss';


const Button = ({text='Button', fontsize='1em', onClick=null, id=null}) => {
  return (
    <button 
      className={style.button}
      id={id} 
      style={{fontSize: fontsize }} 
      onClick={onClick}> 
        {text} 
    </button>
  )
}

export default Button