<template>
  <div class="vaultById">
    {{activeVault}}
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
      }
    },
    methods: {},
    components: {
    }
  }

</script>

<style>


</style>