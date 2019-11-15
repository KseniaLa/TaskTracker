<template>
	<div class="dashboard">
	  <div class="section-header">
			<span>Dashboard</span>
			<button class="add-button" v-on:click="openModal">Add</button>
		</div>
		<div class="chart-area">
			<div v-for="widget in widgets" v-bind:key="widget.id">
				<div class="chart-item">
					<chart :id="widget.id" :item="widget" v-on:delete-widget="deleteWidget"></chart>
				</div>
			</div>
		</div>

		<modal name="widget" height="90%" width="50%">
      <WidgetModal v-on:widgets-refresh="getData"/>
    </modal>
  </div>
</template>

<script>
import WidgetModal from "./AddWidgetModal";
import Chart from "./Chart";
import WidgetRepository from "../dataWorker/widget/WidgetRepository.js";
import { toastConfig } from "../utils/Config.js";

export default {
  name: "Dashboard",
  components: {
    WidgetModal,
    Chart
  },
  methods: {
    openModal: function() {
      this.$modal.show("widget");
    },
    deleteWidget: async function(id) {
      let success = await WidgetRepository.instance.deleteWidget(this.isDemo, id);
      if (!success) {
        this.$dlg.toast("Failed to delete widget", toastConfig);
      }
      this.getData();
    },
    getData: async function() {
      let widgets = await WidgetRepository.instance.getWidgets(this.isDemo);
      this.widgets = widgets.data;
      this.$store.commit("setWidgets", widgets.data);
      if (!widgets.success) {
        this.$dlg.toast("Failed to get widgets", toastConfig);
      }
    }
  },
  data: function() {
    return {
      widgets: [],
    };
  },
  computed: {    
    isDemo () {
      return this.$store.state.isDemo;
    },
    appTasks() {
      return this.$store.state.tasks;
    }
  },
  mounted: function() {
    this.$log.info(`Start retrieving widgets data. Running in ${this.isDemo ? 'Demo' : 'Real'} mode`, !this.isDemo);
    this.getData();
    this.$log.info('Finish retrieving widgets data.', !this.isDemo);
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

  @media screen and (max-width: 1200px) {
    grid-template-columns: 50% 50%;
  }

  @media screen and (max-width: 800px) {
    grid-template-columns: 100%;
  }

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