<template>
  <main class="landing-page-container">
    <div class="landing-page-content">
      <label class="select-title">Sign In</label>
      <div v-if="isLogin" class="input-container">
        <input type="text" v-model="login" class="login-input" placeholder="login" />
        <input type="password" v-model="password" class="login-input" placeholder="password" />
        <button class="two-colored-login-button" v-on:click="authenticate">Sign in</button>
      </div>
      <div v-else class="input-container">
        <input type="text" v-model="regName" class="login-input" placeholder="name" />
        <input type="text" v-model="regLogin" class="login-input" placeholder="login" />
        <input type="password" v-model="regPassword" class="login-input" placeholder="password" />
        <button class="two-colored-login-button" v-on:click="createUser">Sign up</button>
      </div>
      <button class="two-colored-login-button login-swith-button" v-on:click="switchForms">{{isLogin ? "Sign up" : "Sign in"}}</button>
    </div>
  </main>
</template>

<script>
import router from "../router";
import AccountWorker from "../dataWorker/common/AccountWorker.js";
import { toastConfig } from "../utils/Config.js";

export default {
  data() {
    return {
      isLogin: true,
      login: "",
      password: "",
      regName: "",
      regLogin: "",
      regPassword: "",
      accountWorker: new AccountWorker()
    };
  },
  methods: {
    authenticate: async function() {
      let creds = { login: this.login, password: this.password };
      let tokenResponce = await this.accountWorker.authenticate(creds);
      if (tokenResponce.success && tokenResponce.token) {
        this.$store.commit("setAuthToken", tokenResponce.token);
        router.push("main");
      } else {
        this.$dlg.toast(
          "Failed to sign in. Invalid login or password",
          toastConfig
        );
      }
    },
    createUser: async function() {
      let user = { name: this.regName, login: this.regLogin, password: this.regPassword };
      let tokenResponce = await this.accountWorker.createUser(user);
      if (tokenResponce.success) {
        console.log("ok");
      } else {
        this.$dlg.toast(
          "Failed to create user",
          toastConfig
        );
      }
    },
    switchForms: function() {
      this.isLogin = !this.isLogin;
    }
  },
  mounted: function() {
    this.$log.info("Application (Landing page) loaded.", !this.isDemo);
    this.$store.commit("setLanding", true);
  }
};
</script>

<style lang="scss">
@import "../styles/constants.scss";
@import "../styles/mixins.scss";

.landing-page-container {
  @include flex-item(column);
  align-items: center;
  justify-content: center;
  background: $base-color;
  height: 100%;
}

.landing-page-content {
  @include flex-item(column);
  align-items: center;
  justify-content: center;
  padding: 60px;
  background: $base-color;
  box-shadow: 0 4px 8px 0 #00000033, 0 6px 20px 0 #00000030;

  @media screen and (max-width: 500px) {
    padding: 30px;
  }
}

.select-title {
  font-size: 40px;
  color: #ffffff;
}

.two-colored-login-button {
  padding: 5px;
  margin: 5px;
  border-radius: 5px;
  font-size: 15px;
  transition: 500ms;
  border: none;
  background-color: #2765b6;
  color: #ffffff;
  cursor: pointer;

  &:hover {
    background-color: #ffffff;
    color: #024daf;
    border-color: #024daf;
  }
}

.login-swith-button {
  background-color: #4e78af;
}

.input-container {
  display: flex;
  flex-direction: column;
}

.radiogroup-container {
  @include flex-item(row);
  margin: 10px;

  @media screen and (max-width: 500px) {
    flex-direction: column;
  }
}

.login-input {
  margin-bottom: 5px;
  padding: 5px;
  border-radius: 5px;
  text-decoration: none;
  outline: none;
  font-size: 15px;
  box-shadow: none;
  resize: none;
}

.container {
  display: block;
  position: relative;
  padding-left: 50px;
  margin: 12px;
  cursor: pointer;
  font-size: 40px;
  color: #ffffff;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

.container input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
}

.checkmark {
  position: absolute;
  top: 10px;
  left: 0;
  height: 40px;
  width: 40px;
  background-color: #eee;
  border-radius: 50%;
}

.container:hover input ~ .checkmark {
  background-color: #ccc;
}

.container input:checked ~ .checkmark {
  background-color: #88dd88;
}

.checkmark:after {
  content: "";
  position: absolute;
  display: none;
}

.container input:checked ~ .checkmark:after {
  display: block;
}

.container .checkmark:after {
  top: 10px;
  left: 10px;
  width: 20px;
  height: 20px;
  border-radius: 50%;
  background: white;
}
</style>