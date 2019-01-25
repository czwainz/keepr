<template>
  <div class="dashboard container-fluid">

    <vaults></vaults>

    <div class="row mb-3">
      <addVault></addVault>
    </div>

    <userKeeps></userKeeps>

    <div class="row">
      <addKeep></addKeep>
    </div>



  </div>
</template>

<script>
  import vaults from "@/components/vaults.vue"
  import addKeep from "@/components/addKeep.vue"
  import addVault from "@/components/addVault.vue"
  import userKeeps from "@/components/userKeeps.vue"

  export default {
    name: 'Dashboard',
    // mounted() {},
    data() {
      return {
      }
    },
    computed: {

    },
    methods: {},
    components: {
      vaults,
      addKeep,
      addVault,
      userKeeps
    }
  }

</script>

<style>


</style>