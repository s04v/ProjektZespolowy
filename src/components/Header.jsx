import logo from '../resources/logo.svg'
import Button from './Button';
import Switch from './Switch';
import {Link} from "react-router-dom";
import style from '../styles/components/header.module.scss'


const Header = (props) => {
  return (
    <header className={style.header}>
      <div className={style.container}>
        <Link to='/'><img src={logo} height='38px' alt="findjob." className={style.logo}  id="logo"/></Link> 
        <Switch onSwitch={props.onSwitch} on={true}/>
          <div className={style.buttons}>
            <Link to='/signup'><Button text="Register"/></Link>
            <Link to='/signin'><Button text="Sign in"/></Link>
          </div>
      </div>
    </header>
  );
}

export default Header