import Vue from "vue";
import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    isDemo: false,
    isLanding: true
  },
  plugins: [createPersistedState()],
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
