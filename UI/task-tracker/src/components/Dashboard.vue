<template>
	<div class="dashboard">
	  <div class="section-header">
			<span>Dashboard</span>
			
			<button class="add-button" v-on:click="openModal">Add</button>
			<modal name="widget" height="90%" width="50%">
      	<WidgetModal />
    	</modal>
		</div>

  </div>
</template>

<script>
import WidgetModal from "./AddWidgetModal";
export default {
	name: "Dashboard",
	components: {
		WidgetModal
	},
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