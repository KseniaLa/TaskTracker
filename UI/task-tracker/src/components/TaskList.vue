<template>
  <div class="task-list">
    <div class="section-header">
      <span>Tasks</span>
      <button class="add-button" v-on:click="openModal">Add</button>
    </div>
    <div class="task-set">
      <div v-if="isLoading"><progress class="progress is-small is-info" max="100">15%</progress></div>
      <div v-else v-for="task in tasks" v-bind:key="task.id">
        <TaskListItem :task="task" />
      </div>
    </div>

    <modal name="task" height="90%" width="50%" @before-open="beforeOpen">
      <TaskModal :isEdit="isEdit" :task="task" v-on:tasks-refresh="getData" />
    </modal>
  </div>
</template>

<script>
import TaskModal from "./AddTaskModal";
import TaskListItem from "./TaskListItem";
import TaskRepository from "../dataWorker/task/TaskRepository.js";
import { toastConfig } from "../utils/Config.js";

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
    getData: async function(isDelete, id) {
      let tasks = await TaskRepository.instance.getTasks(this.isDemo);
      this.tasks = tasks.data;
      this.$store.commit("setTasks", tasks.data);
      if (!tasks.success) {
        this.$dlg.toast("Failed to load tasks", toastConfig);
      }
      this.isLoading = false;
      if (isDelete && id > 0) {
        this.$bus.$emit(`task${id}`);
      } else {
        this.$bus.$emit("full-update");
      }
    }
  },
  data: function() {
    return {
      isEdit: Boolean,
      isLoading: true,
      task: Object,
      tasks: []
    };
  },
  computed: {
    isDemo() {
      return this.$store.state.isDemo;
    }
  },
  mounted: function() {
    this.$log.info(
      `Start retrieving tasks data. Running in ${
        this.isDemo ? "Demo" : "Real"
      } mode`,
      !this.isDemo
    );
    this.getData();
    this.$log.info("Finish retrieving tasks data.", !this.isDemo);
  }
};
</script>

<style lang="scss">
@import '../styles/constants.scss';
@import '../styles/mixins.scss';

.task-list {
  @include flex-item(column);
  width: 40%;
  border-right: solid 1px $border-color;
  height: 100%;
}
.task-set {
  overflow: hidden;
  overflow-y: scroll;

  &::-webkit-scrollbar {
    @include scrollbar();
  }

  &::-webkit-scrollbar-thumb {
    @include scrollbar-thumb();
  }
}

.some {
  height: 70px;
}
</style>