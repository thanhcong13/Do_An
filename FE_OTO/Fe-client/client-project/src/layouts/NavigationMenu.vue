<script setup lang="ts">
import { ref } from "vue";

import NavigatinItem from "./NavigationItem";
const navItem = ref(NavigatinItem);
</script>
<template>
  <div class="d-flex justify-center">
    <v-list class="d-flex justify-center">
      <template v-for="(item, i) in navItem" :key="i">
        <v-list-item :to="item.to" rounded="lg" class="mb-1 mr-2">
          <v-list-item-avatar start class="v-list-item-avatar--start">
          </v-list-item-avatar>
          <v-list-item-title v-text="item.title"></v-list-item-title>
        </v-list-item>
      </template>
    </v-list>
  </div>
</template>
<style>
.v-toolbar{
  background: #00000047 !important;
}
.router-link-active img{
  filter: invert(96%) sepia(99%) saturate(2%) hue-rotate(59deg) brightness(106%) contrast(100%);
}
.v-toolbar__content {
  display: flex;
  justify-content: space-between !important;
  background: transparent;
}
.v-list-item--active {
  /* background-color: #ee8a6a; */
  color: white;
}
.v-list-item:hover .v-list-item__overlay{
  opacity: 0;
}
.v-list-item__overlay{
  opacity: 0;
}
.v-list{
  background: transparent;
 
}
.v-list a{
  background: transparent;
  color: white;
}
.v-list a:hover{
  color: #dfb22d;
  transition: .3s;
}
.v-list-item__overlay{
  opacity: 0 !important;
}
</style>
