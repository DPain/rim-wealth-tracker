<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Home</router-link>
      |
      <router-link to="/about">About</router-link>
      |
      <router-link to="/leader">Leaderboard</router-link>
    </div>
    <router-view />
  </div>
</template>

<style lang="scss">
@import '@/style/variables.scss';

body {
  height: 100vh;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: $light;
  background-color: $dark;
  min-height: 100%;
  height: auto;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: $primary-dark;

    &.router-link-exact-active {
      color: $primary;
    }
  }
}
</style>
