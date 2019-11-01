<template>
	<div class="error">
		{{message}}
	</div>
</template>

<script>
export default {
  name: "AppHeader",
  props: {
    message: String
  }
};
</script>

<style lang="scss">
.error {
	display: flex;
	justify-content: center;
	align-items: center;
	width: 100%;
	height: 100%;
	background-color: #c56f6f;
	color: #ffffff;
}
</style>