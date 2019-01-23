<template>
  <div class="userKeeps">
    <div class="row">
      <div class="col-12">
        <h4>User Keeps</h4>
      </div>
      <div class="col-3 card" v-for="keeps in userKeeps">
        <h6>{{keeps.name}}</h6>
        <p>{{keeps.description}}</p>
        <button class="btn btn-primary btn-sm" @click="deleteKeep(keeps.id)"><i class="fas fa-trash"></i></button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'userKeeps',
    mounted() {
      this.$store.dispatch("getUserKeeps")
    },
    data() {
      return {

      }
    },
    computed: {
      userKeeps() {
        return this.$store.state.userKeeps
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      }
    }
  }

</script>

<style>


</style>