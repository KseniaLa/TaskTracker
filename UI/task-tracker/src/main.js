import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import VModal from "vue-js-modal";
import "./registerServiceWorker";
import "./styles/common.scss";
import Icon from "vue-awesome/components/Icon";

Icon.register({
  plus: {
    width: 448,
    height: 512,
    paths: [
      {
        d:
          "M416 208c17.7 0 32 14.3 32 32v32c0 17.7-14.3 32-32 32h-144v144c0 17.7-14.3 32-32 32h-32c-17.7 0-32-14.3-32-32v-144h-144c-17.7 0-32-14.3-32-32v-32c0-17.7 14.3-32 32-32h144v-144c0-17.7 14.3-32 32-32h32c17.7 0 32 14.3 32 32v144h144z"
      }
    ]
  }
});

Icon.register({
  "plus-circle": {
    width: 512,
    height: 512,
    paths: [
      {
        d:
          "M256 8c137 0 248 111 248 248s-111 248-248 248-248-111-248-248 111-248 248-248zM400 284v-56c0-6.6-5.4-12-12-12h-92v-92c0-6.6-5.4-12-12-12h-56c-6.6 0-12 5.4-12 12v92h-92c-6.6 0-12 5.4-12 12v56c0 6.6 5.4 12 12 12h92v92c0 6.6 5.4 12 12 12h56c6.6 0 12-5.4 12-12v-92h92c6.6 0 12-5.4 12-12z"
      }
    ]
  }
});

Vue.component("v-icon", Icon);

Vue.config.productionTip = false;

Vue.use(VModal);
Vue.use(require("vue-moment"));

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
