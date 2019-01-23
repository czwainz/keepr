<template>
  <div class="col-12 addKeep">
    <form @submit.prevent="createKeep">
      <div class="form-group px-5 py-1">
        <input type="name" class="form-control" v-model="newKeep.name" placeholder="Keep Name">
        <input type="description" class="form-control my-1" v-model="newKeep.description" placeholder="Keep Description">
        <input type="img" class="form-control my-1" v-model="newKeep.img" placeholder="Image URL">

        <div class="form-check form-check-inline">
          <label class="form-check-label" for="inlineCheckboxPrivate">Mark as Private &nbsp; </label>
          <input class="form-check-input" type="checkbox" id="inlineCheckboxPurivate" value="private" v-model="newKeep.isPrivate"
            true-value="1" false-value="0">
        </div>
        <br>
        <button type="submit" class="btn btn-outline-warning mt-1">Add New Keep</button>
      </div>
    </form>
  </div>
</template>

<script>
  export default {
    name: 'addKeep',
    data() {
      return {
        newKeep: {
          name: '',
          description: '',
          img: '',
          isPrivate: 0
        }
      }
    },
    computed: {},
    methods: {
      createKeep() {
        debugger
        this.$store.dispatch("createKeep", this.newKeep)
      }
    }
  }

</script>

<style>


</style>