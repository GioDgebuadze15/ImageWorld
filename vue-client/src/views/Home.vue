<template>

  <v-container>
    <v-row v-if="postsStore.posts">
      <v-col
          v-for="p in postsStore.posts"
          :key="`post-${p.imageName}`"
          sm="4"
      >
        <v-card color="post-card-item" elevation="3">
          <router-link :to="`/posts/${p.id}`" >
            <v-img :src="`https://localhost:7058/api/image/${p.imageName}`" class="ma-3"></v-img>
          </router-link>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import {usePostsStore} from "@/stores/posts";

const postsStore = usePostsStore()
</script>

<style scoped>

</style>    