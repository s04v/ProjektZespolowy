import logo from '../resources/logo.svg'
import Button from './Button';
import Switch from './Switch';
import {Link} from "react-router-dom";


const Header = (props) => {
  return (
    <header className="header">
      <div className='container'>
        <img src={logo} height='38px' alt="findjob." className="logo" />
        <Switch onSwitch={props.onSwitch} on={true}/>
          <div className='buttons'>
            <Link to='/signup'><Button text="Register"/></Link>
            <Link to='/signin'><Button text="Sign in"/></Link>
          </div>
      </div>
    </header>
  );
}

export default Header