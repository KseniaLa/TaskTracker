import { Bar } from "vue-chartjs";

export default {
  extends: Bar,
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
