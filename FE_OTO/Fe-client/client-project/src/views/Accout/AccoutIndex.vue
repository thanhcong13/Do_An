<script setup>
import { onMounted, ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";

const userId = localStorage.getItem("id");
const getInfo = ref([]);
const fullName = ref("");
const phone = ref("");
const address = ref("");
const email = ref("");
const username = ref("");
const router = useRouter();
onMounted(() => {
  getData();
});
const getData = async () => {
  try {
    const res = await axios.get(
      "http://localhost:8080/api/v1/user/getUserById/" + userId
    );
    getInfo.value = res.data;
  } catch (e) {
    console.log(e);
  }
};
const updateInfo = async (data) => {
  try {
    const dataUpdate = {
      fullName: getInfo.value.fullName,
      address: getInfo.value.address,
      phone: getInfo.value.phone,
      email: getInfo.value.email,
      username: getInfo.value.username,
    };
    const update = await axios.put(
      "http://localhost:8080/api/v1/user/update/" + userId,
      dataUpdate
    );
    if (dataUpdate != null) {
      router.push("/accout");
    }
  } catch (e) {
    console.log(e);
  }
};
</script>
<template>
  <v-container>
    <v-row class="w-100 d-flex justify-center">
      <v-col class="w-50" cols="4">
        <h6>Tài khoản</h6>
        <input
          class="w-100 input_info"
          disabled
          v-model="getInfo.username"
          type="text"
        />
      </v-col>
      <v-col class="w-50" cols="4">
        <h6>Họ tên</h6>
        <input
          class="w-100 input_info"
          v-model="getInfo.fullName"
          type="text"
        />
      </v-col>
    </v-row>
    <v-row class="w-100 mt-0 d-flex justify-center">
      <v-col cols="8" class="w-100">
        <h6>Email</h6>
        <input
          disabled
          class="input_info w-100"
          v-model="getInfo.email"
          type="text"
        />
      </v-col>
    </v-row>
    <v-row class="w-100 d-flex justify-center">
      <v-col class="w-50" cols="4">
        <h6>Số điện thoại</h6>
        <input class="w-100 input_info" v-model="getInfo.phone" type="text" />
      </v-col>
      <v-col class="w-50" cols="4">
        <h6>Địa chỉ</h6>
        <input class="w-100 input_info" v-model="getInfo.address" type="text" />
      </v-col>
    </v-row>
    <v-row class="w-100 d-flex justify-end align-center">
      <v-col class="w-50" cols="4">
        <v-btn @click="updateInfo(item)" class="float-center mr-4 btn_update">
          Cập nhật
        </v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>
<style>
.input_info {
  outline: none;
  padding: 6px;
  border: 1px solid #ccc;
  border-radius: 6px;
}
.btn_update {
  padding: 6px;
  border: 1px solid #ccc;
  border-radius: 4px;
  color: white;
  background-color: #ee8a6a;
}
</style>
