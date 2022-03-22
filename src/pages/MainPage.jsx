import Header from '.././components/Header';
import Button from '.././components/Button'
import Photo from '../resources/job-interview.png'
import Footer from "../components/Footer";
import {useState} from "react";


const MainPage = () => {
    const [tab, setTab] = useState(0);

    const onSwitch = (whichOne) => {
        setTab(whichOne);
    }

  return (
    <>
      <Header onSwitch={onSwitch}/>
      <main className='container'>
        <section className='first-section'>
          <img src="https://thispersondoesnotexist.com/image" alt="A human being" />
          <div>
            <h1>findjob works for you.</h1>
              { !tab ? <Button fontsize='24px' text='Create CV' /> : <input placeholder='Search' /> }
          </div>
        </section>
          <section className='second-section'>
              <div>
                <h1>sit amet purus gravida quis</h1>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
              </div>
              <img src={Photo} />
          </section>
          <Footer />
      </main>
    </>
  );
}

export default MainPage