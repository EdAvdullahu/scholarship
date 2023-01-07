import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import { createPinia } from "pinia";

const pinia = createPinia();
pinia.use(({ store }) => {
 store.$subscribe((mutations) => {
  localStorage.setItem(mutations.events.key, mutations.events.newValue);
 });
});

const app = createApp(App);
app.use(ElementPlus);
app.use(pinia);
app.use(router);
app.mount("#app");
