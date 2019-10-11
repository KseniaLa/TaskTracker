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
        {id: 1, title:"The slings and arrows of outrageous fortune The slings and arrows of outrageous fortune The slings and arrows of outrageous fortune", date: new Date(2019, 9), state: 0, priority: 0, description: "To be, or not to be, that is the question: Whether 'tis nobler in the mind to suffer The slings and arrows of outrageous fortune, Or to take arms against a sea of troubles And by opposing end them. The slings and arrows of outrageous fortune The slings and arrows of outrageous fortune"},
        {id: 2, title:"apple2", date: new Date(2019, 9), state: 1, priority: 1, description: "test task"},
        {id: 3, title:"qwerty3", date: new Date(2019, 9), state: 2, priority: 2, description: "test task"},
        {id: 4, title:"hello", date: new Date(2019, 9), state: 1, priority: 3, description: "test task"},
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