<script setup>
import { onMounted, ref, computed } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import { useRoute } from "vue-router";
import Datepicker from "vue3-datepicker";

const route = useRoute();
const router = useRouter();

const desserts = ref([]);
const username = localStorage.getItem("username");
const userid = localStorage.getItem("id");
const email = localStorage.getItem("email");
const dayRental = ref(new Date());

const picked_end = ref();
const totalMoney = ref(0);
const datedif = computed({
  get() {
    return Math.round(
      (picked_end.value - dayRental.value) / (60 * 60 * 1000 * 24)
    );
  },
});
const total = computed({
  get() {
    return Math.round(datedif.value * desserts.value.price);
  },
});
onMounted(() => {
  getDataOrder();
});
const getDataOrder = async () => {
  try {
    const res = await axios.get(
      "http://localhost:8080/api/v1/order/getbyid/" + route.params.id
    );
    desserts.value = res.data;
  } catch (e) {
    console.error(e);
  }
};
const orderEdit = async () => {
  try {
    const editData = {
      dayNum: datedif.value,
      totalMoney: total.value,
      dayRental: dayRental.value,
    };
    const insert = await axios.put(
      "http://localhost:8080/api/v1/order/update/" + route.params.id,
      editData
    );
    if (insert != null) {
      router.push("/thankspage");
    }
  } catch (e) {
    console.log(e);
  }
};
</script>

<template>
  <v-container>
    <v-row>
      <v-col cols="4">
        <div class="bg-white">
          <img class="w-100" :src="`${desserts.image}`" alt="" />
          <div class="bg-white pa-3">
            <h2>{{ desserts.hotelName }}</h2>
            <v-row>
              <v-col cols="4">Room name: </v-col>
              <v-col cols="8"
                ><span class="float-right"
                  >{{ desserts.roomName }}
                </span></v-col
              >
            </v-row>

            <v-row>
              <v-col cols="4">Capacity: </v-col>
              <v-col cols="8"
                ><span class="float-right"
                  >{{ desserts.capacity }}
                </span></v-col
              >
            </v-row>
            <v-row>
              <v-col cols="4">Price: </v-col>
              <v-col cols="8">
                <div>
                  <h3 class="text-color float-right text-h5">
                    {{ desserts.price }}
                    <span
                      class="float-right text-blue-darken-1 text-subtitle-1"
                    >
                      VNĐ / night</span
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
          <h3>Booking Information</h3>
          <div>
            <span>Time of booking</span>
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
          <h3>Contact Information</h3>
          <div>
            <span>Contact name:</span>
            <v-row>
              <v-col cols="12">
                <input
                  class="input-text"
                  type="text"
                  disabled
                  placeholder="Input your full name as show your ID / Passport"
                  v-model="desserts.fullName"
                />
              </v-col>
            </v-row>
          </div>
          <div>
            <v-row>
              <v-col cols="6">
                <span> Username: </span>
                <v-row>
                  <v-col cols="12">
                    <input
                      disabled
                      class="input-text"
                      type="text"
                      v-model="username"
                      placeholder="Username"
                    />
                  </v-col>
                </v-row>
              </v-col>
              <v-col cols="6">
                <span> Phone number: </span>
                <v-row>
                  <v-col cols="12">
                    <input
                      disabled
                      class="input-text"
                      type="text"
                      v-model="desserts.phone"
                      placeholder="Username"
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
                  disabled
                  class="input-text"
                  type="text"
                  v-model="email"
                  placeholder="Email"
                />
              </v-col>
            </v-row>
          </div>
          <div class="float-right d-flex flex-column">
            <div class="text-h6">
              <span>Thanh toán: </span>
              <span>{{ total }}</span>
              <span> VNĐ</span>
            </div>
            <div class="mt-5">
              <v-btn class="float-right" @click="orderEdit">Book now</v-btn>
            </div>
          </div>
        </div>
      </v-col>
    </v-row>
  </v-container>
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
