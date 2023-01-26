import { createRouter, createWebHistory } from "vue-router";
import EntryPage from "@/views/Entry/EntryPage";
import HomeView from '@/views/Home/HomeView.vue';
import BaseView from "@/views/BaseView.vue";
import { useLoginStore } from "@/store/useLoginStore";

const routes = [
 {
  path: "/entry",
  name: "entry",
  component: EntryPage,
 },
 {
  path: '/',
  name: 'base',
  component: BaseView,
  children:[
   {
    path: "/home",
    name: 'home',
    component: HomeView
   }
  ]
 }
];

const router = createRouter({
 history: createWebHistory(process.env.BASE_URL),
 routes,
});
router.beforeEach(function (to, from, next) {
 const store = useLoginStore().$state;
 const loggedIn = store.login;
 if (to.path !== "/entry" && to.path !== "entry" && !loggedIn) {
  console.log("login not changed")
  next({ path: "/entry" });
 } else if ((to.path === "/entry" || to.path === "entry") && loggedIn) {
  next({ path: "/home" });
 } else {
  next();
 }
});

export default router;
