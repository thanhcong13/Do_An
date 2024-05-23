<script setup>
import { onMounted, ref } from "vue";
import router from "@/router";
import axios from "axios";
import { Swiper, SwiperSlide } from "swiper/vue";

// Import Swiper styles
import "swiper/css";

const desserts = ref([]);
onMounted(() => {
  getData();
});
const getData = async () => {
  try {
    const res = await axios.get("http://localhost:5222/api/SanPham/GetAllProducts");
    desserts.value = res.data.innerBody;
  } catch (e) {
    console.log(e);
  }
};

const getYear = (data) => {
      const date = new Date(data);
      return date.getFullYear();
    }
</script>
<template>
  <!-- <v-carousel style="position: relative" show-arrows="hover">
    <div style="width: 100%; height: 100%">
      <h1
        data-aos="fade-down"
        style="
          position: absolute;
          top: 38%;
          left: 32%;
          z-index: 10000;
          color: white;
          font-size: 50px;
          text-transform: uppercase;
        "
      >
        Mua bán, bảo dưỡng xe uy tín
      </h1>
      <v-carousel-item
        style="
          background: linear-gradient(
              rgba(64, 6, 97, 0.4),
              rgba(64, 6, 97, 0.4)
            ),
            url('https://storage.googleapis.com/f1-cms/2021/06/1b79ceb7-20210607_034302.jpg')
              center center / cover no-repeat;
        "
      ></v-carousel-item>
    </div>

    <v-carousel-item
      src="https://nova4x4.vn/wp-content/uploads/2019/08/ban-tai-ford-ranger-2019-lariat.jpg"
      cover
    ></v-carousel-item>

    <v-carousel-item
      src="https://cms-i.autodaily.vn/du-lieu/2016/10/10/C250%20Exclusive/mercedes-benz-c250-2.jpg"
      cover
    ></v-carousel-item>
  </v-carousel> -->
  <div class="video">
    <div class="video-wrap" id="video-container">
      <video
        id="intro-video"
        preload="auto"
        loop=""
        autoplay="auto"
        playsinline=""
        muted=""
      >
        <source src="@/assets/video/video-intro.mp4" type="video/mp4" />
      </video>
    </div>
  </div>

  <div>
    <h1
      style="
        margin-top: 30px;
        text-align: center;
        text-transform: uppercase;
        font-size: 40px;
        color: #ee8a6a;
      "
    >
      Sản phẩm nổi bật
    </h1>
    <v-item-group style="margin: 0 auto" mandatory>
      <v-container>
        <v-row>
          <template v-for="(item, index) in desserts" :key="item.MaSP">
            <v-col class="" v-if="index < 6" cols="4">
              <div
                @click="router.push('/products/' + item.MaSP)"
                class="hover-scale"
              >
                <img
                  class="css-img"
                  style="width: 100%; height: 340px"
                  :src="`${item.Image}`"
                  alt=""
                />
                <h4 class="hotel-h1 text-h6 ml-3" >{{ item.TenSP }}</h4>
                <!-- <div class="text-right">
                  <span class="text-right">từ </span>
                  <span class="text-h6 text-teal-lighten-1"
                    >{{ item.fromPrice }}
                  </span>
                  <span class="mr-3"> VNĐ</span>
                </div> -->
                <div class="d-flex mx-3 pb-3 justify-space-between">
                  <div class="col-md-6 d-flex content-auto">
                    <v-icon class="icon-product mr-1 ">mdi-calendar</v-icon>
                    <p>{{ getYear(item.NamSX) }}</p>
                  </div>
                  <div class="col-md-6 content-auto">
                    <p class="text-none">{{item.TenCH}}</p>
                  </div>
                </div>
              </div>
            </v-col>
          </template>
        </v-row>
        <div class="text-center mt-16">
          <button
            @click="router.push('/products')"
            class="pa-3 bg-orange-lighten-2 text-white btn-see"
          >
            Xem thêm
          </button>
        </div>
      </v-container>
    </v-item-group>
    <div class="content__intro ">
                <div class="content__intro__title">
                    <div class="content__intro__name col-lg-12 mt-0 mt-md-3 mt-xl-5">
                        <h1 class="text-while text-upper text-name ">Cung cấp những chiếc siêu xe đẹp nhất</h1>
                    </div>
                    <div>
                        <p class="text-while intro-text">
                            Có trụ sở tại Preston ở Lancashire, gần Giao lộ 31A của Đường cao tốc
                            M6, AUTO88 cung cấp nhiều loại Siêu xe cổ điển và đương đại cũng như 
                            xe thể thao để bán từ các thương hiệu như Aston Martin, Bentley, 
                            Bugatti, Ferrari, Lamborghini, Pagani, Porsche và nhiều hơn nữa. 
                            Siêu xe AUTO88 nổi tiếng quốc tế vì cung cấp nhiều lựa chọn độc đáo về
                            một số loại ô tô tốt nhất thế giới. Với hàng trăm chiếc xe đẹp được 
                            cung cấp cho nhiều đối tượng khách hàng đa dạng, AUTO88 là đại lý Siêu
                            xe số 1 và hàng đầu tại Vương quốc Anh.
                        </p>
                        
                    </div>
                </div>
           </div>
    </div>
    <!-- <swiper :watchSlidesProgress="true" :slidesPerView="3" class="mySwiper">
      <swiper-slide>
        <img
          class="img-object"
          src="https://storage.googleapis.com/f1-cms/2021/11/4003c02c-20211124_030843.jpg"
          alt=""
        />
      </swiper-slide>
      <swiper-slide
        ><img
          class="img-object"
          src="data:image/jpeg;base64,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"
          alt=""
      /></swiper-slide>
      <swiper-slide
        ><img
          class="img-object"
          src="https://danviet.mediacdn.vn/296231569849192448/2022/2/7/mazda-6-2023-lo-dien-dep-my-man-du-suc-ngang-duong-toyota-camry-danvietvn-2-16442421409181885382055.png"
          alt=""
      /></swiper-slide>
      <swiper-slide
        ><img
          class="img-object"
          src="https://carshop.vn/wp-content/uploads/2022/07/anh-xe-BMW-82.jpg"
          alt=""
        />
      </swiper-slide>
      <swiper-slide
        ><img
          class="img-object"
          src="https://fordlongbien.com/wp-content/uploads/2017/08/Ford-ranger-Sport-2024-mau-do.jpg"
          alt=""
      /></swiper-slide>
      <swiper-slide
        ><img
          class="img-object"
          src="https://cdn.tuoitrethudo.vn/stores/news_dataimages/tuoitrethudocomvn/082018/10/08/o-to-vinfast-lo-noi-that-dep-khong-kem-xe-sang-03-.6257.png"
          alt=""
      /></swiper-slide>
      <swiper-slide
        ><img
          class="img-object"
          src="https://cdn.24h.com.vn/upload/2-2022/images/2022-05-09/ford-ranger-1652080138-618-width1200height720.jpg"
          alt=""
      /></swiper-slide>
      <swiper-slide
        ><img
          class="img-object"
          src="https://wrapstudio.vn/wp-content/uploads/2023/05/BMW-740Li-2023.png"
          alt=""
      /></swiper-slide>
      <swiper-slide
        ><img
          class="img-object"
          src="https://xehayvietnam.com.vn/wp-content/uploads/2023/06/hinh-anh-xe-mercedes-benz-c200-avantgarde-3-jpg.webp"
          alt=""
      /></swiper-slide>
    </swiper> -->

    
    
