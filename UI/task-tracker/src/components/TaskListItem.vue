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
	width: 100%;
	height: 80px;
}
</style>