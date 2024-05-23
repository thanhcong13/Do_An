<script setup>
import { onMounted, ref } from "vue";
import axios from "axios";
import { useRoute } from "vue-router";
import { Swiper, SwiperSlide } from "swiper/vue";

// Import Swiper styles
import "swiper/css";

import "swiper/css/free-mode";
import "swiper/css/navigation";
import "swiper/css/thumbs";

// import required modules
import { FreeMode, Navigation, Thumbs } from "swiper";

const desserts = ref([]);
const route = useRoute();
const dialog = ref(false);

// let thumbsSwiper = null;
// const setThumbsSwiper = (swiper) => {
//   thumbsSwiper = swiper;
// };
const images = [
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326699205.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
  "https://sdl.xtel.vn/file/v1/download/hotel-product-cover-img/SDL_BKAV_1624326698771.jpg",
];
onMounted(() => {
  getData();
});

const getData = async () => {
  try {
    const res = await axios.get(
      "http://localhost:5222/api/SanPham/GetById?id=" + route.params.id
    );
    desserts.value = res.data.innerBody[0];
    console.log(desserts.value);
  } catch (e) {
    console.error(e);
  }
};
</script>
<template>
  <v-car>
    <v-container>
      <v-row class="bg-yellow-lighten-5 pa-0 ma-0 mb-3">
        <v-col cols="4">
          <h2 style="width: 60%" class="header-hv">{{ desserts.TenSP }}</h2>
        </v-col>

        <img class="w-100" :src="`${desserts.image}`" alt="" />
      </v-row>
      <v-toolbar class="mb-4 bg-yellow-lighten-4">
        <v-row>
          <v-col col="4">
            <span>Type: </span>
            <span style="color: #ee8a6a; font-weight: 600">{{
              desserts.hotelType
            }}</span>
          </v-col>
          <v-col col="4">
            <span> Rated: </span>
            <span style="color: #ee8a6a; font-weight: 600"
              >{{ desserts.rated }} stars</span
            >
          </v-col>
          <v-col col="4">
            <span> Phone number: </span>
            <span style="color: #ee8a6a; font-weight: 600">{{
              desserts.phone
            }}</span>
          </v-col>
          <v-col col="4">
            <span> Email: </span>
            <span style="color: #ee8a6a; font-weight: 600">{{
              desserts.email
            }}</span>
          </v-col>
        </v-row>
      </v-toolbar>
      <v-row class="bg-yellow-lighten-5 ma-0">
        <v-col cols="6">
          <div class="float-left">
            <h2>General introduction</h2>
            <span>{{ desserts.description }}</span>
          </div>
        </v-col>
      </v-row>
      <v-row class="bg-amber-lighten-5 ma-0 mt-4">
        <v-col cols="12">
          <div class="">
            <h3>Tiện nghi</h3>
            <v-row
              class="w-100 d.flex justify-space-between align-center"
              v-if="desserts.service"
            >
              <v-col
                class="text-center md-4 lg-4 w-100"
                cols="2"
                v-for="item in desserts.service.split(',')"
                :key="item"
              >
                <span class="item_service">{{ item }}</span>
              </v-col>
            </v-row>
            <v-row v-else>
              <v-col cols="12">
                <span>Đang cập nhật</span>
              </v-col>
            </v-row>
          </div>
        </v-col>
      </v-row>
      <div v-for="item in desserts.rooms" :key="item.id">
        <v-row
          class="bg-blue-grey-lighten-5 ma-0 mt-6 mb-6"
          v-if="item.status === true"
        >
          <v-col cols="3">
            <img
              style="width: 100%; height: auto"
              :src="`${item.image}`"
              alt=""
            />
          </v-col>
          <v-col
            cols="9"
            class="col-10 pt-10 pb-10 d-flex justify-space-between"
          >
            <div>
              <h3 class="pt-3 pb-3" style="color: #ee8a6a; font-size: 28px">
                Bed type: {{ item.bedType }}
              </h3>
              <span>Capactity: {{ item.capacity }}m²</span>
              <div>
                <span style="font-size: 28px; color: rgb(73 190 110)">{{
                  item.price
                }}</span>
                <span> VND/night</span>
              </div>
            </div>
            <div>
              <v-btn :to="`/hotels/${route.params.id}/${item.id}`"
                >Đặt phòng</v-btn
              >
            </div>
          </v-col>
        </v-row>
        <v-dialog v-model="dialog" class="w-75">
          <v-card>
            <swiper
              :style="{
                '--swiper-navigation-color': '#fff',
                '--swiper-pagination-color': '#fff',
              }"
              :spaceBetween="10"
              :navigation="true"
              :thumbs="{ swiper: thumbsSwiper }"
              :modules="modules"
              class="mySwiper2"
            >
              <swiper-slide
                v-for="(img, index) in desserts.image?.split(',')"
                :key="index"
                ><img style="width: 100%; height: 400px" :src="img"
              /></swiper-slide>
            </swiper>
            <swiper
              @swiper="setThumbsSwiper"
              :spaceBetween="10"
              :slidesPerView="4"
              :freeMode="true"
              :watchSlidesProgress="true"
              :modules="modules"
              class="mySwiper"
            >
              <swiper-slide
                v-for="(img, index) in desserts.image?.split(',')"
                :key="index"
                ><img style="width: 100%; height: 80px" :src="img" />
              </swiper-slide>
            </swiper>
            <v-card-actions>
              <v-btn color="primary" block @click="dialog = false"
                >Close Dialog</v-btn
              >
            </v-card-actions>
          </v-card>
        </v-dialog>
      </div>
    </v-container>
  </v-car>
