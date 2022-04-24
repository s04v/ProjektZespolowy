import axios from "axios";

const Api = axios.create({
    baseURL: 'https://pz-api-findjob.herokuapp.com/',
    timeout: 1000,
    withCredentials: true,
});

Api.defaults.headers.common['Access-Control-Allow-Origin'] = '*';

export default Api;