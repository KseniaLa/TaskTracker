<template>
	<div class="chart" v-bind:style="{ 'border-color': borderColor }">
		<div class="chart-header">
			<div>{{title}}</div>
			<button class="chart-delete-button" v-on:click="deleteWidget">Delete</button>
		</div>
		<div v-if="chartType === 'bar'">
			<bar-chart :chartData="data"></bar-chart>
		</div>
		<div v-else-if="chartType === 'pie'">
			<pie-chart :chartData="data"></pie-chart>
		</div>
		<div v-else-if="chartType === 'list'">
			list
		</div>
		<div v-else>
		</div>
	</div>
</template>

<script>
import BarChart from "./BarChart.js";
import PieChart from "./PieChart.js";

export default {
  name: "Chart",
  components: {
    BarChart,
    PieChart
  },
  props: {
		id: Number,
		title: String,
		chartType: String,
		borderColor: String,
    data: Object
	},
	methods: {
		deleteWidget() {
			this.$emit("delete-widget", this.id);
		}
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