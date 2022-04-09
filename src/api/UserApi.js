import Api from './index'

const registerAccount = async (data) => {
    return await Api.post('/api/user/signup', data);
}

 const login = async (data) => {
    return await Api.post('/api/user/signin', data);
}

const helper = {
    registerAccount: registerAccount,
    login: login
}

export  { registerAccount, login };
export default helper;