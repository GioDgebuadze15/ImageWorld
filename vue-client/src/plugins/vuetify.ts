import 'vuetify/styles'
import {createVuetify} from 'vuetify'
import type {ThemeDefinition} from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import '@mdi/font/css/materialdesignicons.css'

const myCustomDarkTheme: ThemeDefinition = {
    dark: false,
    colors: {
        background: '#1A202C',
        surface: '#1A202C',
        primary: '#6200EE',
        'primary-darken-1': '#3700B3',
        secondary: '#03DAC6',
        'secondary-darken-1': '#018786',
        error: '#B00020',
        info: '#2196F3',
        success: '#4CAF50',
        warning: '#FB8C00',
        'image-card-item': '#272f40'
    }
}

const Vuetify =  createVuetify({
    components,
    directives,
    theme: {
        defaultTheme: 'myCustomDarkTheme',
        themes: {
            myCustomDarkTheme,
        },
    }
})

export default Vuetify