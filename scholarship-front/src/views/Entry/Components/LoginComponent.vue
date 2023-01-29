<template>
 <div class="main-login">
  <div>
   <span>Log In</span>
  </div>
  <div>
   <el-form
    ref="ruleFormRef"
    :model="ruleForm"
    status-icon
    :rules="rules"
    label-width="120px"
    class="demo-ruleForm"
   >
    <el-form-item label="Email" prop="email">
     <el-input v-model="ruleForm.email" type="email" autocomplete="off" />
    </el-form-item>
    <el-form-item label="Password" prop="password">
     <el-input v-model="ruleForm.password" type="password" autocomplete="off" />
    </el-form-item>
    <el-form-item>
     <el-button type="primary" @click="submitForm(this.$refs.ruleFormRef)"
      >Login</el-button
     >
    </el-form-item>
   </el-form>
  </div>
 </div>
</template>
<script>
import { mapStores } from "pinia";
import { useLoginStore } from "@/store/useLoginStore";
import { ElLoading, ElMessage } from "element-plus";
import { API_ENDPOINTS } from "../../../common/api/Endpoints";
import callApi from "../../../common/api/ApiCall";
import { setCookie } from "@/common/services/utilities.service";
export default {
 data() {
  return {
   loading: false,
   oppen: true,
   ruleForm: {
    email: "",
    password: "",
   },
   rules: {
    email: [
     { validator: this.validateEmail, trigger: "blur" },
     {
      type: "email",
      message: "Please input a valid email address",
      trigger: ["blur", "change"],
     },
    ],
    password: [{ validator: this.validatePassword, trigger: "blur" }],
   },
  };
 },
 methods: {
  validateEmail(rule, value, callback) {
   if (!value) {
    return callback(new Error("Please input an Email."));
   } else if (value.includes(" ")) {
    return callback(new Error("Please enter a valid Email"));
   } else {
    callback();
   }
  },
  validatePassword(rule, value, callback) {
   if (!value) {
    return callback(new Error("Please input a password."));
   } else if (value.includes(" ") || value.length < 8) {
    return callback(new Error("Please enter a valid password"));
   } else {
    callback();
   }
  },
  submitForm(form) {
   form.validate((valid) => {
    if (valid) {
     const load = ElLoading.service({
      lock: true,
      text: "Loading...",
      background: "rgba(0, 0, 0, 0.7)",
     });
     let user = {
      email: this.ruleForm.email,
      password: this.ruleForm.password,
     };
     callApi
      .noAuth(API_ENDPOINTS.USER.USER_LOGIN(), user)
      .then((res) => {
       console.log(res);
       if (res.status !== 200) {
        ElMessage.error("Bad Request");
        return;
       } else {
        ElMessage({
         message: "user loged in successfully",
         type: "success",
        });
       }
       return res;
      })
      .then((res) => {
       this.loginStore.logIn(res.data);
       setCookie("token", res.data.token);
       setCookie("role", res.data.role);
       setCookie("name", res.data.name);
       setCookie("email", res.data.email);
      })
      .catch((error) => {
       ElMessage.error(error.response.data);
      })
      .finally(() => {
       load.close();
       this.goHome();
      });
    } else {
     return false;
    }
   });
  },
  goHome() {
   this.$router.push("/home");
  },
 },
 computed: {
  ...mapStores(useLoginStore),
 },
};
</script>

<style scoped>
@import "@/assets/Variables.css";
.main-login {
 display: flex;
 flex-direction: column;
}
</style>
