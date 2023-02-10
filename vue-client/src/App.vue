<template>
  <v-app>
    <v-layout>
      <v-app-bar elevation="1">
        <v-btn
            icon
            @click="$router.push('/')"
        >
          <v-icon size="x-large">
            mdi-camera-metering-matrix
          </v-icon>
        </v-btn>
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
      <left-navigation 
          class="d-none d-sm-none d-md-block"/>
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
import {usePostsStore} from "@/stores/posts";
import {onBeforeMount} from "vue";

const imageStore = useImageStore()
const postsStore = usePostsStore();


onBeforeMount(() => {
  postsStore.initialize()
})
</script>

<style>
:root {
  overflow-y: auto;
}


</style>
