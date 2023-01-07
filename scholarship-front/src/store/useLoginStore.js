import { defineStore } from "pinia";
import { API_ENDPOINTS } from "@/common/api/Endpoints";
import { callApi } from "@/common/api/ApiCall";
export const useLoginStore = defineStore("login", {
 state() {
  return {
   current: {},
   login: false,
  };
 },
 actions: {
  async logIn(payload) {
   console.log("payload      " + payload);
   callApi(API_ENDPOINTS.USER)
    .fetchAll()
    .then((result) => {
     if (result.status === 200) {
      this.login = true;
      this.current = result.data;
     }
    });
  },
 },
});
