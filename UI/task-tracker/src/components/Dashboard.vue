<template>
	<div class="dashboard">
	  <div class="section-header">
			<span>Dashboard</span>
			<button class="add-button" v-on:click="openModal">Add</button>
		</div>
		<div class="chart-area">
			<bar-chart></bar-chart>
		</div>

		<modal name="widget" height="90%" width="50%">
      <WidgetModal />
    </modal>
  </div>
</template>

<script>
import WidgetModal from "./AddWidgetModal";
import BarChart from "./BarChart";
export default {
  name: "Dashboard",
  components: {
		WidgetModal,
		BarChart
  },
  methods: {
    openModal: function() {
      this.$modal.show("widget");
    }
  }
};
</script>

<style lang="scss">
.dashboard {
  display: flex;
  flex-direction: column;
  width: 60%;
  border-right: solid 1px #a8a8a8;
  height: 100%;
}

.chart-area {
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