import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
//@ts-ignore
import MyVaults from './views/MyVaults.vue'
//@ts-ignore
import Keeps from './views/Keep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/vaults',
      name: 'myVaults',
      component: MyVaults
    },
    {
      path: '/keeps/:keepId',
      name: 'keep',
      component: Keeps
    }
  ]
})
