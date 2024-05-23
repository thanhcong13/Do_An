<script setup>
import { computed, onMounted, ref } from "vue";
import router from "@/router";
import axios from "axios";
const desserts = ref([]);
const search_oto = ref("");
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
const filterHotel = (desserts) => {
  return search_oto.value
    ? desserts.value.filter((dessert) =>
        dessert.TenSP.toLowerCase().match(search_oto.value.toLowerCase())
      )
    : desserts.value;
};
const getDataFilter = computed(() => {
  return filterHotel(desserts);
});
</script>
<template>
  <v-item-group style="margin: 0 auto" mandatory>
    <v-container>
      <v-row class="d-flex align-center">
        <v-col cols="11">
          <input
            class="w-100 input-search bg-yellow-lighten-4"
            v-model="search_oto"
            type="text"
            placeholder="Nhập tên khách sạn"
          />
        </v-col>
        <v-col cols="1">
          <button>
            <v-icon class="pa-6 text-white color-icon"> mdi-magnify </v-icon>
          </button>
        </v-col>
      </v-row>
      <v-row>
        <template v-for="(item, index) in getDataFilter" :key="item.MaSP">
          <v-col class="" v-if="index < 6" cols="4">
            <div
              @click="router.push('/products/' + item.MaSP)"
              class="hover-scale"
            >
              <img
                class="css-img"
                style="width: 100%; height: 340px"
                src="https://danviet.mediacdn.vn/296231569849192448/2023/4/8/2640mazda21-1680993974142-16809939744881343622645.jpg"
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
                  <p>{{item.TenCH}}</p>
                </div>
              </div>
            </div>
          </v-col>
        </template>
      </v-row>
    </v-container>
  </v-item-group>
</template>
<style>
.input-search {
  outline: none;
  padding: 12px;
  border-radius: 12px;
  box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px;
}
.color-icon {
  background-color: #ee8a6a;
  border-radius: 10px;
}
::placeholder {
  color: gray;
}
</style>
