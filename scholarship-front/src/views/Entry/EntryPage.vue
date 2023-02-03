<template>
 <div class="main">
  <back-drop></back-drop>
  <div class="main-inner">
   <div class="info" :class="[this.signUp ? 'info__right' : '']">
    <div class="info-inner">
     <img src="../../assets/Images/loginImage.jpeg" alt="logoImage" />
     <div class="info-inner-backdrop"></div>
     <div class="info-inner-text">
      Desiderius <span> Erasmus </span> Roterodamus was a Dutch philosopher and
      Catholic theologian who is considered one of the greatest scholars of the
      northern Renaissance. As a Catholic priest, he was an important figure in
      classical <span>scholarship</span> who wrote in a pure Latin style. Among
      humanists he was given the sobriquet
      <span>"Prince of the Humanists"</span>, and has been called
      <span>"the crowning glory of the Christian humanists"</span>.
     </div>
    </div>
   </div>
   <div class="welcome" :class="[this.signUp ? 'welcome__left' : '']">
    <div style="background-color: #2841598e; color: var(--mainColor7)">
     <h3>Welcome to our scholorship program</h3>
    </div>
    <div class="component">
     <div v-if="!this.signUp"><login-component></login-component></div>
     <div>
      <span @click="changePage">
       {{ this.signUp ? "Log in" : "Sign up" }}
      </span>
     </div>
    </div>
   </div>
  </div>
 </div>
</template>

<script>
import LoginComponent from "./Components/LoginComponent.vue";
import BackDrop from "../../components/BackDrop.vue";
export default {
 components: {
  LoginComponent,
  BackDrop,
 },
 data() {
  return {
   signUp: false,
  };
 },
 methods: {
  changePage() {
   this.signUp = !this.signUp;
  },
 },
};
</script>

<style scoped>
@import "@/assets/Variables.css";
.main {
 display: flex;
 flex-direction: row;
 margin: 0;
 padding: 0;
 padding-top: 5vh;
 width: 100%;
 height: 100vh;
 background-color: var(--mainColor2);
 color: var(--mainColor5);
 align-content: center;
 position: relative;
 font-family: "Italy" sarif;
}
.info {
 border-radius: 2rem;
 background-color: var(--mainColor1);
 display: flex;
 flex-direction: column;
 width: 30vw;
 height: 90vh;
 margin: auto;
 z-index: 2;
 position: absolute;
 left: 20vw;
 overflow: hidden;
 animation: slideRightBack 600ms;
 animation-fill-mode: forwards;
}
.info__right {
 animation: slideRight 600ms;
 animation-fill-mode: forwards;
}
.welcome {
 position: absolute;
 display: flex;
 flex-direction: column;
 margin: 0;
 margin-top: 15vh;
 width: 30vw;
 right: 20vw;
 animation: slideLeftBack 400ms;
 animation-fill-mode: forwards;
 height: 55vh;
 align-items: center;
}
.component {
 background-color: var(--mainColor8);
 border-radius: 0 20px 20px 0;
 padding: 20px;
 display: flex;
 flex-direction: column;
 width: 100%;
 height: 100%;
}
.welcome__left {
 animation: slideLeft 400ms;
 animation-fill-mode: forwards;
}
.info-inner {
 display: flex;
 flex-direction: column;
 justify-content: center;
 align-items: center;
}
img {
 width: 100%;
}
.info-inner-text {
 position: absolute;
 bottom: 30px;
 max-width: calc(100% - 30px);
 color: var(--mainColor8);
 font-size: 1.2rem;
 font-style: italic;
 font-weight: lighter;
}
span {
 font-weight: bold;
 font-size: 1.25rem;
}
.info-inner-backdrop {
 position: absolute;
 top: 0;
 height: 85%;
 width: 100%;
 background: var(--mainColor1);
 background: linear-gradient(180deg, #0d345b00 0%, var(--mainColor1) 100%);
}
@keyframes slideRightBack {
 from {
  transform: translateX(35vw);
 }
 to {
  transform: translateX(0);
 }
}
@keyframes slideLeftBack {
 from {
  transform: translateX(-45vw);
  border-radius: 20px 0 0 20px;
 }
 to {
  transform: translateX(0);
  border-radius: 0 20px 20px 0;
 }
}
@keyframes slideLeft {
 from {
  transform: translateX(0);
  border-radius: 0 20px 20px 0;
 }
 to {
  transform: translateX(-45vw);
  border-radius: 20px 0 0 20px;
 }
}
@keyframes slideRight {
 from {
  transform: translateX(0);
 }
 to {
  transform: translateX(35vw);
 }
}
</style>
