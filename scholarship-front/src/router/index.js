import { createRouter, createWebHistory } from "vue-router";
import EntryPage from "../views/Entry/EntryPage";
import { useLoginStore } from "@/store/useLoginStore";

const routes = [
 {
  path: "/login",
  name: "login",
  component: EntryPage,
 },
];

const router = createRouter({
 history: createWebHistory(process.env.BASE_URL),
 routes,
});
router.beforeEach(function (to, from, next) {
 const store = useLoginStore().$state;
 const logedIn = store.logIn;
 if (to.path !== "/login" && to.path !== "login" && !logedIn) {
  next({ path: "/login" });
 } else if ((to.path === "/login" || to.path === "login") && logedIn) {
  next({ path: "/" });
 } else {
  next();
 }
});

export default router;
