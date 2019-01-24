<template>
  <div class="col-12 addVault">
    <div class="row" v-if="!isAddingVault">
      <div class="col-12">
        <button class="btn btn-secondary" @click="isAddingVault = true">Add New Vault</button>
      </div>
    </div>

    <div class="row">
      <div class="col-12" v-show="isAddingVault">
        <form @submit.prevent="createVault">
          <div class="col-12 form-group">
            <input type="name" class="form-control" v-model="newVault.name" placeholder="Vault Name">
            <input type="description" class="form-control my-1" v-model="newVault.description" placeholder="Vault Description">
            <button type="submit" @click="isAddingVault = false" class="btn btn-outline-secondary">Add Vault</button>
          </div>
        </form>
      </div>
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
        },
        isAddingVault: false

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