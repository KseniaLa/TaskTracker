<template>
	<div class="task-modal">
	  <div class="modal-title">
			{{isEdit ? 'Edit' : 'Add'}} Task
		</div>
		<input class="modal-input" type="text" v-model="taskTitle" placeholder="Task title"/>
		<datepicker placeholder="Due date" v-model="dueDate" input-class="date-input" :clear-button="true"></datepicker>
		<div class="select-box">
			<multiselect v-model="priorityValue" :options="priorityOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="Priority">
        <template slot="singleLabel" slot-scope="props">{{props.option.name}}</template>
        <template slot="option" slot-scope="props">{{props.option.name}}</template>
      </multiselect>
			<multiselect v-model="stateValue" :options="stateOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="State">
        <template slot="singleLabel" slot-scope="props">{{props.option.name}}</template>
        <template slot="option" slot-scope="props">{{props.option.name}}</template>
      </multiselect>
		</div>
		<textarea class="modal-input modal-textarea" v-model="taskDescription" placeholder="Task description"></textarea>

		<div class="button-set">
			<button class="delete-button" v-if="isEdit" v-on:click="deleteTask">Delete</button>
			<button class="add-button" v-on:click="saveTask">Save</button>
		</div>

    <modal name="task-error" height="20%" width="40%">
			<error-message v-bind:message="'Cannot save task: some fields are empty'"/>
		</modal>
  </div>
</template>

<script>
import Multiselect from "vue-multiselect";
import Datepicker from "vuejs-datepicker";
import { stateMap, priorityMap } from "../mappings/NameMapping.js";
import TaskRepository from "../dataWorker/task/TaskRepository.js";
import ErrorMessage from "./ErrorMessage.vue";
import { toastConfig } from "../utils/Config.js";

export default {
  name: "TaskModal",
  components: {
    Multiselect,
    Datepicker,
    ErrorMessage
  },
  props: {
    isEdit: Boolean,
    task: Object
  },
  data() {
    return {
      taskId: -1,
      taskTitle: "",
      taskDescription: "",
      priorityValue: "",
      stateValue: "",
      dueDate: null,
      priorityOptions: [
        { name: "Low", id: 0 },
        { name: "Medium", id: 1 },
        { name: "High", id: 2 },
        { name: "Critical", id: 3 }
      ],
      stateOptions: [
        { name: "ToDo", id: 0 },
        { name: "InProgress", id: 1 },
        { name: "Done", id: 2 }
      ]
    };
  },
  methods: {
    saveTask: async function() {
      if (this.inputsValid()) {
        let task = {
          id: this.taskId,
          title: this.taskTitle,
          description: this.taskDescription,
          priority: this.priorityValue.id,
          state: this.stateValue.id,
          date: this.dueDate
        };
        let success = await TaskRepository.instance.addTask(this.isDemo, task);
        if (!success) {
          this.$dlg.toast("Failed to add task", toastConfig);
        }
        this.$emit("tasks-refresh", false);
        this.$modal.hide("task");
        return;
      }
      this.$modal.show("task-error");
    },
    deleteTask: async function() {
      let success = await TaskRepository.instance.deleteTask(
        this.isDemo,
        this.taskId
      );
      if (!success) {
        this.$dlg.toast("Failed to delete task", toastConfig);
      }
      this.$emit("tasks-refresh", true, this.taskId);
      this.$modal.hide("task");
    },
    inputsValid() {
      return (
        this.taskTitle && this.dueDate && this.priorityValue && this.stateValue
      );
    }
  },
  computed: {
    isDemo() {
      return this.$store.state.isDemo;
    }
  },
  mounted: function() {
    this.taskId = this.isEdit ? this.task.id : -1;
    this.taskTitle = this.isEdit ? this.task.title : "";
    this.taskDescription = this.isEdit ? this.task.description : "";
    this.stateValue = this.isEdit
      ? { name: stateMap[this.task.state], id: this.task.state }
      : null;
    this.priorityValue = this.isEdit
      ? { name: priorityMap[this.task.priority], id: this.task.priority }
      : null;
    this.dueDate = this.isEdit ? this.task.date : null;
  }
};
</script>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>

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
    margin: 0;
  }
}

.v--modal-overlay[data-modal="task-error"] {
  background: transparent;
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