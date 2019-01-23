<template>
  <div class="userKeeps row justify-content-center">
    <div class="col-12">
      <h4>User Keeps</h4>
    </div>
    <div class="col-3 card mx-2 px-0 " v-for="keeps in userKeeps">
      <div class="card-body">
        <h6>{{keeps.name}}</h6>
        <p>{{keeps.description}}</p>
      </div>
      <div class="card-footer bg-transparent">
        <button class="btn btn-outline-danger btn-sm btn-circle" @click="deleteKeep(keeps.id)"><i class="fas fa-trash"></i></button>
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