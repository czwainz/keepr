<template>
  <div class="dashboard container-fluid">

    <div class="row">
      <addKeep></addKeep>
    </div>

    <div class="row">
      <addVault></addVault>
    </div>

    <vaults></vaults>

    <userKeeps></userKeeps>



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