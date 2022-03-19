import Header from '.././components/Header';
import Button from '.././components/Button'

const MainPage = () => {
  return (
    <>
      <Header />
      <main className='container'>
        <section className='first-section'>
          <img src="https://thispersondoesnotexist.com/image" alt="A human being" />
          <div>
            <h1>findjob works for you.</h1>
            <Button fontsize='24px' text='Create CV' />
          </div>
        </section>
      </main>
    </>
  );
}

export default MainPage