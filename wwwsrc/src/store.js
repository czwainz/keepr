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
    vaults: [],
    activeVault: {},
    userKeeps: []
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
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setActiveVault(state, vault) {
      state.activeVault = vault
    },
    getUserKeeps(state, keeps) {
      state.userKeeps = keeps
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
    getUserKeeps({ commit, dispatch }) {
      api.get('keeps/user')
        .then(res => {
          console.log(res.data)
          commit("getUserKeeps", res.data)
        })
    },
    updateKeep({ commit, dispatch }, payload) {
      api.put('keeps/' + payload.id, payload)
        .then(res => {
          dispatch("getPublicKeeps")
        })
    },
    //Get Single Keep
    getKeep({ commit, dispatch }, keep) {
      api.get('keeps/' + keep)
        .then(res => {
          console.log(res.data)
          commit("setKeep", res.data)
        })
    },
    createKeep({ commit, dispatch }, newKeep) {
      api.post('keeps/', newKeep)
        .then(res => {
          console.log(res.data)
          dispatch("getUserKeeps", res.data)
          router.push({ name: 'dashboard' })
        })
    },
    deleteKeep({ commit, dispatch }, id) {
      api.delete('keeps/' + id)
        .then(res => {
          dispatch("getUserKeeps")
        })
    },
    //VAULTS
    //gets a users vaults
    getVaults({ commit, dispatch }) {
      api.get('vaults/')
        .then(res => {
          commit("setVaults", res.data)
        })
    },
    createVault({ commit, dispatch }, vault) {
      api.post('vaults/', vault)
        .then(res => {

          dispatch("getVaults")
        })
    },
    deleteVault({ commit, dispatch }, id) {
      api.delete('vaults/' + id)
        .then(res => {

          dispatch("getVaults")
        })
    },
    //VAULTKEEPS
    activeVault({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId)
        .then(res => {
          let vault = res.data
          api.get('vaultkeeps/' + vaultId)
            .then(res => {
              console.log(res.data)
              vault.keeps = res.data
              commit("setActiveVault", vault)
              console.log(res.data)
            })
        })
    },
    addVaultKeep({ commit, dispatch }, payload) {
      api.post('vaultkeeps/', payload.vaultKeep)
        .then(res => {

          commit("setVaults", res.data)
        })
    },
    deleteVaultKeep({ commit, dispatch }, payload) {
      api.delete('vaultkeeps/' + payload.vaultId + '/' + payload.keepId)
        .then(res => {
          dispatch("activeVault", payload.vaultId)
        })
    }
  }
})