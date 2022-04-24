import axios from "axios";

const Api = axios.create({
    baseURL: 'https://localhost:7253/',
    timeout: 1000,
    withCredentials: true,
});

Api.defaults.headers.common['Access-Control-Allow-Origin'] = '*';

export default Api;