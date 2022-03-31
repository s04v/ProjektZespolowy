import style from '../styles/components/button.module.scss';


const Button = ({text='Button', fontsize='1em', onClick=null}) => {
  return (
    <button className={style.button} style={{fontSize: fontsize }} onClick={onClick}> {text} </button>
  )
}

export default Button