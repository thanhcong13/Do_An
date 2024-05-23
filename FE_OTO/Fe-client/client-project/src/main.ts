import { createApp } from "vue";
import App from "./App.vue";
// import router from "./router";
import router from "./router";
import vuetify from "./plugins/vuetify";
import "@/scss/style.scss";
import "@vuepic/vue-datepicker/dist/main.css";
import VueDatePicker from "@vuepic/vue-datepicker";

// import Lightbox from "@morioh/v-lightbox";

const app = createApp(App);
app.component("VueDatePicker", VueDatePicker);
app.use(router);
app.use(vuetify).mount("#app");
