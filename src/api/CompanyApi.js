import Api from './index';

const registerAccount = async (data) => {
    return await Api.post('/api/company/signup', data);
}

const login = async (data) => {
    return await Api.post('/api/company/signin', data);
}

const newOffer = async (data) => {
    return await Api.post('/api/company/{id}/job', data);
}

const getProfile = async () => {
    return await Api.get('/api/company/profile');
}
const helper = {
    registerAccount: registerAccount,
    login: login,
    getProfile: getProfile
}

export {
    registerAccount,
    login
}

export default helper;