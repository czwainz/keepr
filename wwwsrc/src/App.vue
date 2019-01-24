<template>
  <div id="app">
    <navBar></navBar>
    <router-view />
  </div>
</template>

<script>
  import navBar from "@/components/navBar.vue"

  export default {
    name: 'app',
    components: {
      navBar
    },
    mounted() {
      this.$store.dispatch("authenticate");
      this.$store.dispatch("getPublicKeeps")
    }
  }
</script>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;

  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  a {
    text-decoration: none;
    color: var(--success);
  }

  a:hover {
    text-decoration: none;
    color: var(--info)
      /* cursor: none; */
  }
</style>