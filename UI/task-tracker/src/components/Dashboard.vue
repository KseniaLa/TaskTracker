<template>
	<div class="dashboard">
	  <div class="section-header">
			<span>Dashboard</span>
			
			<button class="add-button" v-on:click="openModal">Add</button>
			<modal name="widget" :adaptive="true">
      	add widget
    	</modal>
		</div>

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
</style>