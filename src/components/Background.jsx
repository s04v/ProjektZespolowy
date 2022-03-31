import style from '../styles/components/background.module.scss';

const Background = (props) => {
    return (
        <div style={style} className={style.background}>
            <div  className={style.first_section}></div>
            <div className={style.seperator}>
                <svg viewBox='0 0 300 300' preserveAspectRatio="none">
                    <path d='M 300 100 Q 300 0 300 0 L 0 0 L 0 300 L 300 100 ' />
                </svg>
            </div>
            <div className={style.second_section}></div>
        </div>
    )
}

export default Background;