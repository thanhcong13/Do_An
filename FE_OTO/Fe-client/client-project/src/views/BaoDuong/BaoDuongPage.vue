<template>
  <h1 class="text-center" style="margin-top:85px;">Thông tin bảo dưỡng</h1>
  <v-item-group style="margin: 0 auto; min-height:420px" mandatory>
    <v-container class="fill-height">
      <v-row class="d-flex justify-center align-center w-50">
        <v-col cols="12">
          <v-row class="d-flex justify-center align-center">
            <v-col cols="3">
              <span class="mr-2">Tên khách hàng</span>
              <input
                class="w-100 input_lienhe"
                type="text"
                v-model="tenKH"
                placeholder="Nhập tên"
              />
            </v-col>
            <v-col cols="3">
              <span class="float-left">Tên sản phẩm</span>
              <input class="w-100 input_lienhe" type="text" v-model="tenSP" />
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
              <span class="mr-2">Ngày Bảo dưỡng</span>
              <VueDatePicker
                :min-date="new Date()"
                v-model="ngayBD"
                class="d-picked"
                :enable-time-picker="false"
              ></VueDatePicker>
            </v-col>
          </v-row>
        </v-col>
        <v-col cols="12">
          <v-row class="d-flex justify-center align-center">
            <v-col cols="3" style="height:90px">
              <span class="mr-2">Tên cửa hàng</span>
              <v-combobox
              v-model="tenCH"
                :items="listCH"
                variant="solo"
              ></v-combobox>
            </v-col>
            <v-col cols="3" style="margin-top:12px">
              <span class="mr-2">Email</span>
              <input
                class="w-100 input_lienhe" style="padding: 14px"
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
              <v-btn @click="onClickSend()">Gửi</v-btn>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
  </v-item-group>
</template>

<script setup>
import { ref, onMounted } from "vue";
import { useRouter } from "vue-router";
import axios from "axios";
const listCH = ref([]);
const router = useRouter();
const getAllCH = async () => {
  const res = await axios.get("http://localhost:5222/api/SanPham/GetAllCH");
  listCH.value = res.data.innerBody.map((item) => item.TenCH);
};
const tenKH = ref("");
const emailKH = ref("");
const sDTKH = ref("");
const tenSP = ref("");
const ngayBD = ref(Date);
const tenCH = ref("");
onMounted(() => {
  getAllCH();
});

const onClickSend = async () => {
  const entity = {
    tenKH: tenKH.value,
    emailKH: emailKH.value,
    sDTKH: sDTKH.value,
    tenSP: tenSP.value,
    ngayBD: ngayBD.value,
    tenCH: tenCH.value
  }
  const res = await axios.post('http://localhost:5222/api/BaoDuong/Post', entity)
  localStorage.removeItem(`TenSP`);
  router.push("/thankspage");
}
</script>

<style>
.input_lienhe {
  outline: none;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
  
}
</style>
