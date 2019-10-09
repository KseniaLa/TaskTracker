<template>
	<div>
		{{title}}
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
  name: "AppHeader",
  components: {
    BarChart,
    PieChart
  },
  props: {
		title: String,
    chartType: String,
    data: Object
  }
};
</script>

<style lang="scss">

</style>