<template>
	<header class="header">
		<div class="app-name">
			<router-link to="/">TaskTracker</router-link>
		</div>
		<div v-if="isDemo" class="demo-badge">Demo</div>
	</header>
</template>

<script>
export default {
  name: "Header",
  props: {
    isDemo: Boolean
  }
};
</script>

<style lang="scss">
.header {
  display: flex;
  flex-direction: row;
	align-items: center;
	justify-content: space-between;
  padding: 10px;
  background-color: #005eda;
  color: #ffffff;
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


