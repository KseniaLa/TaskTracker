<template>
	<div class="dashboard">
	  <div class="section-header">
			<span>Dashboard</span>
			<button class="add-button" v-on:click="openModal">Add</button>
		</div>
		<div class="chart-area">
			<div v-for="data in chartData" v-bind:key="data.id">
				<div class="chart-item">
					<chart :title="data.title" :chartType="data.chartType" :data="data.data" ></chart>
				</div>
			</div>
		</div>

		<modal name="widget" height="90%" width="50%">
      <WidgetModal />
    </modal>
  </div>
</template>

<script>
import WidgetModal from "./AddWidgetModal";
import Chart from "./Chart";

export default {
  name: "Dashboard",
  components: {
    WidgetModal,
    Chart
  },
  methods: {
    openModal: function() {
      this.$modal.show("widget");
    }
  },
  data: function() {
    return {
      chartData: [
        {
          id: 1,
          title: "test1",
          chartType: "bar",
          data: {
            labels: ["January", "February", "March"],
            datasets: [
              {
                label: "GitHub Commits",
                backgroundColor: ["#f87979", "#ff0000"],
                data: [40, 20, 12]
              }
            ]
          }
        },
        {
          id: 2,
          title: "test1",
          chartType: "pie",
          data: {
            labels: ["January", "February", "March"],
            datasets: [
              {
                label: "GitHub Commits",
                backgroundColor: ["#f87979", "#ff0000", "#00ff00"],
                data: [40, 20, 12]
              }
            ]
          }
				},
				{
          id: 3,
          title: "test1",
          chartType: "bar",
          data: {
            labels: ["January", "February", "March"],
            datasets: [
              {
                label: "GitHub Commits",
                backgroundColor: ["#ff0000", "#00ff00", "#0000ff"],
                data: [40, 20, 12]
              }
            ]
          }
				},
				{
          id: 4,
          title: "test1",
          chartType: "pie",
          data: {
            labels: ["January", "February", "March"],
            datasets: [
              {
                label: "GitHub Commits",
                backgroundColor: ["#f87979", "#ff0000", "#00ff00"],
                data: [40, 20, 12]
              }
            ]
          }
				}
      ]
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
  grid-template-columns: 33% 33% 33%;
  overflow: hidden;
  overflow-y: scroll;

  &::-webkit-scrollbar {
    width: 8px;
    background-color: #f5f5f5;
  }

  &::-webkit-scrollbar-thumb {
    border-radius: 10px;
    -webkit-box-shadow: inset 0 0 6px #a0a0a0;
    background-color: rgb(161, 161, 161);
  }
}

.chart-item {
  margin: 20px;
}
</style>