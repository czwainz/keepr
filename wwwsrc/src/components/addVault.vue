<template>
  <div class="addVault">
    <div class="col-12">
      <form @submit.prevent="createVault">
        <div class="col-12 form-group">
          <input type="name" class="form-control" v-model="newVault.name" placeholder="Vault Name">
          <input type="description" class="form-control my-1" v-model="newVault.description" placeholder="Vault Description">
          <button type="submit" class="btn btn-primary">Add Vault</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'addVault',
    data() {
      return {
        newVault: {
          name: '',
          description: ''
        }

      }
    },
    computed: {},
    methods: {
      createVault() {
        this.$store.dispatch("createVault", this.newVault)
      }
    }
  }

</script>

<style>


</style>