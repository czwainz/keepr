<template>
  <div class="userKeeps row justify-content-center">
    <div class="col-12">
      <h4>User Keeps</h4>
    </div>
    <div class="col-3 card mx-2 px-0 " v-for="keeps in userKeeps">
      <img :src="keeps.img" class="card-img-top shadow rounded" height="200px" width="200px">
      <div class="card-img-overlay d-flex justify-content-end align-items-baseline" v-if="keeps.isPrivate">
        <i class="fas fa-asterisk" style="color: var(--light); text-shadow: 0px 0px 1px gray"></i>
      </div>
      <div class="card-body align-content-center">
        <h6>{{keeps.name}}</h6>
        <p>{{keeps.description}}</p>
      </div>

      <div class="dropdown mb-2 mt-0" v-show="user.id">
        <button class="btn btn-warning dropdown-toggle btn-circle btn-xl shadow-lg" type="button" id="dropdownMenuButton"
          data-toggle="dropdown"><i class="far fa-lemon"></i></button>
        <div class="dropdown-menu">
          <p class="dropdown-item" v-for="vault in vaults" @click="addVaultKeep(vault.id, keeps)">{{vault.name}}</p>
        </div>
      </div>

      <div class="card-footer bg-transparent">
        <button class="btn btn-outline-danger btn-sm btn-circle" @click="deleteKeep(keeps.id)"><i class="fas fa-trash"></i></button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'userKeeps',
    mounted() {
      this.$store.dispatch("getUserKeeps")
    },
    data() {
      return {

      }
    },
    computed: {
      userKeeps() {
        return this.$store.state.userKeeps
      },
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      },
      addVaultKeep(vaultId, keep) {
        let vaultKeep = {
          vaultId: vaultId,
          keepId: keep.id,
          userId: this.user.id
        }
        keep.keeps++
        this.$store.dispatch("updateKeep", keep)
        this.$store.dispatch("addVaultKeep", vaultKeep)
      }
    }
  }

</script>

<style>


</style>