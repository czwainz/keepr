<template>
  <div class="addKeep">
    <div class="row">
      <div class="col-12">
        <form @submit.prevent="createKeep">
          <div class="form-group px-5 py-1">
            <input type="name" class="form-control" v-model="newKeep.name" placeholder="Keep Name">
            <input type="description" class="form-control my-1" v-model="newKeep.description" placeholder="Keep Description">
            <input type="img" class="form-control my-1" v-model="newKeep.img" placeholder="Image URL">


            <!-- <input type="radio" value="private" v-model="pubpri" id="private"></input>
            <label for="private">&nbsp; Private&emsp;</label>

            <input type="radio" value="public" v-model="pubpri" id="public"></input>
            <label for="public">&nbsp;Public </label><br> -->

            <button type="submit" class="btn btn-warning mt-1">Add Keep</button>
          </div>
        </form>
      </div>
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