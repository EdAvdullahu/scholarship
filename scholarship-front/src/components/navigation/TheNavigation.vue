<template>
 <div class="navigation">
  <div class="navigation-route">SPMS > {{ route }}</div>
 </div>
</template>

<script>
export default {
 name: "TheNavigation",
 computed: {
  route() {
   let route = this.$route.name;
   return route;
  },
 },
};
</script>

<style scoped>
@import "@/assets/Variables.css";
.navigation {
 display: flex;
 flex-direction: row;
 margin: 0;
 width: calc(100vw - 120px);
 height: 70px;
 background-color: var(--mainColor3);
 top: 0;
}
.navigation-route {
 display: flex;
 flex-direction: row;
 padding-left: 50px;
 color: var(--mainColor5);
}
</style>
