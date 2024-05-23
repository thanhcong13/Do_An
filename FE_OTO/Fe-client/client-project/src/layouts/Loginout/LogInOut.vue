<script setup lang="ts">
import { ref } from "vue";
import LogInOutItem from "./LogInOutItem";
import { useRouter } from "vue-router";
const navItem = ref(LogInOutItem);
const router = useRouter();
const username = localStorage.getItem("username");
const logOut = () => {
  router.push("/login");
  window.localStorage.removeItem("username");
  window.localStorage.removeItem("token");
};
</script>
<template>
  <div class="d-flex justify-center float-right">
    <v-list class="pl-16 ml-16 d-flex justify-center" v-if="!username">
      <!-- <template v-for="(item, i) in navItem" :key="i">
        <v-list-item :to="item.to" rounded="lg" class="mb-1 mr-2">
          <v-list-item-avatar start class="v-list-item-avatar--start">
          </v-list-item-avatar>
          <v-list-item-title v-text="item.title"></v-list-item-title>
        </v-list-item>
      </template> -->
    </v-list>
    <div class="float-right mr-4" v-else @submit.prevent="logOut">
      <v-menu open-on-hover>
        <template v-slot:activator="{ props }">
          <v-btn color="black" v-bind="props">Xin chào {{ username }} </v-btn>
        </template>

        <v-list>
          <v-list-item>
            <v-btn class="w-100" to="/accout">{{ username }}</v-btn>
          </v-list-item>
          <v-list-item>
            <v-btn to="/orderlist" class="w-100">Đơn đặt phòng</v-btn>
          </v-list-item>
          <v-list-item>
            <v-btn @click="logOut" type="submit" color="secondary" block
              >Đăng xuất</v-btn
            >
          </v-list-item>
        </v-list>
      </v-menu>
    </div>
  </div>
</template>
<style>
.v-list-item--active {
  background-color: #ee8a6a;
  color: white;
}
</style>
