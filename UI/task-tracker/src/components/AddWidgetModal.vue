<template>
	<div class="modal">
	  <div class="modal-title">
			Add Widget
		</div>
		<input class="modal-input" type="text" v-model="widgetTitle" placeholder="Widget title"/>
		
		<div class="select-box">
			<multiselect v-model="priorityValue" :options="priorityOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="Priority"></multiselect>
			<multiselect v-model="stateValue" :options="stateOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="State"></multiselect>
		</div>

		<div class="select-box">
			<multiselect v-model="chartValue" :options="chartOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="Chart type"></multiselect>
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
import "vue-multiselect\\dist\\vue-multiselect.min.css";
import ColorPicker from "vue-color-picker-wheel";
import ErrorMessage from "./ErrorMessage.vue";

export default {
  name: "TaskModal",
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
      priorityValue: "",
      stateValue: "",
      borderColor: "",
      chartOptions: ["List", "Pie chart", "Bar chart"],
      colorOptions: ["1", "2", "3"],
      priorityOptions: ["Low", "Medium", "High", "Critical"],
      stateOptions: ["ToDo", "InProgress", "Done"]
    };
  },
  methods: {
    saveWidget: function() {
      if (this.inputsValid()) {
        console.log('save widget');
        return;
      }
      this.$modal.show("widget-error");
    },

    inputsValid() {
      return this.widgetTitle && this.chartValue && (this.priorityValue || this.stateValue);
    }
  }
};
</script>

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