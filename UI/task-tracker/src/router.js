import Vue from "vue";
import Router from "vue-router";
import LandingPage from "./views/LandingPage.vue";
import MainPage from "./views/MainPage.vue";
import LoginPage from "./views/LoginPage.vue";

Vue.use(Router);

export default new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "home",
      component: LandingPage
    },
    {
      path: "/main",
      name: "main",
      component: MainPage
    },
    {
      path: "/login",
      name: "login",
      component: LoginPage
    }
  ]
});
