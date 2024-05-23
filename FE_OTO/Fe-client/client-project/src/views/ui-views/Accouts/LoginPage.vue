<script setup>
import { ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";

const router = useRouter();

const username = ref("");
const password = ref("");
const login = async () => {
  try {
    const res = await axios.post(
      `http://localhost:8080/api/auth/signinclient`,
      {
        username: username.value,
        password: password.value,
      }
    );
    console.log(res.data);
    if (res != null) {
      router.push("/");
      localStorage.setItem(`id`, res.data.id);
      localStorage.setItem(`token`, res.data.accessToken);
      localStorage.setItem(`username`, res.data.username);
      localStorage.setItem(`email`, res.data.email);
    }
  } catch (error) {
    console.log(error);
  }
};
</script>
<template>
  <div class="bg-img">
    <v-container class="container">
      <div class="row justify-center">
        <div class="col-md-6 col-lg-4">
          <div class="login-wrap pa-0 mt-16">
            <h2 class="mb-4 text-white mt-6 text-center">Đăng nhập hệ thống</h2>
            <div class="d-flex justify-center">
              <v-form class="w-25 mt-16" @submit.prevent="login">
                <div class="form-group mt-6">
                  <input
                    class="input-login pa-3 mb-4"
                    type="text"
                    v-model="username"
                    placeholder="Username"
                    required
                  />
                </div>
                <div class="form-group">
                  <input
                    class="input-login pa-3"
                    type="password"
                    v-model="password"
                    placeholder="Password"
                    required
                  />
                </div>
                <div class="form-group w-100 mt-5">
                  <v-btn type="submit" class="w-100 pa-2"> Login </v-btn>
                </div>
                <div class="mt-4">
                  <span class="rg_content">Đăng ký tài khoản </span>
                  <a class="rg_link" href="/register">tại đây</a>
                </div>
              </v-form>
            </div>
          </div>
        </div>
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
  color: white;
  background-color: rgba(144, 126, 154, 0.4);
}
::placeholder {
  color: white;
}
.rg_content {
  font-size: 20px;
}
.rg_link {
  font-size: 20px;
  color: #ee8a6a;
  font-weight: 600;
}
</style>
