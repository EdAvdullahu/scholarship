<template>
  <div>
    <the-navigation></the-navigation>
    <div class="main-holder"><router-view></router-view></div>
  </div>
</template>

<script>
import TheNavigation from "@/components/navigation/TheNavigation.vue";
export default {
  name: "MainVue",
  components:{
    TheNavigation
  }
}
</script>

<style scoped>
.main-holder{
  margin-top: 75px;
}
</style>