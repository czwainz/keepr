<template>
    <div class="login">
        <form v-if="loginForm" @submit.prevent="loginUser" class="form-row justify-content-center">
            <input type="email" v-model="creds.email" placeholder="email" class="form-control mx-1">
            <input type="password" v-model="creds.password" placeholder="password" class="form-control">
            <button class="btn btn-sm btn-primary ml-1" type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register" class="form-row justify-content-center">
            <input type="text" v-model="newUser.username" placeholder="name" class="form-control mx-1">
            <input type="email" v-model="newUser.email" placeholder="email" class="form-control">
            <input type="password" v-model="newUser.password" placeholder="password" class="form-control mx-1">
            <button class="btn btn-sm btn-primary" type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">No account?<br><button class="btn btn-sm btn-outline-warning">Register</button></p>
            <p v-else>Already have an account? <br><button class="btn btn-sm btn-outline-warning">Login</button></p>
        </div>
    </div>
</template>

<script>
    export default {
        name: "login",
        mounted() {
            //checks for valid session

        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            },
            logoutUser() {
                this.$store.dispatch("logout")
            }
        }
    };
</script>
<style scoped>
    .form-control {
        width: 10rem;
    }
</style>