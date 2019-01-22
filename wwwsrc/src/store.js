import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    publicKeeps: [],
    keep: {},
    vaults: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    getKeeps(state, keeps) {
      state.publicKeeps = keeps
    },
    setKeep(state, keep) {
      state.keep = keep
    },
    getVaults(state, vaults) {
      state.vaults = vaults
    }
  },
  actions: {
    //AUTH
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'home' })
        })
    },
    //KEEPS
    getPublicKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          console.log(res.data)
          commit('getKeeps', res.data)
        })
    },
    updateKeep({ commit, dispatch }, payload) {
      api.put('keeps/' + payload.id, payload)
        .then(res => {
          // console.log(res.data)
          commit("getKeeps", res.data)
        })
    },
    getKeep({ commit, dispatch }, keep) {
      api.get('keeps/' + keep)
        .then(res => {
          console.log(res.data)
          commit("setKeep", res.data)
        })
    },
    createKeep({ commit, dispatch }, newKeep) {
      debugger
      api.post('keeps/', newKeep)
        .then(res => {
          debugger
          console.log(res.data)
          commit("getKeeps")
        })
    },
    //VAULTS
    getVaults({ commit, dispatch }, ) {
      api.get('vaults/')
      debugger
    }

  }
})