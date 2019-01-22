<template>
  <div class="keep container-fluid">
    <div class="row" v-if="!isEditingKeep">
      <div class="col-12">
        <button class="btn btn-primary" @click="isEditingKeep = true">Add New Keep</button>
      </div>
    </div>
    <div v-show="isEditingKeep">
      <addKeep v-on:addKeep="isEditingKeep = false"></addKeep>
    </div>
    <div class="row justify-content-center">
      <div class="col-8 card text-center">
        <img :src="keep.img" class="card-img-top">
        <div class="card-body mx-2">
          <h3 class="mx-2">{{keep.name}}</h3>
          <div class="circles d-inline"><i class="fas fa-eye"></i></div> {{keep.views}}
          <div class="circles d-inline"><i class=" fas fa-share-square"></i></div> {{keep.shares}}
          <div class="circles d-inline"><i class="far fa-lemon"></i></div> {{keep.keeps}}
        </div>
      </div>
    </div>
  </div>

</template>

<script>
  import addKeep from "@/components/addKeep.vue"

  export default {
    name: 'keep',
    mounted() {
      let keep = this.$store.state.publicKeeps.find(k => k.id == this.$route.params.keepId)
      if (keep) {
        keep.views++
        this.$store.dispatch("updateKeep", keep)
      }
    },
    created() {
      return this.$store.dispatch("getKeep", this.$route.params.keepId)
    },
    data() {
      return {
        activeKeep: {},
        isEditingKeep: false
      }
    },
    computed: {
      keep() {
        return this.$store.state.keep
      }
    },
    methods: {
    },
    components: {
      addKeep
    }
  }

</script>

<style scoped>
  .card-img-top {
    height: 300px;
    width: 300px;
  }
</style>

<style>
  .circles {
    border-radius: 50%;
    text-align: center;
    padding: 15px;
    width: 50px;
    height: 50px;
    background-color: aquamarine;
  }
</style>