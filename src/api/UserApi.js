import Api from './index'

const registerAccount = async (data) => {
    return await Api.post('/api/user/signup', data);
}

 const login = async (data) => {
    return await Api.post('/api/user/signin', data);
}

const getProfile = async () => {
    return await Api.get('/api/user/profile');
}

const helper = {
    registerAccount: registerAccount,
    login: login,
    getProfile: getProfile
}

export  { registerAccount, login };
export default helper;