<script setup>
import { onMounted, ref, watch } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";

const orderList = ref([]);
const router = useRouter();
const dialog = ref(false);
const deleteData = ref([]);
const deleteItem = ref(false);
const checkItem = ref(true);
onMounted(() => {
  getData();
});
watch(orderList, () => {
  getData();
});
const userId = localStorage.getItem("id");
const getData = async () => {
  try {
    const res = await axios.get(
      "http://localhost:8080/api/v1/user/getUserById/" + userId
    );
    orderList.value = res.data.orderHotelDetails;
  } catch (e) {
    console.log(e);
  }
};
const handleDelete = async (data) => {
  try {
    deleteData.value = data;
    const detele = {
      delete: deleteItem.value,
    };
    const success = await axios.put(
      "http://localhost:8080/api/v1/order/delete/" + deleteData.value.id,
      detele
    );
    dialog.value = false;
  } catch (e) {
    console.log(e);
  }
};
const checkOrder = async (data) => {
  try {
    deleteData.value = data;
    const check = {
      status: checkItem.value,
    };
    const checkSuccess = await axios.put(
      "http://localhost:8080/api/v1/order/check/" + deleteData.value.id,
      check
    );
  } catch (e) {
    console.log(e);
  }
};
// const dialogDelete = async () => {
//   try{
//    const deleteOrder = await axios.delete("")
//   }
// }
const openDelete = (data) => {
  console.log(data);
  dialog.value = true;
};
</script>
<template>
  <v-container>
    <v-row class="bg-white mt-4">
      <v-col cols="6">
        <span class="pl-3">Information</span>
      </v-col>
      <v-col cols="6">
        <v-row class="pr-3">
          <v-col cols="3">
            <span>Price</span>
          </v-col>
          <v-col cols="3">
            <span>Day</span>
          </v-col>
          <v-col cols="3">
            <span>Total Money</span>
          </v-col>
          <v-col class="text-center" cols="3">
            <span>Operation</span>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <div v-for="item in orderList" :key="item.id">
      <v-row v-if="item.delete === true" class="mt-5 bg-white">
        <v-col cols="6">
          <button>
            <h3 class="pl-3 pr-3">{{ item.hotelName }}</h3>
          </button>
        </v-col>
        <v-col v-if="item.isConfirm === true" class="text-center" cols="6">
          <button
            @click="checkOrder(item)"
            class="btn-acction text-center float-right mr-10"
          >
            Trả phòng
          </button>
        </v-col>
        <v-col v-if="item.isConfirm === null" class="text-center" cols="6">
          <button class="btn-acction text-center float-right mr-10">
            Đang chờ xử lý
          </button>
        </v-col>
        <v-col v-if="item.isConfirm === false" class="text-center" cols="6">
          <button class="btn-acction text-center float-right mr-10">
            Đơn đặt bị từ chối
          </button>
        </v-col>
        <v-divider class="pr-3"></v-divider>
        <v-col cols="12">
          <v-row class="pr-3 pl-3">
            <v-col cols="6">
              <v-row>
                <v-col cols="3">
                  <img class="w-100" :src="`${item.image}`" alt="" />
                </v-col>
                <v-col cols="4">
                  <span>{{ item.roomName }}</span>
                </v-col>
                <v-col cols="3">
                  <span>{{ item.bedType }}</span>
                </v-col>
              </v-row>
            </v-col>
            <v-col cols="6">
              <v-row>
                <v-col cols="3">
                  <span class="color-pri mt-6">{{ item.price }} đ</span>
                </v-col>
                <v-col cols="3">
                  <span>{{ item.dayNum }}</span>
                </v-col>
                <v-col cols="3">
                  <span>{{ item.totalMoney }} VNĐ</span>
                </v-col>
                <v-col class="text-center" cols="3">
                  <v-row v-if="item.status === false">
                    <v-col cols="12">
                      <button
                        @click="router.push('/order/' + item.id)"
                        class="text-underline"
                      >
                        Sửa
                      </button>
                    </v-col>
                    <v-col cols="12">
                      <button @click="openDelete(item)" class="text-underline">
                        Hủy
                      </button>
                    </v-col>
                  </v-row>
                  <v-row v-else-if="item.status === true">
                    <v-col cols="12">
                      <button class="text-underline">Đã trả phòng</button>
                    </v-col>
                  </v-row>
                </v-col>
              </v-row>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
      <template>
        <v-row justify="space-around">
          <v-dialog
            v-model="dialog"
            transition="dialog-top-transition"
            persistent
            width="auto"
          >
            <v-card>
              <v-card-title class="text-h5"> Cảnh báo! </v-card-title>
              <v-card-text>Bạn có chắc muốn hủy không?</v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn
                  color="red-darken-1"
                  variant="text"
                  @click="dialog = false"
                >
                  Không
                </v-btn>
                <v-btn
                  color="green-darken-1"
                  variant="text"
                  @click="handleDelete(item)"
                >
                  Đồng ý
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-row>
      </template>
    </div>
  </v-container>
</template>
<style>
.text-underline {
  text-decoration: underline;
}
.text-underline:hover {
  color: #ee8a6a;
}
.color-pri {
  color: #ee8a6a;
}
.btn-acction {
  background-color: #ee8a6a;
  padding: 4px;
  border-radius: 4px;
  color: white;
}
</style>
