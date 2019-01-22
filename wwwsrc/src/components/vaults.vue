<template>
  <div class="vaults row justify-content-center">
    <div class="col-5 card mx-3" v-for="vault in vaults">
      <div class="card-body">
        <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">
          <h4>{{vault.name}}</h4>
        </router-link>
        <p>{{vault.description}}</p>
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
    methods: {}
  }

</script>

<style>


</style>