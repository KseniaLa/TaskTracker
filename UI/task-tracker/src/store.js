import Vue from "vue";
import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    isDemo: false,
    isLanding: true,
    authToken: null,
    tasks: [],
    widgets: []
  },
  plugins: [createPersistedState()],
  mutations: {
    setDemo(state, isDemo) {
      state.isDemo = isDemo;
    },
    setLanding(state, isLanding) {
      state.isLanding = isLanding;
    },
    setAuthToken(state, token) {
      state.authToken = token;
    },
    setTasks(state, tasks) {
      state.tasks = tasks;
    },
    setWidgets(state, widgets) {
      state.widgets = widgets;
    }
  },
  actions: {
    isDemo: state => state.isDemo,
    isLanding: state => state.isLanding,
    authToken: state => state.authToken,
    tasks: state => state.tasks,
    widgets: state => state.widgets
  }
});
