<template>
  <div class="col-12 addKeep">
    <div class="row my-2 " v-if="!isAddingKeep">
      <div class="col-12">
        <button class="btn btn-secondary" @click="isAddingKeep = true">Add New Keep</button>
      </div>
    </div>
    <div class="col-12" v-show="isAddingKeep">
      <form @submit.prevent="createKeep">
        <div class="form-group px-5 py-1">
          <input type="name" class="form-control" v-model="newKeep.name" placeholder="Keep Name">
          <input type="description" class="form-control my-1" v-model="newKeep.description" placeholder="Keep Description">
          <input type="img" class="form-control my-1" v-model="newKeep.img" placeholder="Image URL">
          <div class="form-check form-check-inline">
            <label class="form-check-label" for="inlineCheckboxPrivate">Private &nbsp; </label>
            <input class="form-check-input" type="checkbox" id="inlineCheckboxPrivate" value="private" v-model="newKeep.isPrivate"
              true-value="1" false-value="0">
          </div>
          <br>
          <button type="submit" @click="isAddingKeep = false" class="btn btn-outline-secondary mt-1">Add New Keep</button>
        </div>
      </form>
    </div>
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
        },
        isAddingKeep: false,
      }
    },
    computed: {},
    methods: {
      createKeep() {
        this.$store.dispatch("createKeep", this.newKeep)
      }
    }
  }

</script>

<style>


</style>