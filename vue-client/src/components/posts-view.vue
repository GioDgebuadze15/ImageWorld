<template>
  <v-container class="pa-5">
    <v-row v-if="props.posts">
      <v-col
          v-for="p in props.posts"
          :key="`post-${p.imageName}`"
          sm="3"
      >
        <v-card color="post-card-item" elevation="3">
          <router-link :to="`/post/${p.id}`">
            <v-img :src="`https://localhost:7058/api/image/${p.imageName}`" class="ma-3"></v-img>
          </router-link>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import type {Post} from "@/data/interfaces";

interface Props {
  posts: Array<Post> | null
}

const props = defineProps<Props>()

</script>

<style scoped>

</style>