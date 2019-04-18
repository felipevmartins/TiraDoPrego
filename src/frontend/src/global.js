import Vue from 'vue'

export const usuarioKey = '__knowledge_user'
export const baseApiUrl = 'http://35.247.236.48:5100'

export function showError(e) {
    if(e && e.response && e.response.data) {
        Vue.toasted.global.defaultError({ msg : e.response.data })
    } else if(typeof e === 'string') {
        Vue.toasted.global.defaultError({ msg : e })
    } else {
        Vue.toasted.global.defaultError()
    }
}

export function showPasswordError(e) {
    Vue.toasted.global.passwordError()
}

export default { baseApiUrl, showError, showPasswordError, usuarioKey }