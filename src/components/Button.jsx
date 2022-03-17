

const Button = (props) => {
  return (
    <button className="button"> {props.text} </button>
  )
}

Button.defaultProps = {
  text:"Button",
}

export default Button