<template>
  <div class="vaultById">
    <div class="row justify-content-around my-1">
      <div class="col-12 d-flex justify-content-start ml-5">
        <small>
          <router-link :to="{name: 'dashboard'}">User Dashboard</router-link>
        </small>
      </div>
      <div class="col-12">
        <h2>{{activeVault.name}}</h2>
      </div>
      <div class="col-6 col-lg-3 card mx-1 my-1 " v-for="keeps in activeVault.keeps">
        <img :src="keeps.img" class="card-img-top mt-2 shadow-sm rounded mb-0" height="200px" width="200px">
        <div class="card-img-overlay d-flex justify-content-end align-items-baseline" v-if="keeps.isPrivate">
          <i class="fas fa-asterisk" style="color: var(--warning); text-shadow: 0px 0px 1px gray"></i>
        </div>
        <div class="card-body">
          <h5>{{keeps.name}}</h5>
          <p>Views:{{keeps.views}}<br>
            Shares: {{keeps.shares}}<br>
            Keeps: {{keeps.keeps}}</p>
        </div>
        <div class="card-footer bg-transparent px-0 py-0 justify-content-end">
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