import {useState} from "react";


const Switch = (props) => {
    const [active, setActive] = useState(0);

    const onClick = (whichOne) => {
        props.onSwitch(whichOne);
        setActive(whichOne);
    }

  return (
    <div className="switch" onClick={() => onClick(!active)}>
      <div className={"movable" + (active ? "right" : "")}></div>
      <div className="option">Employee</div>
      <div className="option">Employer</div>
    </div>
  )
}

Switch.defaultProps = {
  on: false
}

export default Switch;