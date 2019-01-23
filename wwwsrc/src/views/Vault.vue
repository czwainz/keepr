<template>
  <div class="vaultById">
    <div class="row justify-content-around my-1">
      <div class="col-12 d-flex justify-content-start ml-5">
        <router-link :to="{name: 'dashboard'}">User Dashboard</router-link>
      </div>
      <div class="col-12">
        <h2>{{activeVault.name}}</h2>
      </div>
      <div class="col-3 card mx-1 my-1 " v-for="keeps in activeVault.keeps">
        <img :src="keeps.img" class="card-img-top pt-2 shadow rounded">
        <div class="card-body">
          <h4>{{keeps.name}}</h4>
          <p>Views:{{keeps.views}}<br>
            Shares: {{keeps.shares}}<br>
            Keeps: {{keeps.keeps}}</p>
        </div>
        <div class="card-footer bg-transparent">
          <button @click="deleteVaultKeep(activeVault.id, keeps.id)" class="btn btn-outline-warning btn-sm">Remove From
            Vault</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

  export default {
    name: 'Vault',
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch("activeVault", this.$route.params.vaultId)
    },
    computed: {
      activeVault() {
        return this.$store.state.activeVault
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      deleteVaultKeep(activeVaultId, keepId) {
        let payload = {
          vaultId: activeVaultId,
          keepId: keepId,
          userId: this.$store.state.user.id
        }
        this.$store.dispatch("deleteVaultKeep", payload)
      }
    },
    components: {
    }
  }

</script>

<style>


</style>