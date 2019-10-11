<template>
  <div class="sections-container">
    <DashBoard/>
		<TaskList :tasks="tasks"/>
  </div>
</template>

<script>
import DashBoard from "@/components/Dashboard.vue";
import TaskList from "@/components/TaskList.vue";

export default {
  name: "MainPage",
  components: {
	DashBoard,
	TaskList
  },
  data: function () {
    return {
      tasks: [
        {id: 1, title:"hello1", date: "und", state: 0, priority: 1, description: "test task"},
        {id: 2, title:"apple2", date: "und", state: 0, priority: 1, description: "test task"},
        {id: 3, title:"qwerty3", date: "und", state: 0, priority: 1, description: "test task"},
        {id: 4, title:"hello"},
        {id: 5, title:"apple"},
        {id: 6, title:"qwerty"},
        {id: 7, title:"hello"},
        {id: 8, title:"apple"},
        {id: 9, title:"qwerty"},
        {id: 10, title:"hello4"},
        {id: 11, title:"apple5"},
        {id: 12, title:"qwerty6"}
      ]
    }
  },
};
</script>

<style lang="scss">
.sections-container {
	display: flex;
	flex-direction: row;
	height: 100%;
}
</style>