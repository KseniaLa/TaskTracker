<template>
	<header class="app-header">
		<div class="app-name">
			<router-link to="/">TaskTracker</router-link>
		</div>
		<div v-if="isDemo" class="demo-badge">Demo</div>
	</header>
</template>

<script>
export default {
  name: "AppHeader",
  props: {
    isDemo: Boolean
  }
};
</script>

<style lang="scss">
.app-header {
  display: flex;
  flex-direction: row;
	align-items: center;
	justify-content: space-between;
  padding: 10px;
  background-color: #005eda;
  color: #ffffff;
	box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);

	@media screen and (max-width: 400px) {
    flex-direction: column;
		justify-content: center;
  }
}

.app-name {
  color: #ffffff;
  a {
    font-weight: bold;
    color: #ffffff;
		font-size: 50px;
		text-decoration: none;
  }
}

.demo-badge {
	background-color: #008000;
	padding: 10px;
	border-radius: 5px;
	font-weight: bold;
	text-transform: uppercase
}
</style>


