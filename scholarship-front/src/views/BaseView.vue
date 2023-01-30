<template>
 <div class="main">
  <div style="grid-area: header"><the-navigation></the-navigation></div>
  <div style="grid-area: nav; z-index: 10"><the-header></the-header></div>
  <div class="content">
   <router-view></router-view>
   <the-footer></the-footer>
  </div>
 </div>
</template>

<script>
import TheNavigation from "@/components/navigation/TheNavigation.vue";
import TheHeader from "@/components/header/TheHeader.vue";
import TheFooter from "@/components/footer/TheFooter.vue";
export default {
 name: "MainVue",
 components: {
  TheNavigation,
  TheHeader,
  TheFooter,
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
.content {
 grid-area: main;
 padding: 30px;
 width: calc(100vw - 180px);
 height: calc(100vh - 130px);
 background: var(--mainColor3);
 background: linear-gradient(var(--mainColor3), var(--mainColor2));
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
