<template>
	<div class="chart" v-bind:style="{ 'border-color': item.borderColor }">
		<div class="chart-header">
			<div>{{item.title}}</div>
			<button class="chart-delete-button" v-on:click="deleteWidget">Delete</button>
		</div>
		<div v-if="item.chartType === 0">
			<list-chart :chartData="data"></list-chart>
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
import ListChart from "./ListChart.vue";
import ChartDataProcessor from "../utils/ChartDataProcessor.js";

export default {
  name: "Chart",
  components: {
    BarChart,
    PieChart,
    ListChart
  },
  props: {
    id: Number,
    item: Object
  },
  data: function() {
    return {
      data: {}
    };
  },
  methods: {
    deleteWidget() {
      this.$emit("delete-widget", this.id);
    },
    getChartData() {
      return ChartDataProcessor.getData(
        this.$store.state.tasks,
        this.item.states,
        this.item.priorities,
        this.item.chartType
      );
    },
    updateData() {
      var newData = this.getChartData();
      this.data = newData.data;
      newData.ids.forEach(e => {
        this.$bus.$on(`task${e}`, () => {
          this.data = this.getChartData().data;
        });
      });
    }
  },
  mounted: function() {
		this.updateData();
  },
  created: function() {
    this.$bus.$on("full-update", () => {
			this.updateData();
    });
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