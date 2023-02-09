<template>
  <v-app>
    <v-layout>
      <v-app-bar elevation="1">
        <v-spacer></v-spacer>
        <div class="text-center">
          <v-menu
          >
            <template v-slot:activator="{ props }">
              <v-btn
                  flat
                  color="secondary-darken-1"
                  class="font-weight-bold"
                  v-bind="props"
                  @click="imageStore.toggleActivity"
              >
                Upload
              </v-btn>
            </template>
          </v-menu>
        </div>
      </v-app-bar>
      <left-navigation/>
      <v-main>
        <!--      <slot/>-->
        <file-upload/>
        <router-view/>
      </v-main>
    </v-layout>
  </v-app>
</template>

<script setup lang="ts">
import FileUpload from "@/components/file-upload.vue";
import {useImageStore} from "@/stores/image-upload";
import LeftNavigation from "@/components/left-navigation.vue";
import {usePostStore} from "@/stores/post";
import {onBeforeMount} from "vue";

const imageStore = useImageStore()
const postStore = usePostStore();


onBeforeMount(() => {
  postStore.initialize()
})
</script>

<style>
:root {
  overflow-y: auto;
}


</style>
