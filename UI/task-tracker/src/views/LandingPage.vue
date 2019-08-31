<template>
	<main class="landing-page-container">
		<label class="typo__label">Select site mode</label>
		
		<button v-on:click="goToMainPage">Go to MainPage</button>
	</main>
    
</template>

<script>
import router from '../router'

export default {
  methods: {
    goToMainPage: function() {
      this.$store.commit('setDemo', true)
      this.$store.commit('setLanding', false)
      router.push('main')
    }
  },
  mounted: function () {
    this.$store.commit('setLanding', true)
  }
};
</script>

<style lang="scss">
.landing-page-container {
  display: flex;
  flex-direction: column;
  background: #005eda;
  height: 100%;
}
</style>


