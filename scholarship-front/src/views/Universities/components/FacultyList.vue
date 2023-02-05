<template>
 <el-dialog
  title="Faculties"
  :model-value="this.oppen"
  width="80%"
  :before-close="handleClose"
  center
  :destroy-on-close="true"
  v-if="this.oppen"
 >
  <div class="fac-list">
   <div class="fac-item" v-for="fac in faculties" :key="fac.id">
    <div>{{ fac.facultyName }}</div>
    <div>{{}}</div>
   </div>
  </div>
 </el-dialog>
</template>

<script>
import ApiCall from "../../../common/api/ApiCall";
import { API_ENDPOINTS } from "../../../common/api/Endpoints";
export default {
 props: ["uniIndex"],
 data() {
  return {
   oppen: true,
   faculties: [],
  };
 },
 methods: {
  handleClose() {
   this.$router.go(-1);
  },
 },
 beforeMount() {
  ApiCall.get(API_ENDPOINTS.UNIVERSITY.UNIVERSITY_FACULTY_ID(this.uniIndex))
   .then((res) => {
    this.faculties = res.data;
   })
   .then(() => {
    console.log("it's called", this.faculties);
   });
 },
};
</script>
