<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link> |
      <router-link v-if="!authenticated" to="/login">Login</router-link>
      <router-link v-if="authenticated" to="/login" v-on:click.native="logout()" replace>Logout</router-link> |
      <router-link v-if="!authenticated" to="/register">Register</router-link>
    </div>
    <router-view @authenticated="setAuthenticated" />
  </div>
</template>

<script>
  export default {
      name: 'App',
      data() {
          return {
              authenticated: false,
              mockAccount: {
                  username: "user",
                  password: "password"
              }
          }
      },
      mounted() {
          if(!this.authenticated) {
              this.$router.replace({ name: "login" });
          }
      },
      methods: {
          setAuthenticated(status) {
              this.authenticated = status;
          },
          logout() {
              this.authenticated = false;
          }
      }
  }
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #0088ff;
}
</style>
