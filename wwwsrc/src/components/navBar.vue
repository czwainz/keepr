<template>
  <div class="navBar container-fluid">
    <nav class="navbar row d-flex">
      <!-- Link to home -->
      <div class="col-10 d-flex justify-content-start pt-2">
        <router-link :to="{name: 'home'}">
          <h5><i class="far fa-lemon"></i>&nbsp;KEEPR</h5>
        </router-link>
      </div> <!-- Collapse Button -->
      <div class="col-2 d-flex justify-content-end">
        <button class="navbar-toggler toggler-example mr-3" type="button" data-toggle="collapse" data-target="#navbarSupportedContent1"
          aria-controls="navbarSupportedContent1" aria-expanded="false" aria-label="Toggle navigation">
          <span class="dark-blue-text"><i class="fas fa-bars fa-1x" style="color: var(--success)"></i></span>
        </button>
      </div>
      <!-- Collapsible content -->
      <div class="collapse navbar-collapse" id="navbarSupportedContent1">

        <!-- Links -->
        <ul class="navbar-nav mr-auto">
          <li class="nav-item-active">
            <a class="nav-link">
              <router-link :to="{name: 'home'}" data-toggle="collapse" data-target="#navbarSupportedContent1"
                aria-controls="navbarSupportedContent1" aria-expanded="false" aria-label="Toggle navigation">Home</router-link>
            </a>
          </li>
          <div v-if="isLoggedIn()">
            <li class=" nav-item-active">
              <a class="nav-link">
                <router-link :to="{name: 'dashboard'}" data-toggle="collapse" data-target="#navbarSupportedContent1"
                  aria-controls="navbarSupportedContent1" aria-expanded="false" aria-label="Toggle navigation">User
                  Dashboard</router-link>
              </a>
            </li>
            <li class=" nav-item-active">
              <a class="nav-link" @click="logoutUser">
                <router-link :to="{name: 'home'}" data-toggle="collapse" data-target="#navbarSupportedContent1"
                  aria-controls="navbarSupportedContent1" aria-expanded="false" aria-label="Toggle navigation">Logout</router-link>
              </a>
            </li>

          </div>
          <div v-else class="d-flex justify-content-center">
            <li class="d-flex">
              <a class="nav-link">
                <router-link :to="{name: 'login'}" data-toggle="collapse" data-target="#navbarSupportedContent1"
                  aria-controls="navbarSupportedContent1" aria-expanded="false" aria-label="Toggle navigation">Sign
                  In</router-link>
              </a>
            </li>
          </div>
          <!-- Search form -->
          <!-- <li class="pl-2 pr-2 pb-2">
            <form @submit.prevent="search">
              <input class="form-control text-center" type="text" placeholder="Search Keeps" aria-label="Search"
                v-model="searchWord">
            </form>
          </li> -->

        </ul>
      </div>
    </nav>
  </div>
</template>

<script>
  export default {
    name: 'navBar',
    data() {
      return {

      }
    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      isLoggedIn() {
        return (this.user.id) ? true : false
      },
      logoutUser() {
        this.$store.dispatch("logout")
      }
    }
  }
</script>

<style>
  .collapse {
    width: 10rem;
  }

  .navbar-toggler.toggler-example {
    cursor: pointer;
  }

  .navBar {
    background-color: rgba(245, 231, 37, 0.924);
  }

  /* .nav-item-active {
    width: 10rem;
    justify-content: flex-end;
  } */


  .nav-link {
    display: flex;
    justify-content: center;
    margin-right: 1rem;
  }
</style>