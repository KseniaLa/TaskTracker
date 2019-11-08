import { Pie } from "vue-chartjs";

export default {
  extends: Pie,
  props: {
    chartData: {
      type: Object,
      default: null
    }
  },
  mounted() {
    this.renderChart(this.chartData);
  },
  watch: {
    chartData: function() {
      this.renderChart(this.chartData);
    }
  }
};
