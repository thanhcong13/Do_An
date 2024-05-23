<template>
  <v-card>
    <v-layout>
      <!-- <v-container> -->
      <v-app-bar class="d-flex justify-space-between" :elevation="0">
        <div class="pa-16 ma-16">
          <RouterLink to="/">
            <img style="width:200px; height:auto;" src="../assets/images/logos/qcs-auto-logo.png" />
          </RouterLink>
        </div>
        <NavigationMenu />
        <LogInOut />
      </v-app-bar>
      <!-- </v-container> -->
      <v-main  class="po-r">
        <RouterView />
        <v-footer class="bg-black po-a">
          <v-container>
            <v-row class="d-flex">
              <v-col cols="3">
                <img class="img-footer" style="width:180px; height:auto; background-color:white" src="../assets/images/logos/qcs-auto-logo.png" alt="" />
                <v-row class="d-flex mt-2">
                  <v-col class="pa-0 mx-1">
                    <v-icon class="icon-footer">mdi-facebook</v-icon>
                  </v-col>
                  <v-col class="pa-0 mx-1">
                    <v-icon class="icon-footer">mdi-twitter</v-icon>
                  </v-col>
                  <v-col class="pa-0 mx-1">
                    <v-icon class="icon-footer">mdi-instagram</v-icon>
                  </v-col>
                  <v-col class="pa-0 mx-1">
                    <v-icon class="icon-footer">mdi-web</v-icon>
                  </v-col>
                </v-row>
              </v-col>
              <v-col cols="3">
                <h3 class="heading-footer">Truy cập nhanh</h3>
                <v-row class="flex-column mt-2">
                  <v-col class="item-link" cols="12">
                    <a href="/products">Sản phẩm</a>
                  </v-col>
                  <v-col class="item-link" cols="12">
                    <a href="/blog">Bài viết</a>
                  </v-col>
                  <v-col class="item-link" cols="12">
                    <a href="/baoduong">Bảo dưỡng</a>
                  </v-col>
                </v-row>
              </v-col>
              <v-col cols="3">
                <h3>Liên hệ</h3>
                <v-row class="flex-column mt-2">
                  <v-col class="item-link" cols="12">
                    <a href="/#">Tel:024 3557 7799</a>
                  </v-col>
                  <v-col class="item-link" cols="12">
                    <a href="/gmail.com.vn"> congthanh@gmail.com</a>
                  </v-col>
                </v-row>
              </v-col>
              <v-col cols="3">
                <h3>Địa chỉ</h3>
                <v-row class="flex-column mt-2">
                  <v-col class="item-link" cols="12">
                    <a href="/#">Phùng Khoang,Hà Đông, Hà Nội</a>
                  </v-col>
                  <v-col class="item-link po-re" cols="12">
                    <input
                      class="input-email"
                      type="email"
                      placeholder="Nhập email"
                    />
                    <v-icon class="po-ab">mdi-send</v-icon>
                  </v-col>
                </v-row>
              </v-col>
            </v-row>
          </v-container>
        </v-footer>
      </v-main>
    </v-layout>
  </v-card>
</template>

<script setup lang="ts">
import { RouterLink } from "vue-router";
import NavigationMenu from "./NavigationMenu.vue";
import LogInOut from "./Loginout/LogInOut.vue";
</script>
<style>
body{
  font-family: "Montserrat", sans-serif;
}
.v-main{
  padding-top: 0;
}
.v-col{
  flex-grow: unset;

}
.img-footer{
  filter: invert(96%) sepia(99%) saturate(2%) hue-rotate(59deg) brightness(106%) contrast(100%);
}
.icon-footer {
  padding: 20px;
  border-radius: 4px;
  color: #949eb2;
}
.icon-footer:hover {
  background-color: #f0987c;
  color: white;
}
.heading-footer {
  font-size: 20px;
}
.item-link {
  padding: 4px 12px;
}
.item-link a {
  text-decoration: none;
  color: #868c98;
  font-size: 16px;
}
.item-link a:hover {
  color: #dca73a;
  animation: transform 0.2s linear;

  transform: translateX(6px);
}
.input-email {
  outline: none;
  width: 100%;
  padding: 8px 12px;
  background-color: white;
}
.po-re {
  position: relative;
}
.po-ab {
  position: absolute;
  top: 26%;
  right: 6%;
  color: #f0987c;
}
</style>
