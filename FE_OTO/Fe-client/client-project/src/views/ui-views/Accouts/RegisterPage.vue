<script setup>
import { ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";

const router = useRouter();

const username = ref("");
const password = ref("");
const fullName = ref("");
const email = ref("");
const address = ref("");
const phone = ref("");
const register = async () => {
  try {
    const res = await axios.post(`http://localhost:8080/api/auth/signup`, {
      username: username.value,
      password: password.value,
      fullName: fullName.value,
      email: email.value,
      address: address.value,
      phone: phone.value,
    });
    console.log(res.data);
    if (res != null) {
      router.push("/login");
    }
  } catch (error) {
    console.log(error);
  }
};
</script>
<template>
  <div class="bg-img">
    <v-container class="form-posi h-100">
      <div class="form-sign-up w-75 pa-5">
        <h2 class="text-center heading-login py-4">
          Đăng ký để sử dụng dịch vụ của chúng tôi
        </h2>
        <v-row>
          <v-col cols="6">
            <span>Tài khoản</span>
            <input
              class="w-100 input-login"
              type="text"
              v-model="username"
              placeholder="Nhập tài khoản"
            />
          </v-col>
          <v-col cols="6">
            <span>Họ và tên</span>
            <input
              class="w-100 input-login"
              type="text"
              v-model="fullName"
              placeholder="Họ và tên"
            />
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="6">
            <span>Mật khẩu</span>
            <input
              class="w-100 input-login"
              type="password"
              placeholder="Nhập mật khẩu"
              name=""
              v-model="password"
              id=""
            />
          </v-col>
          <v-col cols="6">
            <span>Email</span>
            <input
              class="w-100 input-login"
              placeholder="Nhập đúng định dạng email"
              type="email"
              v-model="email"
            />
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="6">
            <span>Số điện thoại</span>
            <input
              class="w-100 input-login"
              type="text"
              placeholder="Nhập số điện thoại"
              name=""
              v-model="phone"
              id=""
            />
          </v-col>
          <v-col cols="6">
            <span>Địa chỉ</span>
            <input
              class="w-100 input-login"
              placeholder="Nhập địa chỉ"
              type="email"
              v-model="address"
            />
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="12">
            <button @click="register" class="btn-rigis">Đăng ký</button>
          </v-col>
          <v-col cols="12" class="text-center">
            <span> Bạn đã có tài khoản ? đăng nhập</span>
            <a href="/login"> tại đây</a>
          </v-col>
        </v-row>
      </div>
    </v-container>
  </div>
</template>
<style>
.bg-img {
  background: linear-gradient(rgba(64, 6, 97, 0.4), rgba(64, 6, 97, 0.4)),
    url(@/assets/images/bg/bg.jpg) top center / cover no-repeat;
  height: 100vh;
}
.input-login {
  border-radius: 20px !important;
  outline: none;
  width: 100%;
  padding: 8px;
  color: black;
  background-color: #a3bee2;
}
::placeholder {
  color: white;
}
.form-posi {
  position: relative;
}
.form-sign-up {
  background-color: white;
  position: absolute;
  top: 16%;
  left: 10%;
  border-radius: 14px;
  box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
}
.heading-login {
  line-height: 40px;
  text-transform: uppercase;
}
.btn-rigis {
  width: 100%;
  padding: 8px;
  background-color: aqua;
  border-radius: 20px;
}
</style>
