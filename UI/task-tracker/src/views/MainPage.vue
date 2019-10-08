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
        {id: 1, title:"hello"},
        {id: 2, title:"apple"},
        {id: 3, title:"qwerty"}
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