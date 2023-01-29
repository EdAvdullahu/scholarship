import { defineStore } from "pinia";
export const useLoginStore = defineStore("login", {
 state() {
  return {
   current: {},
   login: false,
  };
 },
 actions: {
  async logIn(payload) {
   console.log("payload:" + JSON.stringify(payload));
   this.current = payload;
   this.login = true;
  },
 },
});
