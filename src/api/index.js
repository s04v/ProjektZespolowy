import axios from "axios";

const Api = axios.create({
    baseURL: 'https://pz-api-findjob.herokuapp.com:80/',
    withCredentials: true
});

export default Api;