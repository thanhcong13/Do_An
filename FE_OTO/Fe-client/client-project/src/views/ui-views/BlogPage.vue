<script setup>
import { onMounted, ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import moment from "moment";

const desserts = ref([]);
const router = useRouter();
onMounted(() => {
  getData();
});
const getData = async () => {
  try {
    const res = await axios.get("http://localhost:8080/api/v1/blog/getall");
    desserts.value = res.data;
  } catch (e) {
    console.log(e);
  }
};
</script>
<template>
  <v-container>
    <v-row class="mx-16 md-mx-8 sm-mx-4">
      <v-col class="" cols="6" v-for="item in desserts" :key="item.id">
        <div style="height: 490px" class="content_blog pb-2">
          <img :src="`${item.image}`" class="w-100 img_blog ma-0" alt="" />
          <h4 class="ma-0 mx-4">{{ item.title }}</h4>
          <span class="mx-4">
            tạo
            {{ moment(item.createdDate).format("LL") }}</span
          >
          <div class="text-right mx-4">
            <button @click="router.push('/blog/' + item.id)" class="btn_see">
              Xem chi tiết
            </button>
          </div>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>
<style>
.content_blog {
  box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
}
.img_blog {
  object-fit: cover;
}
.btn_see {
  background-color: #f0987c;
  padding: 4px 6px;
  border-radius: 4px;
  color: white;
}
</style>
