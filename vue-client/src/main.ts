import {createApp} from 'vue'
import {createPinia} from 'pinia'

import App from './App.vue'

import router from './router'

import Vuetify from "@/plugins/vuetify";

// Axios
import axios from 'axios'
import VueAxios from 'vue-axios'
// import axios from './plugins/axios'

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(Vuetify)
app.use(VueAxios, axios)
// app.use(axios, {
//     baseUrl: 'https://localhost:7058/',
// })

app.mount('#app')
