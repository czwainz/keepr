<template>
  <div class="navBar container-fluid">
    <navBar class="navbar navbar-light light-blue lighten-4 row d-flex">
      <div class="col-10 d-flex justify-content-start">
        <router-link :to="{name: 'home'}"><i class="far fa-lemon"></i></router-link>
      </div>
    </navBar>
  </div>
</template>

<script>
  export default {
    name: 'navBar',
    data() {
      return {

      }
    },
    computed: {},
    methods: {}
  }

</script>

<style>


</style>