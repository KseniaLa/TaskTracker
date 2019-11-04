<template>
  <div class="sections-container">
    <DashBoard/>
		<TaskList/>
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