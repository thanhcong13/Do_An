<template>
  <h1 class=" text-center" style="margin-top:85px;">Đăng ký lái thử</h1>
  <v-item-group style="margin: 0 auto; min-height: 420px" mandatory>
    <v-container class="fill-height">
      <v-row class="d-flex justify-center align-center w-50">
        <v-col cols="12">
          <v-row class="d-flex justify-center align-center">
            <v-col cols="3">
              <span class="float-left">Tên sản phẩm</span>
              <input class="w-100 input_lienhe" type="text" disabled v-model="tenSP" />
            </v-col>
            <v-col cols="3">
              <span class="mr-2">Tên khách hàng</span>
              <input
                class="w-100 input_lienhe"
                type="text"
                v-model="tenKH"
                placeholder="Nhập tên"
              />
            </v-col>
          </v-row>
        </v-col>
        <v-col cols="12">
          <v-row class="d-flex justify-center align-center">
            <v-col cols="3">
              <span class="mr-2">Số điện thoại</span>
              <input
                class="w-100 input_lienhe"
                type="text"
                v-model="sDTKH"
                placeholder="Nhập số điện thoại"
              />
            </v-col>
            <v-col cols="3">
              <span class="mr-2">Email</span>
              <input
                class="w-100 input_lienhe"
                type="text"
                v-model="emailKH"
                placeholder="Nhập email"
              />
            </v-col>
          </v-row>
        </v-col>
        <v-col cols="12">
          <v-row class="d-flex justify-center align-center">
            <v-col cols="6">
              <span class="mr-2">Ngày lái thử</span>
              <VueDatePicker
                :min-date="new Date()"
                v-model="ngayLT"
                class="d-picked"
                :enable-time-picker="false"
              ></VueDatePicker>
            </v-col>
          </v-row>
        </v-col>
        <v-col cols="12">
          <v-row class="d-flex justify-center align-center">
            <v-col cols="6">
              <v-btn @click="onClickSend()">Gửi</v-btn>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
  </v-item-group>
</template>

<script setup>
import axios from "axios";
import { ref } from "vue";
import { useRouter } from "vue-router";
const router = useRouter();

const tenSP = localStorage.getItem(`TenSP`);
const tenKH = ref("");
const sDTKH = ref("");
const emailKH = ref("");
const ngayLT = ref(Date);
const onClickSend = async () => {
  const entity = {
    tenKH: tenKH.value,
    emailKH: emailKH.value,
    sDTKH: sDTKH.value,
    tenSP: tenSP,
    ngayLT: ngayLT.value
  };
  const res = await axios.post("http://localhost:5222/api/LaiThu/Post", entity);
  localStorage.removeItem(`TenSP`);
  router.push("/thankspage");
};
</script>

<style>
.input_lienhe {
  outline: none;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
</style>
