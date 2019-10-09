<template>
	<div class="dashboard">
	  <div class="section-header">
			<span>Dashboard</span>
			<button class="add-button" v-on:click="openModal">Add</button>
		</div>
		<div class="chart-area">
			<div class="chart-item">
				<bar-chart :chartData="chartData"></bar-chart>
			</div>
			<div class="chart-item">
				<pie-chart :chartData="chartData"></pie-chart>
			</div>
			<div class="chart-item">
				<bar-chart></bar-chart>
			</div>
		</div>

		<modal name="widget" height="90%" width="50%">
      <WidgetModal />
    </modal>
  </div>
</template>

<script>
import WidgetModal from "./AddWidgetModal";
import BarChart from "./BarChart.js";
import PieChart from "./PieChart.js";

export default {
  name: "Dashboard",
  components: {
    WidgetModal,
		BarChart,
		PieChart
  },
  methods: {
    openModal: function() {
      this.$modal.show("widget");
    }
  },
  data: function() {
    return {
      chartData: {
        labels: [
          "January",
          "February",
          "March",
          "April",
          "May",
          "June",
          "July",
          "August",
          "September",
          "October",
          "November",
          "December"
        ],
        datasets: [
          {
            label: "GitHub Commits",
            backgroundColor: ["#f87979", "#ff0000"],
            data: [40, 20, 12, 39, 10, 40, 39, 80, 40, 20, 12, 11]
          }
        ]
      }
    };
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
	display: grid;
  grid-template-columns: 50% 50%;
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

.chart-item {
	margin: 20px;
}
</style>