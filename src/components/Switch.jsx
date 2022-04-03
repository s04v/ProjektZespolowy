import {useState} from "react";
import style from '../styles/components/switch.module.scss'


const Switch = ({onSwitch=null, className=null}) => {
    const [active, setActive] = useState(0);

    const onClick = (whichOne) => {
        onSwitch(whichOne);
        setActive(whichOne);
    }

  const right = active ? style.movableright : style.movable;
  return (
    <div className={[style.switch, className].join(" ")} onClick={() => onClick(!active)}>
      <div className={right}></div>
      <div className={style.option}>Employee</div>
      <div className={style.option}>Employer</div>
    </div>
  )
}

export default Switch;