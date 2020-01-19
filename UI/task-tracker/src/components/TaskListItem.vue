<template>
	<div class="task-item" v-on:click="edit">
		<div class="task-title">{{task.title}}</div>
		<div class="date">{{task.date | moment("DD MMM YY")}}</div>
		<div class="priority">
			<span v-bind:class="['tag', priorityClass]">{{priority}}</span>
		</div>
		<div class="state">
			<span class="tag">{{state}}</span>
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
@import '../styles/constants.scss';
@import '../styles/mixins.scss';

.task-item {
  display: grid;
  grid-template-columns: 25% 25% 25% 25%;
  grid-template-rows: auto;
  grid-template-areas:
    "title title title date"
    "priority state . ."
    "description description description description";
  padding: 5px;
  border: 1px solid $sub-border-color;
  width: 100%;
	height: 110px;
	cursor: pointer;


	@media screen and (max-width: 1200px) {
    grid-template-areas:
			"title title title title"
			"priority state . ."
			". . . .";
		grid-template-rows: 50% 50%;
  }

	@media screen and (max-width: 900px) {
    grid-template-columns: 60% 20% 20%;
		grid-template-areas:
			"title priority state";
		grid-template-rows: 100%;
		height: 40px;
  }

	&:hover{
		background-color: #f0f0f0;
	}
}

.task-title {
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
	color: $sub-text-color;
	padding: 5px;
}
.priority {
	@include flex-item(row);
	align-items: center;
  grid-area: priority;
	padding: 5px;
}
.state {
	@include flex-item(row);
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
	color: $sub-text-color;
	padding: 5px;
}

.round {
	width: 20px;
	height: 20px;
	border-radius: 50%;
	margin-right: 5px;
}

.round-title {
	@media screen and (max-width: 900px) {
		display: none;
	}
}
</style>