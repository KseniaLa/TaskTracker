import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    isDemo: false,
    isLanding: true
  },
  mutations: {
    setDemo(state, isDemo) {
      state.isDemo = isDemo;
    },
    setLanding(state, isLanding) {
      state.isLanding = isLanding;
    }
  },
  actions: {
    isDemo: state => state.isDemo,
    isLanding: state => state.isLanding
  }
});
