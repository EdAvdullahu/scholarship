<template>
 <div class="uni-vew">
  <div class="search-holder">
   <input type="text" placeholder="search" v-model="search" />
  </div>
  <br />
  <div class="universitites">
   <the-university
    v-for="uni in this.unies"
    :key="uni.id"
    unies
    :description="uni.description"
    :id="uni.id"
    :name="uni.universityName"
   ></the-university>
   <div class="uni-more-info">
    <router-view></router-view>
   </div>
  </div>
 </div>
</template>

<script>
import ApiCall from "@/common/api/ApiCall";
import { API_ENDPOINTS } from "@/common/api/Endpoints";
import { ElLoading } from "element-plus";
import TheUniversity from "./components/TheUniversity.vue";

export default {
 components: { TheUniversity },
 name: "UniversitisView",
 data() {
  return {
   search: "",
   Universities: [],
  };
 },
 computed: {
  unies() {
   return this.Universities.filter(
    (data) =>
     !this.search ||
     data.universityName.toLowerCase().includes(this.search.toLowerCase()) ||
     data.description.toLowerCase().includes(this.search.toLowerCase())
   );
  },
 },
 beforeMount() {
  const load = ElLoading.service({
   lock: true,
   text: "Loading...",
   background: "rgba(0, 0, 0, 0.7)",
  });
  ApiCall.get(API_ENDPOINTS.UNIVERSITY.NULL())
   .then((res) => {
    this.Universities = res.data;
   })
   .then(() => {
    load.close();
   });
 },
};
</script>

<style scoped>
.uni-vew {
 display: flex;
 flex-direction: column;
 margin-bottom: 50px;
}
</style>
