<template>
	<div class="modal">
	  <div class="modal-title">
			Add Widget
		</div>
		<input class="modal-input" type="text" v-model="widgetTitle" placeholder="Widget title"/>
		
		<div class="select-box">
			<multiselect v-model="priorityValue" :options="priorityOptions" :searchable="false" :multiple="true" :close-on-select="false" :clear-on-select="false" track-by="name" label="name" placeholder="Priority">
        <template slot="singleLabel" slot-scope="props">{{props.option.name}}</template>
        <template slot="option" slot-scope="props">{{props.option.name}}</template>
      </multiselect>
			<multiselect v-model="stateValue" :options="stateOptions" :searchable="false" :multiple="true" :close-on-select="false" :clear-on-select="false" track-by="name" label="name" placeholder="State">
        <template slot="singleLabel" slot-scope="props">{{props.option.name}}</template>
        <template slot="option" slot-scope="props">{{props.option.name}}</template>
      </multiselect>
		</div>

		<div class="select-box">
			<multiselect v-model="chartValue" :options="chartOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="Chart type">
        <template slot="singleLabel" slot-scope="props">{{props.option.name}}</template>
        <template slot="option" slot-scope="props">{{props.option.name}}</template>
      </multiselect>
			<multiselect v-model="colorValue" :options="colorOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="Color scheme"></multiselect>
		</div>

		<div class="color-box">
			<span>Border color</span>
			<div class="dropdown">
				<svg height="32" width="32" class="dropdown">
					<circle cx="16" cy="16" r="15" :fill="borderColor" />
				</svg>
				<div class="dropdown-content">
					<color-picker v-model="borderColor" width="120" height="120"></color-picker>
				</div>
			</div>
		</div>

		<button class="add-button" v-on:click="saveWidget">Save</button>

    <modal name="widget-error" height="20%" width="40%">
			<error-message v-bind:message="'Cannot save widget: some fields are empty'"/>
		</modal>
  </div>
</template>

<script>
import Multiselect from "vue-multiselect";
import ColorPicker from "vue-color-picker-wheel";
import ErrorMessage from "./ErrorMessage.vue";
import WidgetRepository from "../dataWorker/widget/WidgetRepository.js";
import { toastConfig } from "../utils/Config.js";

export default {
  name: "WidgetModal",
  components: {
    Multiselect,
    ColorPicker,
    ErrorMessage
  },
  data() {
    return {
      widgetTitle: "",
      chartValue: "",
      colorValue: "",
      priorityValue: [],
      stateValue: [],
      borderColor: "#0000ff",
      chartOptions: [
        { name: "List chart", id: 0 },
        { name: "Pie chart", id: 1 },
        { name: "Bar chart", id: 2 }
      ],
      colorOptions: ["1", "2", "3"],
      priorityOptions: [
        { name: "Low", id: 0 },
        { name: "Medium", id: 1 },
        { name: "High", id: 2 },
        { name: "Critical", id: 3 }
      ],
      stateOptions: [
        { name: "ToDo", id: 0 },
        { name: "InProgress", id: 1 },
        { name: "Done", id: 2 }
      ]
    };
  },
  methods: {
    saveWidget: async function() {
      if (this.inputsValid()) {
        let widget = {
          id: -1,
          title: this.widgetTitle,
          states: this.stateValue.map(s => s.id),
          priorities: this.priorityValue.map(p => p.id),
          chartType: this.chartValue.id,
          colorScheme: this.colorValue,
          borderColor: this.borderColor
        };
        let success = await WidgetRepository.instance.addWidget(
          this.isDemo,
          widget
        );
        if (!success) {
          this.$dlg.toast("Failed to add widget", toastConfig);
        }
        this.$emit("widgets-refresh");
        this.$modal.hide("widget");
        return;
      }
      this.$modal.show("widget-error");
    },

    inputsValid() {
      return (
        this.widgetTitle &&
        this.chartValue &&
        this.priorityValue &&
        this.stateValue &&
        this.priorityValue.length > 0 &&
        this.stateValue.length > 0
      );
    }
  },
  computed: {
    isDemo() {
      return this.$store.state.isDemo;
    }
  }
};
</script>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>

<style lang="scss">
.modal {
  display: flex;
  flex-direction: column;
  padding: 10px;
  height: 100%;
  z-index: 1000000000;

  button {
    margin: 10px;
    position: absolute;
    right: 10px;
    bottom: 10px;
  }
}

.v--modal-overlay[data-modal="widget-error"] {
  background: transparent;
}

.color-box {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.dropdown {
  position: relative;
  display: inline-block;
  width: 32px;
}

.dropdown-content {
  display: none;
  float: left;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 120px;
  box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
  padding: 12px 16px;
  z-index: 1;
}

.dropdown:hover .dropdown-content {
  display: block;
}
</style>