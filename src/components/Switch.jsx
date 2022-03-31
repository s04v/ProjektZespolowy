import {useState} from "react";
import style from '../styles/components/switch.module.scss'


const Switch = (props) => {
    const [active, setActive] = useState(0);

    const onClick = (whichOne) => {
        props.onSwitch(whichOne);
        setActive(whichOne);
    }

  const right = active ? style.movableright : style.movable;
  return (
    <div className={style.switch} onClick={() => onClick(!active)}>
      <div className={right}></div>
      <div className={style.option}>Employee</div>
      <div className={style.option}>Employer</div>
    </div>
  )
}

Switch.defaultProps = {
  on: false
}

export default Switch;