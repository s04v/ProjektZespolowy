import logo from '../resources/logo.svg'
import Button from './Button';
import Switch from './Switch';


const Header = () => {
  return (
    <header className="header">
        <img src={logo} height='38px' alt="findjob." className="logo" />
        <Switch />
        <div className='buttons'>
          <Button text="Register"/>
          <Button text="Sign in"/>
        </div>
    </header>
  );
}

export default Header