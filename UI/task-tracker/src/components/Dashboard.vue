<template>
	<div class="dashboard">
	  <div class="section-header">
			<span>Dashboard</span>
			
			<button class="add-button" v-on:click="openModal"><v-icon name="plus"/></button>
			<modal name="widget" :adaptive="true">
      	add widget
    	</modal>
		</div>

		widgets

  </div>
</template>

<script>
export default {
	name: "Dashboard",
	methods: {
    openModal: function() {
      this.$modal.show('widget');
    }
  },
};
</script>

<style lang="scss">
.dashboard {
	display: flex;
	flex-direction: column;
	width: 60%;
	border-right: solid 1px #a8a8a8;
	height: 100%;
}

.add-button {
	color: #0e2feb;
	background-color: #ffffff;
	font-size: 40px;
	border: none;
	margin: 10px;
}
</style>