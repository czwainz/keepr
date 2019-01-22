<template>
  <div class="vaults">
    <div class="row">
      <div class="col-4" v-for="vault in vaults">
        {{vault.name}}
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaults',
    data() {
      return {

      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {}
  }

</script>

<style>


</style>