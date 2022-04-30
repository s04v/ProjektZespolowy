import Api from './index';

const registerAccount = async (data) => {
    return await Api.post('/api/company/signup', data);
}

const login = async (data) => {
    return await Api.post('/api/company/signin', data);
}

const newOffer = async (data) => {
    return await Api.post('/api/job/add', data);
}

const getProfile = async () => {
    return await Api.get('/api/company/profile');
}

const getProfileData = async (id) => {
    return await Api.get(`/api/company/${id}/job`);
}
const helper = {
    registerAccount: registerAccount,
    login: login,
    getProfile: getProfile,
    getProfileData: getProfileData,
    newOffer: newOffer,
}

export {
    registerAccount,
    login
}

export default helper;