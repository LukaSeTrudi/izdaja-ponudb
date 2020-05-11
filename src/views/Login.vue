<template>
    <div id="login">
        <h1>Login</h1>
        <form id="loginForm">
        <b-input type="text" name="username" v-model="input.username" placeholder="Username" ></b-input><br>
        <b-input type="password" name="password" v-model="input.password" placeholder="Password" ></b-input><br>
        </form>
        <b-button type="button" v-on:click="login()">Login</b-button>
    </div>
</template>

<script>
    export default {
        name: 'Login',
        data() {
            return {
                input: {
                    username: "",
                    password: ""
                }
            }
        },
        methods: {
            login() {
                if(this.input.username != "" && this.input.password != "") {
                    fetch("https://izdaja-ponudb.herokuapp.com/login.php", {
                    method: 'POST',
                    body: new FormData(document.getElementById('loginForm')),
                    })
                    .then(response => response.text())
                    .then(result => {
                        console.log(result);
                        if(result == "NO USER"){
                            
                        console.log("The username and / or password is incorrect");
                        } else {
                            this.$emit("authenticated", true);
                        this.$router.replace({ name: "home" });
                        }
                    })
                    .catch(error => {
                        console.log(error);
                    });
                    
                } else {
                    console.log("A username and password must be present");
                }
            },
        }
    }
</script>

<style scoped>
    #login {
        width: 500px;
        border: 1px solid #CCCCCC;
        background-color: #FFFFFF;
        margin: auto;
        margin-top: 200px;
        padding: 20px;
    }
</style>