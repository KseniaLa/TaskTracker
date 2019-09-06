<template>
	<div class="task-list">
	  <div class="section-header">
			<span>Tasks</span>
			<button class="two-colored-button"  v-on:click="openModal">Add</button>
		</div>

		widgets

		<modal name="task" :adaptive="true">
			add task
		</modal>
  </div>
</template>

<script>
export default {
	name: "TaskList",
	methods: {
    openModal: function() {
      this.$modal.show('task');
    }
  },
};
</script>

<style lang="scss">
.task-list {
	display: flex;
	flex-direction: column;
	width: 40%;
	border-right: solid 1px #a8a8a8;
	height: 100%;
}
</style>