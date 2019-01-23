<template>
  <div class="home">

    <div class="container-fluid">
      <div class="row">
        <!-- <div class="col-2">
          <button class=" btn btn-outline-danger" @click="logoutUser">Log Out</button>
        </div> -->
        <div class="col-12">
          <h2>Welcome Home</h2>
        </div>
        <div class="row justify-content-center">
          <div class="col-3 card mx-1 my-1 pt-1" v-for="keeps in publicKeeps">
            <router-link :to="{name: 'keep', params: {keepId: keeps.id}}">
              <img class="card-img-top shadow rounded" :src="keeps.img" height="200px" width="200px">
            </router-link>
            <div class="card-body">
              <p>
                <button class="btn btn-primary btn-circle shadow">
                  <router-link :to="{name: 'keep', params: {keepId: keeps.id}}" style="color:aliceblue;"><i class="fas fa-eye"></i></router-link>
                </button> {{keeps.views}}
                <button class="btn btn-info btn-circle shadow"><i class="fas fa-share-square"></i></button>
                {{keeps.shares}}
                <br>
                {{keeps.keeps}} Keeps
                <div class="dropdown" v-show="user.id">
                  <button class="btn btn-warning dropdown-toggle btn-circle btn-xl shadow-lg" type="button" id="dropdownMenuButton"
                    data-toggle="dropdown"><i class="far fa-lemon"></i></button>
                  <div class="dropdown-menu">
                    <p class="dropdown-item" v-for="vault in vaults" @click="addVaultKeep(vault.id, keeps)">{{vault.name}}</p>
                  </div>
                </div>
              </p>
              <h4>{{keeps.name}}</h4>
            </div>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getVaults")
    },
    data() {
      return {

      }
    },
    computed: {
      publicKeeps() {
        return this.$store.state.publicKeeps
      },
      vaults() {
        return this.$store.state.vaults
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      addVaultKeep(vaultId, keep) {
        let vaultKeep = {
          vaultId: vaultId,
          keepId: keep.id,
          userId: this.user.id
        }
        keep.keeps++
        this.$store.dispatch("updateKeep", keep)
        this.$store.dispatch("addVaultKeep", vaultKeep)
        // this.$store.dispatch("getVaults")
      },


    }
  };
</script>

<style>
  .btn-circle {
    width: 30px;
    height: 30px;
    padding: 6px 0px;
    border-radius: 15px;
    text-align: center;
    font-size: 12px;
    line-height: 1.42857;
  }

  .btn-circle.btn-xl {
    width: 70px;
    height: 70px;
    padding: 10px 16px;
    border-radius: 35px;
    font-size: 24px;
    line-height: 1.33;
  }
</style>