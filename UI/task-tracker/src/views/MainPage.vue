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
        {id: 1, title:"The slings and arrows of outrageous fortune The slings and arrows of outrageous fortune The slings and arrows of outrageous fortune", date: "und", state: 0, priority: 0, description: "To be, or not to be, that is the question: Whether 'tis nobler in the mind to suffer The slings and arrows of outrageous fortune, Or to take arms against a sea of troubles And by opposing end them. The slings and arrows of outrageous fortune The slings and arrows of outrageous fortune"},
        {id: 2, title:"apple2", date: "und", state: 1, priority: 1, description: "test task"},
        {id: 3, title:"qwerty3", date: "und", state: 2, priority: 2, description: "test task"},
        {id: 4, title:"hello", date: "und", state: 1, priority: 3, description: "test task"},
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