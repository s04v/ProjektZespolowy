import Separator from "./Separator";
import Footer from "./Footer";

const Background = (props) => {
    return (
        <>
        {props.children}
        <div className='background'>
            <div className='first-section'></div>
            <Separator />
            <div className='second-section'></div>
        </div>
        </>
    )
}

export default Background;