<template>
	<div class="task-item">
		<div class="title">{{task.title}}</div>
		<div class="date">{{task.date}}</div>
		<div class="priority">{{priority}}</div>
		<div class="state">{{state}}</div>
		<div class="description">{{task.description}}</div>
	</div>
</template>

<script>
import { stateMap, priorityMap } from "../mappings/NameMapping.js";

export default {
  name: "TaskListItem",
  props: {
    task: Object
  },
  computed: {
    state: function() {
      return stateMap[this.task.state];
		},
		priority: function() {
      return priorityMap[this.task.priority];
    }
  }
};
</script>

<style lang="scss">
.task-item {
  display: grid;
  grid-template-columns: 25% 25% 25% 25%;
  grid-template-rows: auto;
  grid-template-areas:
    "title title title date"
    "priority state . ."
    "description description description description";
  padding: 5px;
  border: 1px solid #e8e9eb;
  width: 100%;
  height: 80px;
}

.title {
  grid-area: title;
}
.date {
  grid-area: date;
}
.priority {
  grid-area: priority;
}
.state {
  grid-area: state;
}
.description {
  grid-area: description;
}
</style>