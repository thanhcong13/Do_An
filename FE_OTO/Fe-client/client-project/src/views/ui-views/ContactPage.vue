<template>
  <div class="bg-img text-center">
    <h1 class="title_posi">Liên hệ với chúng tôi</h1>
    <span class="content_posi">
      Cảm ơn bạn đã quan tâm đến TDTravel của chúng tôi. Để được hỗ trợ dịch vụ
      tốt nhất hãy liên hệ với chúng tôi theo thông tin bên dưới
    </span>
  </div>
  <v-container>
    <v-row class="mt-4">
      <v-col cols="4">
        <v-row>
          <v-col cols="12">
            <h1 class="header-contact">Trường đại học đại nam</h1>
          </v-col>
        </v-row>
        <v-row class="d-flex justify-center align-center">
          <v-col cols="2">
            <v-icon class="color-icon text-white">mdi-home-assistant</v-icon>
          </v-col>
          <v-col cols="10" class="font-title">
            Số 1 P. Xốm, Phú Lâm, Hà Đông, Hà Nội</v-col
          >
        </v-row>
        <v-row class="d-flex justify-center align-center">
          <v-col cols="2">
            <v-icon class="color-icon text-white">mdi-phone-check</v-icon>
          </v-col>
          <v-col cols="10" class="font-title"> 024 3557 7799</v-col>
        </v-row>
      </v-col>
      <v-col cols="8">
        <a
          href="https://www.google.com/maps/dir/20.2068416,105.8642597/%C4%91%E1%BA%A1i+h%E1%BB%8Dc+%C4%91%E1%BA%A1i+nam/@20.5766064,105.5480363,10z/data=!3m1!4b1!4m9!4m8!1m1!4e1!1m5!1m1!1s0x313452eaa9c461c3:0x2a3e1c421f299adc!2m2!1d105.7577885!2d20.9476712"
        >
          <img class="w-100" src="@/assets/images/img-contact.png" alt="" />
        </a>
      </v-col>
    </v-row>
  </v-container>
</template>
<style>
.bg-img {
  height: 80vh;
  background: linear-gradient(rgba(64, 6, 97, 0.4), rgba(64, 6, 97, 0.4)),
    url("@/assets/images/bg/review-tam-dao-3.jpg") center / cover no-repeat;
  position: relative;
}
.title_posi {
  position: absolute;
  top: 26%;
  left: 36%;
  font-size: 40px;
  text-transform: uppercase;
  color: #f0987c;
}
.content_posi {
  position: absolute;
  top: 40%;
  left: 15%;
  font-size: 20px;
  color: white;
}
.header-contact {
  text-transform: uppercase;
  font-size: 22px;
  color: #f0987c;
}
.color-icon {
  padding: 20px;
  background-color: #f0987c;
  border-radius: 8px;
}
.font-title {
  font-size: 18px;
}
</style>
