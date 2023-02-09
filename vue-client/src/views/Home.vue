<template>

  <v-container>
    <v-row v-if="postStore.posts.values()">
      <v-col
          v-for="p in postStore.posts"
          :key="`post-${p.id}`"
          sm="4"
      >
        <v-card color="image-card-item" elevation="3">
          <router-link :to="`/images/${p.imageName}`" >
            <v-img :src="`https://localhost:7058/api/image/${p.imageName}`" class="ma-3"></v-img>
          </router-link>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import {usePostStore} from "@/stores/post";

const postStore = usePostStore()
</script>

<style scoped>

</style>    