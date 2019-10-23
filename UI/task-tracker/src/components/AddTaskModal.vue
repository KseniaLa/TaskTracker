<template>
	<div class="task-modal">
	  <div class="modal-title">
			{{isEdit ? 'Edit' : 'Add'}} Task
		</div>
		<input class="modal-input" type="text" v-model="taskTitle" placeholder="Task title"/>
		<datepicker placeholder="Due date" v-model="dueDate" input-class="date-input" :clear-button="true"></datepicker>
		<div class="select-box">
			<multiselect v-model="priorityValue" :options="priorityOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="Priority"></multiselect>
			<multiselect v-model="stateValue" :options="stateOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="State"></multiselect>
		</div>
		<textarea class="modal-input modal-textarea" v-model="taskDescription" placeholder="Task description"></textarea>

		<div class="button-set">
			<button class="delete-button" v-if="isEdit">Delete</button>
			<button class="add-button" v-on:click="saveTask">Save</button>
		</div>
  </div>
</template>

<script>
import Multiselect from "vue-multiselect";
import "vue-multiselect\\dist\\vue-multiselect.min.css";
import Datepicker from "vuejs-datepicker";
import { stateMap, priorityMap } from "../mappings/NameMapping.js";
import TaskRepository from "../dataWorker/TaskRepository.js";

export default {
  name: "TaskModal",
  components: {
    Multiselect,
    Datepicker
  },
  props: {
    isEdit: Boolean,
    task: Object
  },
  data() {
    return {
      taskTitle: "",
      taskDescription: "",
      priorityValue: "",
      stateValue: "",
      dueDate: null,
      priorityOptions: ["Low", "Medium", "High", "Critical"],
      stateOptions: ["ToDo", "InProgress", "Done"]
    };
  },
  methods: {
    saveTask: function() {
      TaskRepository.instance.addTask(this.isDemo);
    }
  },
  computed: {    
    isDemo () {
      return this.$store.state.isDemo;
    }
  },
  mounted: function() {
    this.taskTitle = this.isEdit ? this.task.title : "";
    this.taskDescription = this.isEdit ? this.task.description : "";
    this.stateValue = this.isEdit ? stateMap[this.task.state] : null;
    this.priorityValue = this.isEdit ? priorityMap[this.task.priority] : null;
    this.dueDate = this.isEdit ? this.task.date : null;
  }
};
</script>

<style lang="scss">
.task-modal {
  display: flex;
  flex-direction: column;
  padding: 10px;
  z-index: 1000000000;
}

.modal-title {
  margin-bottom: 10px;
  font-size: 22px;
  color: #005eda;
}

.modal-input {
  margin-bottom: 10px;
  padding: 10px;
  border-radius: 5px;
  text-decoration: none;
  outline: none;
  font-size: 20px;
  box-shadow: none;
  resize: none;
}

.date-input {
  padding: 5px;
  border-radius: 5px;
  text-decoration: none;
  outline: none;
  font-size: 15px;
  margin-bottom: 10px;
}

.modal-textarea {
  font-size: 15px;
  height: 200px;
  resize: none;
}

.select-box {
  display: flex;
  flex-direction: row;
  margin-bottom: 10px;
}

.button-set {
	margin: 0;
	position: absolute;
	right: 10px;
	bottom: 10px;

	.add-button {
		margin: 0
	}
}

.delete-button {
	padding: 10px;
  margin-right: 15px;
  border-radius: 10px;
  font-size: 20px;
  transition: 500ms;
  border: none;
  background-color: #ffffff;
	color: #ff0000;
	border: solid 1px #ff0000;
	outline: none;

  &:hover {
    background-color: #f1d9d9;
	}
}
</style>