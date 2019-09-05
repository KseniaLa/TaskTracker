<template>
	<main class="landing-page-container">
    <div class="landing-page-content">
      <label class="select-title">Select site mode</label>
        <div class="radiogroup-container">
          <label class="container">Demo
            <input type="radio" checked="checked" name="radio" v-bind:value="true" v-model="isDemo">
            <span class="checkmark"></span>
          </label>
          <label class="container">Real
            <input type="radio" name="radio" v-bind:value="false" v-model="isDemo">
            <span class="checkmark"></span>
          </label>
        </div>
    
		  <button class="two-colored-button" v-on:click="goToMainPage">Go to MainPage</button>
    </div>
		
	</main>
    
</template>

<script>
import router from "../router";

export default {
  data() {
    return {
      isDemo: true 
    }
  },
  methods: {
    goToMainPage: function() {
      this.$store.commit("setDemo", this.isDemo);
      this.$store.commit("setLanding", false);
      router.push("main");
    }
  },
  mounted: function() {
    this.$store.commit("setLanding", true);
  }
};
</script>

<style lang="scss">
.landing-page-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  background: #005eda;
  height: 100%;
}

.landing-page-content {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 60px;
  background: #005eda;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);

  @media screen and (max-width: 500px) {
    padding: 30px;
  }
}

.select-title {
  font-size: 40px;
  color:#ffffff;
}

.two-colored-button {
  padding: 20px;
  margin: 10px;
  border-radius: 10px;
  font-size: 20px;
  transition: 500ms;
  border: none;
  background-color: #024daf;
  color: #ffffff;

  &:hover {
    background-color: #ffffff;
    color: #024daf;
    border-color: #024daf;
  }
}

.radiogroup-container {
  display: flex;
  flex-direction: row;
  margin: 10px;

  @media screen and (max-width: 500px) {
    flex-direction: column;
  }
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
  top: 0;
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


