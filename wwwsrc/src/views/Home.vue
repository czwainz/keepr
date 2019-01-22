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
            <img class="card-img-top" :src="keeps.img">
            <div class="card-body">
              <h4>{{keeps.name}}</h4>
              <p><i class="fas fa-eye"></i>&nbsp;{{keeps.views}}&nbsp;
                <i class="fas fa-share-square"></i>&nbsp;{{keeps.shares}}&nbsp;
                <i class="far fa-lemon"></i>&nbsp;{{keeps.keeps}}</p>
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
    }
  };
</script>