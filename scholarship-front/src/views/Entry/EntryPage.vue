<template>
 <div class="main">
  <div class="main-inner">
   <div class="info" :class="[this.signUp ? 'info__right' : '']">
    <h2>title in here</h2>
    <div>
     One of the cool things about this font generator is that you can choose
     from more than 20 different styles. That means you can find a unique flair
     that perfectly fits what you’re trying to say. To use the font generator on
     a desktop, simply type (or copy/paste) your text into the “Type/paste your
     text” field, and then select one of the font subsets. Once you click on a
     subset, you’ll see a drop-down list with previews of each style. Find the
     one you like, click the “Copy” button on the right, and then right-click or
     key-shortcut your text anywhere online or offline that allows you to type
     text. For mobile users on iPhone or Android, it’s even easier. Like
     desktop, simply type or copy/paste your desired text into the input field,
     and then choose your subset. Once you decide on the font, click the “Copy”
     button and the text will automatically save to your clipboard. Then head
     over to whatever platform you want, paste it in, and blow people’s minds
     with your fancy text.
    </div>
   </div>
   <div class="welcome" :class="[this.signUp ? 'welcome__left' : '']">
    <h3>Welcome to our scholorship program</h3>
    <div v-if="!this.signUp"><login-component></login-component></div>
    <div>
     <span @click="changePage">
      {{ this.signUp ? "Log in" : "Sign up" }}
     </span>
    </div>
   </div>
  </div>
 </div>
</template>

<script>
import LoginComponent from "./Components/LoginComponent.vue";
export default {
 components: {
  LoginComponent,
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
@import '@/assets/Variables.css';
.main {
 display: flex;
 flex-direction: row;
 margin: 0;
 padding: 0;
 padding-top: 10vh;
 width: 100%;
 height: auto;
 background-color: var(--mainColor1);
 color: var(--mainColor5);
 align-content: center;
 position: relative;
}
.info {
 border-radius: 1rem;
 background-color: var(--mainColor2);
 display: flex;
 flex-direction: column;
 width: calc(50vw - 40px);
 height: 70vh;
 padding: 20px;
 margin: auto;
 z-index: 2;
 position: absolute;
 left: 10vw;
 animation: slideRightBack 600ms;
 animation-fill-mode: forwards;
}
.info__right {
 animation: slideRight 600ms;
 animation-fill-mode: forwards;
}
.welcome {
 background-color: var(--mainColor3);
 border-radius: 0 20px 20px 0;
 padding: 20px;
 position: absolute;
 display: flex;
 flex-direction: column;
 margin: 0;
 margin-top: 10vh;
 width: calc(30vw - 40px);
 right: 10vw;
 animation: slideLeftBack 400ms;
 animation-fill-mode: forwards;
 height: 50vh;
}
.welcome__left {
 animation: slideLeft 400ms;
 animation-fill-mode: forwards;
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
