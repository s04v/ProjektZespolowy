import style from '../styles/components/footer.module.scss'

const Footer = () => {
    return (
        <div className={style.footer}>
            <div className={style.footer_employee}>
                <h1>Employee</h1>
                <ul>
                    <li>Help</li>
                    <li>CV creator</li>
                    <li>Job Centers</li>
                </ul>
            </div>
            <div className={style.footer_employer}>
                <h1>Employer</h1>
                <ul>
                    <li>Search Resume</li>
                    <li>Employer Account</li>
                    <li>Help for companies</li>
                </ul>
            </div>
            <div className={style.footer_other}>
                <h1>Other menu</h1>
                <ul>
                    <li>Terms and Conditions</li>
                    <li>Privacy Policy</li>
                    <li>Cookies policy</li>
                    <li>Cookies settings</li>
                </ul>
            </div>
        </div>
    )
}

export default Footer;
