<template>
	<div class="chart" v-bind:style="{ 'border-color': item.borderColor }">
		<div class="chart-header">
			<div>{{item.title}}</div>
			<button class="chart-delete-button" v-on:click="deleteWidget">Delete</button>
		</div>
		<div v-if="item.chartType === 0">
			list
		</div>
		<div v-else-if="item.chartType === 1">
			<pie-chart :chartData="data"></pie-chart>
		</div>
		<div v-else-if="item.chartType === 2">
			<bar-chart :chartData="data"></bar-chart>
		</div>
		<div v-else>
		</div>
	</div>
</template>

<script>
import BarChart from "./BarChart.js";
import PieChart from "./PieChart.js";
import ChartDataProcessor from "../utils/ChartDataProcessor.js";

export default {
  name: "Chart",
  components: {
    BarChart,
    PieChart
  },
  props: {
    id: Number,
    item: Object,
    tasks: Array
  },
  data: function() {
    return {
      data: {
        labels: ["a", "b", "c"],
        datasets: [
          {
            backgroundColor: ["#ff0000", "#ff0000", "#ff0000"],
            data: [20, 30, 40]
          }
        ]
      }
    };
  },
  methods: {
    deleteWidget() {
      this.$emit("delete-widget", this.id);
    },
    getChartData() {
      return ChartDataProcessor.getData(
        this.tasks,
        this.item.states,
        this.item.priorities
      );
    }
  },
  mounted: function() {
    this.data = this.getChartData();
	}
};
</script>

<style lang="scss">
.chart {
  padding: 10px;
  box-sizing: content-box;
  border-style: solid;
  border-width: 1px;
}

.chart-header {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 15px;
}

.chart-delete-button {
  padding: 5px;
  border-radius: 5px;
  transition: 500ms;
  background-color: #ffffff;
  color: #ff0000;
  border: solid 1px #ff0000;
  outline: none;

  &:hover {
    background-color: #fcd2d2;
  }
}
</style>