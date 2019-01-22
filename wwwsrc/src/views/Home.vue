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
            <router-link @click.native="addView({keepId: keeps.id})" :to="{name: 'keep', params: {keepId: keeps.id}}">
              <img class="card-img-top" :src="keeps.img">
            </router-link>
            <div class="card-body">
              <p><button @click="addView({keepId: keeps.id})" class="btn btn-primary btn-circle"><i class="fas fa-eye"></i>
                </button>
                {{keeps.views}}
                <button class="btn btn-info btn-circle"><i class="fas fa-share-square"></i></button> {{keeps.shares}}
                <button class="btn btn-warning btn-circle"><i class="far fa-lemon"></i></button> {{keeps.keeps}}</p>
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
      //blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
      this.$store.dispatch("getPublicKeeps")
    },
    computed: {
      publicKeeps() {
        return this.$store.state.publicKeeps
      }
    },
    methods: {
      addView(keepId) {
        let payload = {
          id: keepId,
          views: this.publicKeeps.forEach(k => {
            debugger
            k.views += 1
          })
        }
        debugger
        this.$store.dispatch("addView", payload)
      }
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
</style>