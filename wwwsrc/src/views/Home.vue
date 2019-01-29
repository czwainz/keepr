<template>
  <div class="home">

    <div class="container-fluid">
      <div class="row">
        <div class="col-12 headline">
          <i class="far fa-lemon fa-2x headline1"></i>
          <i class="far fa-lemon fa-2x headline2"></i>
          <h1>KEEPR</h1>
          <i class="far fa-lemon fa-2x headline2"></i>
          <i class="far fa-lemon fa-2x  headline1"></i>
        </div>
      </div>
      <div class="row justify-content-around">
        <div class="card-columns justify-content-center">
          <div class="col-8 card border-success bg-lightGreen shadow-sm pt-1" v-for="keeps in publicKeeps">
            <router-link :to="{name: 'keep', params: {keepId: keeps.id}}">
              <img class="card-img-top rounded" :src="keeps.img" height="200px" width="200px">
            </router-link>
            <div class="card-body px-0 py-0 pt-1">
              <p>
                <button class="btn btn-primary btn-circle shadow">
                  <router-link :to="{name: 'keep', params: {keepId: keeps.id}}" style="color:aliceblue;"><i class="fas fa-eye"></i></router-link>
                </button>
                {{keeps.views}}
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
              <h5 class="mx-0">{{keeps.name}}</h5>
            </div>
          </div>
        </div>
      </div>
      <div class="row footer">
        <div class="col-12">
          <h6 style="color: var(--success);">A refreshing take on social media.</h6>
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

  .headline {
    margin-top: .5em;
    color: var(--info);
    /* text-shadow: 1px 1px 2px gray; */
  }

  .headline2 {
    color: var(--warning);
    transform: rotate(-90deg);
  }

  .headline1 {
    color: var(--success);
  }

  .bg-lightGreen {
    background-color: rgba(34, 178, 77, 0.132);
  }

  h1 {
    font-family: 'Chango', cursive;
    background: -webkit-linear-gradient(#22B24C, #22B24C, #F5E625, #F5E625);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
  }
</style>