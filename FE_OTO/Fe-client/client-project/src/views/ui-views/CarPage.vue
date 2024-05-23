<script setup>
import { computed, onMounted, ref } from "vue";
import router from "@/router";
import axios from "axios";
const desserts = ref([]);
const search_oto = ref("");
const listHang = ref([]);
const nameHang = ref("");
onMounted(() => {
  getData();
  getListHang();
});

const getData = async () => {
  try {
    const res = await axios.get(
      "http://localhost:5222/api/SanPham/GetAllProducts"
    );
    desserts.value = res.data.innerBody;
  } catch (e) {
    console.log(e);
  }
};

const getListHang = async () => {
  try {
    const res = await axios.get("http://localhost:5222/api/SanPham/GetAllHang");
    listHang.value = res.data.innerBody;
  } catch (error) {
    console.log(error);
  }
};
const getYear = (data) => {
  const date = new Date(data);
  return date.getFullYear();
};
const onClickItem = async (data) => {
  const nameHang = data.TenHang;
  try {
    const res = await axios.get(
      `http://localhost:5222/api/SanPham/GetAllProductsByHang?tenHang=${nameHang}`
    );
    desserts.value = res.data.innerBody;
  } catch (error) {
    console.log(error);
  }
};
const onClickAll = async (data) => {
  try {
    const res = await axios.get(
      "http://localhost:5222/api/SanPham/GetAllProducts"
    );
    desserts.value = res.data.innerBody;
  } catch (error) {
    console.log(error);
  }
};
const filterCar = (desserts) => {
  return search_oto.value
    ? desserts.value.filter((dessert) =>
        dessert.TenSP.toLowerCase().match(search_oto.value.toLowerCase())
      )
    : desserts.value;
};
const getDataFilter = computed(() => {
  return filterCar(desserts);
});
</script>
<template>
  <v-item-group style="margin: 65px auto" mandatory>
    <v-container>
      <v-row class="d-flex align-center">
        <v-col cols="11">
          <input
            class="w-100 input-search bg-yellow-lighten-4"
            v-model="search_oto"
            type="text"
            placeholder="Nhập tên xe"
          />
        </v-col>
        <v-col cols="1">
          <button>
            <v-icon class="pa-6 text-white color-icon"> mdi-magnify </v-icon>
          </button>
        </v-col>
      </v-row>
      <v-row>
        <h1 class="pa-4" style="text-transform: uppercase">
          Danh sách sản phẩm
        </h1>
      </v-row>
      <v-row>
        <v-col cols="2">
          <ul class="list-hang">
            <li class="item-hang" style="cursor: pointer" @click="onClickAll">
              <h3>Tất cả sản phẩm</h3>
            </li>
            <li
              class="item-hang"
              v-for="item in listHang"
              :key="item.TenHang"
              @click="onClickItem(item)"
              style="cursor: pointer"
            >
              <h3>{{ item.TenHang }}</h3>
            </li>
          </ul>
        </v-col>
        <v-col cols="10">
          <v-row>
            <template v-for="item in getDataFilter" :key="item.MaSP">
              <v-col class="" cols="4">
                <div
                  @click="router.push('/products/' + item.MaSP)"
                  class="hover-scale"
                >
                  <div class="image-container">
                    <img
                      class="css-img responsive-image"
                      
                      :src="item.Image"
                      alt=""
                    />
                  </div>

                  <h4 class="hotel-h1 text-h6 ml-3">{{ item.TenSP }}</h4>
                  <!-- <div class="text-right">
                        <span class="text-right">từ </span>
                        <span class="text-h6 text-teal-lighten-1"
                          >{{ item.fromPrice }}
                        </span>
                        <span class="mr-3"> VNĐ</span>
                      </div> -->
                  <div class="d-flex mx-3 pb-3 justify-space-between">
                    <div class="col-md-6 d-flex content-auto">
                      <v-icon class="icon-product mr-1">mdi-calendar</v-icon>
                      <p>{{ getYear(item.NamSX) }}</p>
                    </div>
                    <div class="col-md-6 content-auto">
                      <p>{{ item.TenCH }}</p>
                    </div>
                  </div>
                </div>
              </v-col>
            </template>
          </v-row>
        </v-col>
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

.list-hang {
  list-style: none;
}

.item-hang {
  color: white;
  font-size: 15px;
  padding: 6px;
  background-color: #ee8a6a;
  margin-bottom: 4px;
}
.image-container {
  width: 100%; /* Đặt kích thước khung chứa */
  height: 340px; /* Đặt kích thước khung chứa */
  overflow: hidden; /* Đảm bảo hình ảnh không tràn ra ngoài khung */
  position: relative;
}

.responsive-image {
  width: 100%;
  height: 100%;
  object-fit: fill; /* Giữ tỷ lệ của ảnh và cắt ảnh để vừa với khung */
  object-position: center; /* Đặt vị trí ảnh ở giữa khung */
}
</style>
