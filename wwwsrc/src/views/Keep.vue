<template>
  <div class="keep container-fluid">
    <div class="row justify-content-center">
      <div class="col-8 card text-center">
        <img :src="keep.img" class="card-img-top">
        <div class="card-body mx-2">
          <h3 class="mx-2 mb-3">{{keep.name}}</h3>
          <div class="circles d-inline shadow-sm">
            <i class="fas fa-eye"></i>
            {{keep.views+1}}
          </div>
          <div class="circles d-inline shadow-sm">
            <i class=" fas fa-share-square"></i>
            {{keep.shares}}
          </div>

          <div class="circles d-inline shadow-sm">
            <i class="far fa-lemon"></i>
            {{keep.keeps}}
          </div>
          <!-- 
          <div class="dropdown" v-show="user.id">
            <button class="btn btn-warning dropdown-toggle btn-circle btn-xl" type="button" id="dropdownMenuButton"
              data-toggle="dropdown">{{keep.keeps}}<i class="far fa-lemon"></i></button>
            <div class="dropdown-menu">
              <p class="dropdown-item" v-for="vault in vaults" @click="addVaultKeep(vault.id, keeps)">{{vault.name}}</p>
            </div>
          </div> -->

        </div>
      </div>
    </div>
  </div>

</template>

<script>


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
      // return this.$store.dispatch("getVaults")
    },
    data() {
      return {


      }
    },
    computed: {
      keep() {
        return this.$store.state.keep
      }
      // user() {
      //   return this.$store.state.user
      // }
    },
    methods: {
    },
    components: {

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
    padding: 1em;
    margin-left: 1em;
    background-color: var(--teal);
    color: var(--light);
    text-shadow: 0px 0px 1px gray;
  }
</style>