<template>
  <div id="app">
    <AppHeader v-bind:isDemo="isBadge" />
    <router-view />
  </div>
</template>

<script>
import AppHeader from "@/components/Header.vue";

export default {
  name: "app",
  components: {
    AppHeader
  },
  computed: {    
    isBadge () {
      return this.$store.state.isDemo && !this.$store.state.isLanding;
    }
  }
};
</script>

<style lang="scss">
@import './styles/mixins.scss';
@import "~bulma/css/bulma.css";

html { height:100%; }
body{
  height:100%;
  margin: 0px;

  &::-webkit-scrollbar {
    @include scrollbar();
  }

  &::-webkit-scrollbar-thumb {
    @include scrollbar-thumb();
  }
}

#app {
  display: flex;
  flex-direction: column;
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  height: 100%;
}

div.v-dialog-toast__container .v-dialog-toast__content {
    padding: 12px 10px 0 70px;
    font-size: 14px;
    overflow: hidden;
    min-height: 68px;
}
</style>
