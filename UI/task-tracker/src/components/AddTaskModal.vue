<template>
	<div class="modal">
	  <div class="modal-title">
			Add Task
		</div>
		<input class="modal-input" type="text" placeholder="Task title"/>
		<datepicker placeholder="Due date" input-class="date-input" :clear-button="true"></datepicker>
		<div class="select-box">
			<multiselect v-model="priorityValue" :options="priorityOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="Priority"></multiselect>
			<multiselect v-model="stateValue" :options="stateOptions" :searchable="false" :close-on-select="true" :show-labels="false" placeholder="State"></multiselect>
		</div>
		<textarea class="modal-input modal-textarea" placeholder="Task description"></textarea>

		<button class="add-button">Save</button>
  </div>
</template>

<script>
import Multiselect from 'vue-multiselect';
import 'vue-multiselect\\dist\\vue-multiselect.min.css';
import Datepicker from 'vuejs-datepicker';

export default {
	name: "TaskModal",
	components: {
		Multiselect,
		Datepicker
  },
  data () {
    return {
			priorityValue: '',
			stateValue: '',
			priorityOptions: ['Low', 'Medium', 'High', 'Critical'],
			stateOptions: ['ToDo', 'InProgress', 'Done']
    }
  }
};
</script>

<style lang="scss">
.modal {
	display: flex;
	flex-direction: column;
	padding: 10px;
	z-index: 1000000000;

	button {
		margin: 0;
	}
}

.modal-title {
	margin-bottom: 10px;
	font-size: 22px;
	color: #005eda
}

.modal-input {
	margin-bottom: 10px;
	padding: 10px;
	border-radius: 5px;
	text-decoration: none;
	outline: none;
	font-size: 20px;
	box-shadow: none;
	resize: none;
}

.date-input {
	padding: 5px;
	border-radius: 5px;
	text-decoration: none;
	outline: none;
	font-size: 15px;
	margin-bottom: 10px;
}

.modal-textarea {
	font-size: 15px;
	height: 200px;
	resize: none;
}

.select-box {
	display: flex;
	flex-direction: row;
	margin-bottom: 10px;
}

</style>