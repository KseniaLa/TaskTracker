<template>
	<div class="task-item">
		{{task.title}}
	</div>
</template>

<script>
export default {
  name: "TaskListItem",
  props: {
    task: Object
  }
};
</script>

<style lang="scss">
.task-item {
	padding: 5px;
	border: 1px solid #e8e9eb;
	width: 100%;
	height: 80px;
}
</style>