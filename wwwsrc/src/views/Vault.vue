<template>
  <div class="vaultById">
    <div class="row justify-content-around my-1">
      <div class="col-12">
        <h2>{{activeVault.name}}</h2>
      </div>
      <div class="col-3 card mx-1 my-1" v-for="keeps in activeVault.keeps">
        <img :src="keeps.img" class="card-img-top pt-2">
        <div class="card-body">
          <h4>{{keeps.name}}</h4>
          <p>Views:{{keeps.views}}<br>
            Shares: {{keeps.shares}}<br>
            Keeps: {{keeps.keeps}}</p>
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
      }
    },
    methods: {},
    components: {
    }
  }

</script>

<style>


</style>