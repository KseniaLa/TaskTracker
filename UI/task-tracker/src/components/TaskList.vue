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

		<modal name="task" height="90%" width="50%" @before-open="beforeOpen">
			<TaskModal :isEdit="isEdit" :task="task" v-on:tasks-refresh="getData"/>
		</modal>
  </div>
</template>

<script>
import TaskModal from "./AddTaskModal";
import TaskListItem from "./TaskListItem";
import TaskRepository from "../dataWorker/task/TaskRepository.js";

export default {
  name: "TaskList",
  components: {
    TaskModal,
    TaskListItem
  },
  methods: {
    openModal: function() {
      this.$modal.show("task", { isEdit: false, task: {} });
    },
    beforeOpen(event) {
			this.isEdit = event.params.isEdit;
			this.task = event.params.task;
    },
    getData() {
      let tasks = TaskRepository.instance.getTasks(this.isDemo);
      this.tasks = tasks;
      this.$store.commit("setTasks", tasks);
    }
  },
  data: function() {
    return {
			isEdit: Boolean,
      task: Object,
      tasks: []
		};
  },
  computed: {    
    isDemo () {
      return this.$store.state.isDemo;
    }
  },
  mounted: function() {
    this.$log.info(`Start retrieving tasks data. Running in ${this.isDemo ? 'Demo' : 'Real'} mode`);
    this.getData();
    this.$log.info('Finish retrieving tasks data.');
  }
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
.task-set {
  overflow: hidden;
  overflow-y: scroll;

  &::-webkit-scrollbar {
    width: 8px;
    background-color: #f5f5f5;
  }

  &::-webkit-scrollbar-thumb {
    border-radius: 10px;
    -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
    background-color: #555;
  }
}
</style>