</template>
<style>
.header-hv:hover {
  color: #ee8a6a;
  cursor: pointer;
}

.img__grid {
  display: grid;
  width: calc(100% - 2.4rem);
  grid-template: repeat(6, 1fr) / 40% repeat(3, 20%);
  grid-gap: 0.4rem;
  gap: 0.4rem;
}

.overview-img__grid-item:first-child {
  grid-row: 1 / span 3;
}

.overview-img__grid-item:nth-child(2) {
  grid-row: 4 / span 3;
}

.overview-img__grid-item:nth-child(3) {
  grid-column: 2 / span 3;
  grid-row: 1 / span 4;
}

.overview-img__grid-item:nth-child(1n + 4) {
  grid-row-end: span 2;
  grid-column-end: span 1;
}

.overview-img__grid-item {
  position: relative;
  cursor: pointer;
}

.overview-img__grid-num {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(36, 36, 36, 0.5);
  color: #fff;
  font-size: 1.5rem;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  align-items: center;
  justify-content: center;
}
.img-fit {
  object-fit: cover !important;
}
#app {
  height: 100%;
}
html,
body {
  position: relative;
  height: 100%;
}

body {
  background: #eee;
  font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
  font-size: 14px;
  color: #000;
  margin: 0;
  padding: 0;
}

.swiper {
  width: 100%;
  height: 100%;
}

.swiper-slide {
  text-align: center;
  font-size: 18px;
  background: #fff;

  /* Center slide text vertically */
  display: flex;
  justify-content: center;
  align-items: center;
}

.swiper-slide img {
  display: block;
  width: 100%;
  height: 100%;
  object-fit: cover;
}

body {
  background: #000;
  color: #000;
}

.swiper {
  width: 100%;
  height: 800px;
  margin-left: auto;
  margin-right: auto;
}

.swiper-slide {
  background-size: cover;
  background-position: center;
}

.mySwiper2 {
  height: 60%;
  width: 100%;
}

.mySwiper {
  height: 80%;
  box-sizing: border-box;
  padding: 10px 0;
}

.mySwiper .swiper-slide {
  width: 25%;
  height: 100%;
  opacity: 0.4;
}

.mySwiper .swiper-slide-thumb-active {
  opacity: 1;
}

.swiper-slide img {
  display: block;
  width: 100%;
  height: 100%;
  object-fit: cover;
}
.item_service {
  text-align: center;
  width: 100%;
  background-color: #fff;
  padding: 8px;
  border: 1px solid #b9f6ca;
  box-sizing: border-box;
  display: inline-block;
  border-radius: 8px;
}
</style>
