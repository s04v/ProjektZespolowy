import logo from '../resources/logo.svg'
import Button from './Button';
import Switch from './Switch';

const Header = () => {
  return (
    <header className="Header">
        <img src={logo} alt="findjob." className="logo" />
        <Switch />
        <Button text="Register"/>
        <Button text="Sign in"/>
    </header>
  );
}

export default Header