<template>
  <div class="vaults row justify-content-center">
    <div class="col-12">
      <h4 class="dashboardHeadline">User Vaults</h4>
    </div>
    <div class="col-5 px-0 card mx-3 my-3" v-for="vault in vaults">
      <div class="card-body">
        <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">
          <h4>{{vault.name}}</h4>
        </router-link>
        <p>{{vault.description}}</p>
      </div>
      <div class="card-footer bg-transparent justify-content-center">
        <button @click="deleteVault(vault.id)" class="btn btn-danger btn-circle"><i class="fas fa-trash"></i></button>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'vaults',
    mounted() {
      this.$store.dispatch("getVaults")
    },
    data() {
      return {

      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteVault(id) {
        this.$store.dispatch("deleteVault", id)
      }
    }
  }

</script>

<style scoped>
  h4.dashboardHeadline {
    font-family: 'Chango', cursive;
  }
</style>