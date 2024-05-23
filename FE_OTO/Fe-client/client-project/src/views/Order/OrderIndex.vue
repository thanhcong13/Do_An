<script setup>
import { ref, onMounted, defineProps, computed } from "vue";
import axios from "axios";
import Datepicker from "vue3-datepicker";
import { useRoute } from "vue-router";
import { useRouter } from "vue-router";

const route = useRoute();
const router = useRouter();
const username = localStorage.getItem("username");
const userid = localStorage.getItem("id");
const desserts = ref([]);
const fullName = ref("");
const hotelName = ref("");
const email = localStorage.getItem("email");
const capacity = ref("");
const roomId = ref();
const roomName = ref("");
const userId = ref();
const hotelId = ref();
const phone = ref("");
const image = ref("");
const images = ref("");
const imgUrls = ref([]);
const imgUrlsPreview = ref([]);
const price = ref();
const dayRental = ref(new Date());
const picked_end = ref();
const totalMoney = ref(0);

const listData = ref([]);
const roomData = ref([]);

// var datedif = picked_end.get().value - picked.get().value;
// const countDate = (date) => {
//   const time = date.getTimezoneOffset() * 60 * 1000;
//   return new Date(date - time).toISOString().split("T")[0];
// };

onMounted(() => {
  getData();
  getDataRoom();
});
const getData = async () => {
  try {
    const res = await axios.get(
      "http://localhost:8080/api/v1/hotel/getbyid/" + route.params.id
    );
    listData.value = res.data;
  } catch (e) {
    console.error(e);
  }
};

const getDataRoom = async () => {
  try {
    const res = await axios.get(
      "http://localhost:8080/api/v1/room/getbyid/" + route.params.roomId
    );
    // console.log(typeof res.data.price);
    roomData.value = res.data;
  } catch (e) {
    console.error(e);
  }
};
const orderRoom = async () => {
  try {
    const inserData = {
      hotelName: hotelName.value,
      userId: userid,
      roomId: route.params.roomId,
      hotelId: route.params.id,
      roomName: roomName.value,
      fullName: fullName.value,
      email: email.value,
      dayNum: datedif.value,
      totalMoney: total.value,
      image: roomData.value.image,
      dayRental: dayRental.value,
      phone: phone.value,
      capacity: capacity.value,
      price: price.value,
    };
    const insert = await axios.post(
      "http://localhost:8080/api/v1/order/create",
      inserData
    );
    if (insert != null) {
      router.push("/thankspage");
    }
  } catch (e) {
    console.log(e);
  }
};
const datedif = computed({
  get() {
    return Math.round(
      (picked_end.value - dayRental.value) / (60 * 60 * 1000 * 24)
    );
  },
});
const total = computed({
  get() {
    return Math.round(datedif.value * roomData.value.price);
  },
});
</script>

<template>
  <div>
    <v-container>
      <v-row>
        <v-col cols="4">
          <div class="bg-white">
            <img class="w-100" :src="`${roomData.image}`" alt="" />
            <div class="bg-white pa-3">
              <h2>{{ listData.hotelName }}</h2>
              <v-row>
                <v-col cols="4">Tên phòng: </v-col>
                <v-col cols="8"
                  ><span class="float-right"
                    >{{ roomData.roomName }}
                  </span></v-col
                >
              </v-row>
              <v-row>
                <v-col cols="4">Loại phòng: </v-col>
                <v-col cols="8"
                  ><span class="float-right"
                    >{{ roomData.bedType }}
                  </span></v-col
                >
              </v-row>
              <v-row>
                <v-col cols="4">Diện tích: </v-col>
                <v-col cols="8"
                  ><span class="float-right"
                    >{{ roomData.capacity }}
                  </span></v-col
                >
              </v-row>
              <v-row>
                <v-col cols="4">Giá: </v-col>
                <v-col cols="8">
                  <div>
                    <h3 class="text-color float-right text-h5">
                      {{ roomData.price }}
                      <span
                        class="float-right text-blue-darken-1 text-subtitle-1"
                      >
                        VNĐ / Đêm</span
                      >
                    </h3>
                  </div>
                </v-col>
              </v-row>
            </div>
          </div>
        </v-col>
        <v-col cols="8">
          <div class="bg-white pa-5">
            <h3>Thông tin đặt phòng</h3>
            <div>
              <span>Ngày thuê</span>
              <v-row class="d-flex justify-space-between">
                <v-col cols="6">
                  <VueDatePicker
                    :min-date="new Date()"
                    v-model="dayRental"
                    class="d-picked"
                    :enable-time-picker="false"
                  ></VueDatePicker>
                </v-col>
                <v-col cols="6">
                  <VueDatePicker
                    :min-date="new Date()"
                    v-model="picked_end"
                    class="d-picked"
                    placeholder="Select Date"
                    :enable-time-picker="false"
                  ></VueDatePicker>
                </v-col>
              </v-row>
            </div>
          </div>
          <div class="bg-white pa-5 mt-2">
            <h3>Thông tin người đặt</h3>
            <div>
              <span>Họ tên:</span>
              <v-row>
                <v-col cols="12">
                  <input
                    class="input-text"
                    type="text"
                    required
                    placeholder="Input your full name as show your ID / Passport"
                    v-model="fullName"
                  />
                </v-col>
              </v-row>
            </div>
            <div>
              <v-row>
                <v-col cols="6">
                  <span> Tài khoản: </span>
                  <v-row>
                    <v-col cols="12">
                      <input
                        class="input-text"
                        type="text"
                        required
                        v-model="username"
                        placeholder="Tài khoản"
                      />
                    </v-col>
                  </v-row>
                </v-col>
                <v-col cols="6">
                  <span> Số điện thoại: </span>
                  <v-row>
                    <v-col cols="12">
                      <input
                        required
                        class="input-text"
                        type="text"
                        v-model="listData.phone"
                        placeholder="Số điện thoại"
                      />
                    </v-col>
                  </v-row>
                </v-col>
              </v-row>
            </div>
            <div>
              <span>Email:</span>
              <v-row>
                <v-col cols="12">
                  <input
                    class="input-text"
                    type="text"
                    v-model="email"
                    placeholder="Email"
                  />
                </v-col>
              </v-row>
            </div>

            <div v-if="username" class="float-right d-flex flex-column">
              <div class="text-h6">
                <span>Thanh toán: </span>
                <span>{{ total === isNaN ? 0 : total }}</span>
                <span> VNĐ</span>
              </div>
              <div class="mt-5">
                <v-btn class="float-right" @click="orderRoom">Book now</v-btn>
              </div>
            </div>
            <div v-else class="float-right">
              <span>Bạn cần đăng nhập để có thể đặt phòng </span>
              <a href="/login">đăng nhập</a>
            </div>
          </div>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<style>
.d-picked {
  width: 100%;
  padding: 4px;
  color: #ee8a6a;
  outline: none;
}
.text-color {
  color: rgb(73, 190, 110);
}
.input-text {
  width: 100%;
  /* outline: none; */
  outline-color: #ee8a6a;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
</style>
