<template>
  <div class="dashboard container-fluid">
    <div class="row my-2" v-if="!isEditingKeep">
      <div class="col-12">
        <button class="btn btn-primary" @click="isEditingKeep = true">Add New Keep</button>
      </div>
    </div>
    <div class="col-12" v-show="isEditingKeep">
      <addKeep v-on:addKeep="isEditingKeep = false"></addKeep>
    </div>

    <div class="row" v-if="!isAddingVault">
      <div class="col-12">
        <button class="btn btn-secondary" @click="isAddingVault = true">Add New Vault</button>
      </div>
    </div>
    <div class="col-12" v-show="isAddingVault">
      <addVault v-on:addVault="isAddingVault = false"></addVault>
    </div>

    <div class="col-12">
      <vaults></vaults>
    </div>

    <div class="col-12">
      <userKeeps></userKeeps>
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
        isEditingKeep: false,
        isAddingVault: false,
      }
    },
    computed: {

    },
    methods: {},
    components: {
      addKeep,
      vaults,
      addVault,
      userKeeps
    }
  }

</script>

<style>


</style>