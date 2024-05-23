<script setup>
import { onMounted, ref } from "vue";
import axios from "axios";
import { useRoute } from "vue-router";
import { Swiper, SwiperSlide } from "swiper/vue";
import { useRouter } from "vue-router";
const router = useRouter();

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
const getFullDay = (dateString) => {
  const date = new Date(dateString);
  const day = String(date.getDate()).padStart(2, "0");
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const year = date.getFullYear();
  return `${day}/${month}/${year}`;
};

const onLienHe = (desserts) => {
  // console.log(desserts);
  localStorage.setItem(`TenSP`, desserts);
  console.log(localStorage.getItem(`TenSP`));
  router.push("/products/lienhe");
};
const onLaiThu = (desserts) => {
  localStorage.setItem(`TenSP`, desserts);
  console.log(localStorage.getItem(`TenSP`));
  router.push("/products/laithu");
}
</script>
<template>
  <v-car>
    <v-container>
      <v-row>
        <v-col cols="8">
          <v-row class="bg-yellow-lighten-5 pa-0 ma-0 mb-3">
            <v-col cols="6">
              <h2 style="width: 100%" class="header-hv">{{ desserts.TenSP }}</h2>
            </v-col>
          </v-row>
          <img
            class="w-100"
            :src="desserts.Image"
            alt=""
          />
          <v-toolbar class="bg-yellow-lighten-4">
            <v-row class="text-center">
              <v-col col="4">
                <span>Năm sản xuất: </span>
                <span style="color: #ee8a6a; font-weight: 600">{{
                  getFullDay(desserts.NamSX)
                }}</span>
              </v-col>
              <v-col col="4">
                <span> Hãng: </span>
                <span style="color: #ee8a6a; font-weight: 600"
                  >{{ desserts.TenHang }}
                </span>
              </v-col>
              <v-col col="4">
                <span> Loại hộp số: </span>
                <span style="color: #ee8a6a; font-weight: 600">{{
                  desserts.LoaiHopSo
                }}</span>
              </v-col>
              <v-col col="4">
                <span> Tình trạng: </span>
                <span style="color: #ee8a6a; font-weight: 600">{{
                  desserts.TinhTrang
                }}</span>
              </v-col>
            </v-row>
          </v-toolbar>
          <v-toolbar class="mb-4 bg-yellow-lighten-4">
            <v-row class="text-center">
              <v-col col="4">
                <span>Năm đăng ký: </span>
                <span style="color: #ee8a6a; font-weight: 600">{{
                  getFullDay(desserts.NamDangKy)
                }}</span>
              </v-col>
              <v-col col="4">
                <span> Màu sắc: </span>
                <span style="color: #ee8a6a; font-weight: 600">{{
                  desserts.MauSac
                }}</span>
              </v-col>
              <v-col col="4">
                <span> Động cơ: </span>
                <span style="color: #ee8a6a; font-weight: 600">{{
                  desserts.DongCo
                }}</span>
              </v-col>
              <v-col col="4">
                <span> Dung tích: </span>
                <span style="color: #ee8a6a; font-weight: 600">{{
                  desserts.DungTich
                }}</span>
              </v-col>
            </v-row>
          </v-toolbar>
          <v-row>
            <v-col cols="3" class="d-flex justify-space-between">
              <v-btn @click="onLienHe(desserts.TenSP)" color="info">Liên hệ</v-btn>
              <v-btn @click="onLaiThu(desserts.TenSP)">Lái thử</v-btn>
            </v-col>
            <v-col cols="10"></v-col>
          </v-row>
          <v-row class="bg-yellow-lighten-5 ml-1 mt-3 pa-4">
            <div class="float-left ml-2">
              <h2>Thông tin chi tiết xe {{ desserts.TenSP }}</h2>
              <span class="pa-3">{{ desserts.MoTa }}</span>
              <h2>Cam kết</h2>
              <ul class="list-dec pa-3">
                <li class="item_dec d-flex align-item-center">
                  <v-icon class="text-white dec-icon"> mdi-check </v-icon>
                  <p>Chạy đúng đồng hồ km</p>
                </li>
                <li class="item_dec d-flex align-item-center">
                  <v-icon class="text-white dec-icon"> mdi-check </v-icon>
                  <p>Không tông đụng, tai nạn, không ngập nước</p>
                </li>
                <li class="item_dec d-flex align-item-center">
                  <v-icon class="text-white dec-icon"> mdi-check </v-icon>
                  <p>Kiểm tra tỉ mỉ về chất lượng</p>
                </li>
                <li class="item_dec d-flex align-item-center">
                  <v-icon class="text-white dec-icon"> mdi-check </v-icon>
                  <p>
                    Bảo hành miễn phí động cơ: 06 tháng hoặc 5000km (tuỳ theo điều kiện
                    nào đến trước)
                  </p>
                </li>
                <li class="item_dec d-flex align-item-center">
                  <v-icon class="text-white dec-icon"> mdi-check </v-icon>
                  <p>Hoàn lại đầy đủ nếu không đúng cam kết</p>
                </li>
              </ul>
            </div>
          </v-row>
          <v-row class="bg-amber-lighten-5 ml-1 pa-4 mt-5">
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
        </v-col>
        <v-col cols="4" >
          <h2 class="content-header mt-10">Thị trường xe</h2>
          <ul class="list-content">
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >Giá xe Vinfast lăn bánh kèm ưu đãi mới nhất tháng 5/2024</a
              >
            </li>
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >Honda giảm giá sập sàn khuyến mại 100% lệ phí trước bạ cho CR-V và Civic</a
              >
            </li>
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >Hyundai Palisade 'siêu lướt' 6.000 km trên sàn xe cũ với giá khó tin</a
              >
            </li>
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >SUV Mazda CX-80 chốt lịch ra mắt thị trường vào ngày 18/4</a
              >
            </li>
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >Xe UAZ mới của Nga lộ diện, cộng đồng mạng hết lời khen đẹp, lực, chất</a
              >
            </li>
          </ul>
          <h2 class="content-header mt-10">Đánh giá xe</h2>
          <ul class="list-content">
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >Đánh giá Mitsubishi Xforce - tân binh phân khúc B SUV với ngập tràn công nghệ</a
              >
            </li>
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >Đánh giá Peugeot 2008: thiết kế cá tính, trải nghiệm lái thể thao</a
              >
            </li>
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >Honda BR-V và Mitsubishi Xpander: tân binh so kè “ông hoàng phân khúc”?</a
              >
            </li>
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >Đánh giá Porsche Cayenne 2016 - SUV phong cách coupe</a
              >
            </li>
            <li class="item-content">
              <a href="#" class="item-link-right px-0"
                >C63 S E-Performance 2023 - se sang tốc độ nhưng còn nhiều hạn chế</a
              >
            </li>
          </ul>
        </v-col>
      </v-row>
    </v-container>
  </v-car>
</template>
<style >
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

/* .v-toolbar__content {
    background: #eee3ce;
} */
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
.list-dec {
  list-style: none;
}

.item_dec {
  line-height: 36px !important;
}

.item_dec p {
  margin-left: 4px;
  margin-top: -3px;
}
.dec-icon {
  font-size: 24px;
  color: #fff;
  padding: 4px;
  border-radius: 4px;
  background-color: #4caf50;
}

.content-header{
  font-size: 30px;
  text-transform: uppercase;
}

.list-content{
  list-style: none;
  
}
.item-content{
  font-size: 14px;
  padding: 8px 0 !important;
  line-height: 40px;
  
}

.item-content:hover .item-link-right{
  color: #ee8a6a;
}
.item-link-right{
  text-decoration:  none;
  color: #000;
  padding: 8px 0;
  

}
</style>
<style scoped>
.v-col{
  flex-grow: 1;
}
.v-toolbar{
  background: wheat !important;
}
.v-container {
    
    padding: 85px 16px 16px 16px;
    
}
</style>