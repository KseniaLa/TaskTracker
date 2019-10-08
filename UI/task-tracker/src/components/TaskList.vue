<template>
	<div class="task-list">
	  <div class="section-header">
			<span>Tasks</span>
			<button class="add-button"  v-on:click="openModal">Add</button>
		</div>
		<div class="task-set">
    <div v-for="task in tasks" v-bind:key="task.id">
			<TaskListItem :task="task"/>
		</div>
		</div>

		<modal name="task" height="90%" width="50%">
			<TaskModal />
		</modal>
  </div>
</template>

<script>
import TaskModal from "./AddTaskModal";
import TaskListItem from "./TaskListItem";

export default {
	name: "TaskList",
	components: {
		TaskModal,
		TaskListItem
	},
	props: {
    tasks: {
      type: Array,
      required: true
    },
  },
	methods: {
    openModal: function() {
      this.$modal.show('task');
    }
  },
	data: function () {
    return {
      
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