<script setup></script>
<template>
  <v-container>
    <v-row class="text-center thanks-page" style="margin-top:70px;">
      <div class="h-100 d-flex justify-content-center align-items-center">
        <div class="col-md-4 mt-2">
          <div class="border border-3 border-success"></div>
          <div class="card bg-white shadow p-5">
            <div class="mb-4 text-center">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                class="text-success mt-2"
                width="75"
                height="75"
                fill="currentColor"
                viewBox="0 0 16 16"
              >
                <path
                  d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"
                />
                <path
                  d="M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z"
                />
              </svg>
            </div>
            <div class="text-center">
              <h1 class="text-h2">Thank You !</h1>
              <p class="text-h6 mt-5 pa-2">
                Chúng tôi sẽ liên hệ với bạn sớm nhất có thể
              </p>
              <v-btn to="/home" class="btn-gohome my-5">Back Home</v-btn>
            </div>
          </div>
        </div>
      </div>
    </v-row>
  </v-container>
</template>
<style>
.thanks-page {
  height: 80vh;
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
}
.btn-gohome {
  padding: 6px;
  border-radius: 4px;
  border: 1px solid #ee8a6a;
  color: #05b187;
}
</style>
