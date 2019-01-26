<template>
  <div class="vaults row justify-content-center">
    <div class="col-12 pt-3">
      <h4 class="dashboardHeadline">VAULTS</h4>
    </div>
    <div class="col-5 px-0 card mx-3 my-3 bg-lightYellow border-primary" v-for="vault in vaults">
      <div class="card-body px-0 py-0">
        <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">
          <h5 class="pt-1">{{vault.name}}</h5>
        </router-link>
        <p class="mb-1">{{vault.description}}</p>
      </div>
      <div class="bg-transparent d-flex justify-content-start align-items-baseline pb-1 pl-2">
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

<style>
  h4.dashboardHeadline {
    font-family: 'Chango', cursive;
  }

  .bg-lightYellow {
    background-color: rgba(235, 105, 100, 0.372);
  }
</style>