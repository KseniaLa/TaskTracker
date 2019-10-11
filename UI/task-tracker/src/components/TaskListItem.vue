<template>
	<div class="task-item" v-on:click="edit">
		<div class="title">{{task.title}}</div>
		<div class="date">{{task.date}}</div>
		<div class="priority">
			<div v-bind:class="['round', priorityClass]"></div>
			<span>{{priority}}</span>
		</div>
		<div class="state">
			<div v-bind:class="['round', stateClass]"></div>
			<span>{{state}}</span>
		</div>
		<div class="description">{{task.description}}</div>
	</div>
</template>

<script>
import { stateMap, priorityMap } from "../mappings/NameMapping.js";
import { stateClassMap, priorityClassMap } from "../mappings/ClassMapping.js";

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
		},
		stateClass: function() {
      return stateClassMap[this.task.state];
		},
		priorityClass: function() {
      return priorityClassMap[this.task.priority];
    }
	},
	methods: {
		edit: function() {
			this.$modal.show("task", { isEdit: true, task: this.task });
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

	&:hover{
		background-color: #f0f0f0;
	}
}

.title {
  grid-area: title;
	flex: 1;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
	font-weight: bold;
	padding: 5px;
}
.date {
  grid-area: date;
	color: #8b8b8b;
	padding: 5px;
}
.priority {
	display: flex;
	flex-direction: row;
	align-items: center;
  grid-area: priority;
	padding: 5px;
}
.state {
	display: flex;
	flex-direction: row;
	align-items: center;
  grid-area: state;
	padding: 5px;
}
.description {
  grid-area: description;
	flex: 1;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
	color: #8b8b8b;
	padding: 5px;
}

.round {
	width: 20px;
	height: 20px;
	border-radius: 50%;
	margin-right: 5px;
}

.low {
	background-color: #e4e4e4
}
.medium {
	background-color: #3fc800
}
.high {
	background-color: #e49c00
}
.critical {
	background-color: #ff0000
}

.todo {
	background-color: #e4e4e4
}
.progress {
	background-color: #1729cc
}
.done {
	background-color: #1c7900
}
</style>