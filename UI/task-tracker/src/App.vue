<template>
  <div id="app">
    <Header v-bind:isDemo="true" />
    <router-view />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
export default {
  name: "header",
  components: {
    Header
  }
};
</script>

<style lang="scss">
html { height:100%; }
body{
  height:100%;
  margin: 0px;
}

#app {
  display: flex;
  flex-direction: column;
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  height: 100%;
}
</style>
