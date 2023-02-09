import axios from 'axios';

interface AxiosOptions {
    baseURL?: string;
}

const defaultOptions: AxiosOptions = {
    baseURL: 'https://localhost:7058',
};

const $axios = axios.create(defaultOptions);

export default $axios;