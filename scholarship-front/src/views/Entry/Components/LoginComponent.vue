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
    <el-form-item prop="email">
     <el-input
      v-model="ruleForm.email"
      placeholder="Email"
      type="email"
      autocomplete="off"
     />
    </el-form-item>
    <el-form-item prop="password">
     <el-input
      v-model="ruleForm.password"
      placeholder="Password"
      type="password"
      autocomplete="off"
     />
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
       console.log(error);
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
span {
 font-weight: 900;
 font-style: italic;
 font-size: 1.7rem;
 font-family: "Italiana", serif;
 color: var(--mainColor2);
}
.main-login :nth-child(2) :first-child :first-child {
 color: var(--mainColor4) !important;
}
.main-login :nth-child(2) :first-child :first-child button {
 width: 100px;
 border-radius: 50rem;
 color: var(--mainColor8);
 background-color: var(--mainColor2);
 outline: none;
 border: none;
}
.main-login :nth-child(2) :first-child :first-child button :first-child {
 color: var(--mainColor8) !important;
 font-style: italic;
 font-size: 1.4rem;
 font-family: "Italiana", serif;
 font-weight: 800;
}

.main-login
 :nth-child(2)
 :first-child
 :first-child
 :first-child
 :first-child
 :first-child {
 border-radius: 50rem;
 color: var(--mainColor8) !important;
 background-color: var(--mainColor4);
 outline: none;
 border: none;
}
.main-login
 :nth-child(2)
 :first-child
 :nth-child(2)
 :first-child
 :first-child
 :first-child {
 border-radius: 50rem;
 color: var(--mainColor8) !important;
 background-color: var(--mainColor4);
 outline: none;
 border: none;
}

.main-login
 :nth-child(2)
 :first-child
 :nth-child(2)
 :first-child
 :first-child
 :first-child::-webkit-input-placeholder,
.main-login
 :nth-child(2)
 :first-child
 :first-child
 :first-child
 :first-child
 :first-child::-webkit-input-placeholder {
 color: var(--mainColor8);
}
.main-login
 :nth-child(2)
 :first-child
 :nth-child(2)
 :first-child
 :first-child
 :first-child::-moz-placeholder,
.main-login
 :nth-child(2)
 :first-child
 :first-child
 :first-child
 :first-child
 :first-child::-moz-placeholder {
 color: var(--mainColor8);
}
.main-login
 :nth-child(2)
 :first-child
 :nth-child(2)
 :first-child
 :first-child
 :first-child:-ms-input-placeholder,
.main-login
 :nth-child(2)
 :first-child
 :first-child
 :first-child
 :first-child
 :first-child:-ms-input-placeholder {
 color: var(--mainColor8);
}
</style>
