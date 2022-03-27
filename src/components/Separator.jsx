import style from '../styles/components/separator.scss'

const Separator = ({ }) => {
    return (
        <div style={style} className='seperator'>
            <svg viewBox='0 0 300 300' preserveAspectRatio="none">
                <path d='M 300 100 Q 300 0 300 0 L 0 0 L 0 300 L 300 100 ' />
            </svg>
        </div>
    )
}

export default Separator;
