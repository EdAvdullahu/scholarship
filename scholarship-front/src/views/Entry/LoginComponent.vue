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
     this.loading = true;
     console.log("true");
     this.loginStore.logIn().then(() => {
      this.loading = false;
      console.log("false");
     });
    } else {
     return false;
    }
   });
  },
 },
 computed: {
  ...mapStores(useLoginStore),
 },
};
</script>

<style scoped>
@import "../../assets/Variables.css";
.main-login {
 display: flex;
 flex-direction: column;
}
.demo-ruleForm > .el-form-item__label {
 color: red;
}
</style>
