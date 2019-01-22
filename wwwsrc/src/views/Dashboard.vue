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
    <div class="col-12">
      <vaults></vaults>
    </div>
  </div>
</template>

<script>
  import vaults from "@/components/vaults.vue"
  import addKeep from "@/components/addKeep.vue"

  export default {
    name: 'Dashboard',
    // mounted() {},
    data() {
      return {
        isEditingKeep: false
      }
    },
    computed: {

    },
    methods: {},
    components: {
      addKeep,
      vaults
    }
  }

</script>

<style>


</style>