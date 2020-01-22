<template>
	<header class="app-header level is-marginless">
		<div class="app-name level-left">
			<router-link to="/">TaskTracker</router-link>
		</div>
		<div v-if="isDemo" class="demo-badge level-right">Demo</div>
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
@import '../styles/constants.scss';

.app-header {
  padding: 10px;
  background-color: $base-color;
  color: #ffffff;
	box-shadow: 0 4px 8px 0 #00000033, 0 6px 20px 0 #00000030;
}

.app-name {
  color: #ffffff;
  a {
    font-weight: bold;
    color: #ffffff;
		font-size: 50px;
		text-decoration: none;

		&:hover	{
			color: #ffffff;
		}
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