</template>
<style>
.video{
    position: relative;
    width: 100%;
    height: 100vh;
    background-color: black;
}
.video-wrap{
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;

}
.intro-video{
   background-size: cover;
    background-position: center center;
    background-color: #111;
}

#video-container {
    height: 100vh;
    overflow: hidden;
    position: relative;
    @media (max-width: 780px) {
      height: 100vw;
    }
    video {
      width: 100vw;
      position: absolute;
      /* canh video ngay giữa */
      left: 50%; top: 50%;
      transform: translate(-50%, -50%);
    }
  }
  /* .text-none{
    max-width: 175px;
    overflow: hidden;
    display: -webkit-box;
    -webkit-line-clamp: 1;
    line-clamp: 1;
    -webkit-box-orient: vertical;
  } */
.hover-scale {
  box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px;
  position: relative;
  /* margin: 0 2px; */
  margin: 12px 1px;
  padding: 0;
}
.hover-scale:hover {
  box-sizing: border-box;
  border: 1px solid #c8c4c4;
  cursor: pointer;
}
.hover-scale:hover img {
  transform: rotate(0deg), scale(1.1);
}
.hover-scale:hover h1 {
  color: #ee8a6a;
}
.hotel-h1 {
  font-size: 26px;
  line-height: 46px;
  text-transform: uppercase !important;
  font-weight: bold;
}
.css-img {
  border-radius: 4px;
}
@keyframes zoom {
  from {
    transform: scale(1);
  }
  to {
    transform: scale(1.1);
  }
}
.text-right {
  text-align: right;
}
.content-auto{
  font-size: 15px;
  color: #ee8a6a;
}
.btn-see {
  border-radius: 8px;
  text-transform: uppercase;
  font-weight: 800;
}
.swiper {
  width: 100%;
}
.swiper-slide {
  height: 300px;
  background: #882525;
  line-height: 300px;
  text-align: center;
}
.swiper-slide:nth-child(2) {
  background: #8acc7d;
}
.swiper-slide:nth-child(3) {
  background: #b7cc7d;
}
.swiper-slide:nth-child(4) {
  background: #9eb75c;
}
.swiper-slide:nth-child(5) {
  background: #7da8cc;
}
.swiper-slide:nth-child(6) {
  background: #96cc7d;
}
.swiper-slide:nth-child(7) {
  background: #cc7dae;
}
.img-object {
  width: 100%;
  object-fit: cover;
  height: 100%;
}
.content__intro{
    background-image: linear-gradient(0 , #33333354,#333),
    url("../../assets/images/backgr_intro.jpg");
    width: 100%;
    height: 770px;
   
    background-repeat: no-repeat;
    background-size: cover;
    
   position: relative;
   font-family: "Inter", sans-serif;

}
.text-while {
    color: white;
    text-decoration: none;
}
.content__intro__title{
        width: 600px;
        position: absolute;
        top: 70px;
        left: 50px;
}
.content__intro__title .text-name{
    line-height: 1.2;
    letter-spacing: 4px;
    margin-bottom: 40px;
}
.content__intro__title .intro-text{
    line-height: 1.9;
    margin-bottom: 70px;
    font-size: 17px;
}


</style>
