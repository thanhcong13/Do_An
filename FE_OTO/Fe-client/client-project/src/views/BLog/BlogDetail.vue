
<script setup>
import { onMounted, ref } from "vue";
import axios from "axios";
import { useRoute } from "vue-router";
import router from "@/router";
// import { useRouter } from "vue-router";
import moment from "moment";

const route = useRoute();
// const route = useRouter();
const dataGetById = ref([]);
const dataGetAll = ref([]);

onMounted(() => {
  getData();
  getAllData();
});
const getData = async () => {
  try {
    const res = await axios.get(
      "http://localhost:8080/api/v1/blog/getbyid/" + route.params.id
    );
    dataGetById.value = res.data;
  } catch (e) {
    console.log("Lỗi " + e);
  }
};
const getAllData = async () => {
  try {
    const response = await axios.get(
      "http://localhost:8080/api/v1/blog/getall"
    );
    dataGetAll.value = response.data;
  } catch (e) {
    console.log("Lỗi 2" + e);
  }
};
</script>

<template>
  <v-container>
    <v-row>
      <v-col cols="8">
        <h3>{{ dataGetById.title }}</h3>
        <span> Ngày {{ moment(createdDate).format("LL") }}</span
        ><br />
        <img
          style="width: 100%; height: fit-content"
          :src="`${dataGetById.image}`"
          alt=""
        />
        <br />
        <p style="width: 100% !important">{{ dataGetById.content }}</p>
      </v-col>
      <v-divider :thickness="1" color="error" vertical></v-divider>
      <v-col cols="4">
        <h2>Các bài viết khác</h2>
        <div v-for="item in dataGetAll" :key="item.id">
          <div>
            <a class="link_blog" :href="`/blog/${item.id}`"
              ><span>
                {{ item.title }}
              </span></a
            >
          </div>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>
<style>
.link_blog {
  color: #000;
  text-decoration: none;
}
.link_blog:hover {
  color: #f0987c;
  text-decoration: underline;
}
</style>
