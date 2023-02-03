<template>
 <div class="main">
  <div style="grid-area: header"><the-navigation></the-navigation></div>
  <div style="grid-area: nav; z-index: 10"><the-header></the-header></div>
  <div class="content">
   <div class="back-color">
    <router-view></router-view>
    <the-welcome></the-welcome>
    <the-footer></the-footer>
   </div>
  </div>
 </div>
</template>

<script>
import TheNavigation from "@/components/navigation/TheNavigation.vue";
import TheHeader from "@/components/header/TheHeader.vue";
import TheFooter from "@/components/footer/TheFooter.vue";
import TheWelcome from "../components/welcome/TheWelcome.vue";
export default {
 name: "MainVue",
 components: {
  TheNavigation,
  TheHeader,
  TheFooter,
  TheWelcome,
 },
};
</script>

<style scoped>
.main {
 margin: 0;
 padding: 0;
 left: 0;
 display: grid;
 grid-template-areas: "nav header" "nav main";
}
.back-color {
 padding: 30px;
 background: var(--mainColor3);
 background: linear-gradient(var(--mainColor3), var(--mainColor1));
}
.content {
 grid-area: main;
 max-width: calc(100vw - 120px);
 max-height: calc(100vh - 70px);
 overflow-y: scroll;
 overflow-x: hidden;
}
::-webkit-scrollbar {
 width: 6px;
}

/* Track */
::-webkit-scrollbar-track {
 background: gainsboro;
 border-radius: 5px;
}

/* Handle */
::-webkit-scrollbar-thumb {
 background: black;
 border-radius: 5px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
 background: #555;
}
</style>
