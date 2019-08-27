<template>
	<main class="landing-page-container">
		Landing page
		<label class="typo__label">Select application mode</label>
		<multiselect v-model="value" :options="options" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="Pick a value"></multiselect>
		<pre class="language-json"><code>{{ value  }}</code></pre>
		<router-link to="/main">Go to MainPage</router-link>
	</main>
    
</template>

<script>
import Multiselect from "vue-multiselect";

export default {
  components: {
    Multiselect
  },
  data() {
    return {
      value: "",
      options: ["Demo", "Real"]
    };
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


