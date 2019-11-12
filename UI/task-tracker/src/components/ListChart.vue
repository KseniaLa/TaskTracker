<template>
	<div class="list-chart">
		<div v-for="ds in chartData.datasets" v-bind:key="ds.id">
			<div>{{`${ds.label} - ${ds.data} %`}}</div>
		</div>
	</div>
</template>

<script>
export default {
  name: "ListChart",
  components: {},
  props: {
    chartData: Object
  },
  data: function() {
    return {
      data: {}
    };
  },
  methods: {
    
  },
  mounted: function() {
		
  },
  created: function() {
    
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

</style>