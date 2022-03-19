

const Switch = (props) => {
  return (
    <div className="switch">
      <div className="movable"></div>
      <div className={"option" + (!props.on ? " checked" : "")}>Employee</div>
      <div className={"option" + (props.on ? " checked" : "")}>Employer</div>
    </div>
  )
}

Switch.defaultProps = {
  on: false
}

export default Switch;