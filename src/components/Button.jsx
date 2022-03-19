

const Button = ({text='Button', fontsize='1em'}) => {
  return (
    <button className="button" style={{fontSize: fontsize }}> {text} </button>
  )
}

export default Button