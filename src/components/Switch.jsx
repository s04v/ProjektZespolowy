import {useState} from "react";
import style from '../styles/components/switch.module.scss'
import {connect} from "react-redux";
import { switchTab } from "../actions/MainActions";


const Switch = (props) => {
    const [active, setActive] = useState(0);

    const onClick = () => {
        props.switchTab();
    }

  const right = props.tab ? style.movableright : style.movable;
  return (
    <div className={[style.switch, props.className].join(" ")} onClick={() => onClick()}>
      <div className={right}></div>
      <div className={style.option}>Employee</div>
      <div className={style.option}>Employer</div>
    </div>
  )
}

const mapStateToProps = (state) => {
    return {
        tab: state.mainReducer.tab
    }
}
export default connect(mapStateToProps, { switchTab })(Switch);