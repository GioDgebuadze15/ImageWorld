<template>
  <v-card
      color="post-card-item"
      class="mx-auto my-10 pa-3"
      max-width="400"
      v-if="postStore.post"
  >
    <v-img
        width="400"
        :src="`https://localhost:7058/api/image/${postStore.post.imageName}`"
        cover
    ></v-img>

    <v-card-title>
      Title: {{ postStore.post?.title }}
    </v-card-title>

    <v-card-subtitle v-if=" postStore.post.categories">
      Categories:
      <v-chip-group v-for="c in postStore.getCategories">
          <v-chip @click="$router.push(`/categories/${c}`)" size="small">{{ c }}</v-chip>
      </v-chip-group>
    </v-card-subtitle>

    <v-card-actions class="pa-0" v-if="postStore.post.content">
      <v-spacer></v-spacer>
      <v-btn
          icon
          color="orange-lighten-2"
          @click="showContent = !showContent"
      >
        <v-icon size="large"> {{ showContent ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
      </v-btn>
    </v-card-actions>

    <v-expand-transition>
      <div v-show="showContent">
        <v-divider></v-divider>
        <v-card-text>
          {{ postStore.post?.content }}
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
  <div v-else>No Content - Go to home page</div>
</template>

<script setup lang="ts">
import {onBeforeMount, ref} from "vue";
import {usePostStore} from "@/stores/post";
import {useRoute} from "vue-router";


const postStore = usePostStore()
const route = useRoute()


onBeforeMount(() => {
  //Todo: any better way?
  const postId = parseInt(route.params.postId as string)
  if (!isNaN(postId))
    postStore.initializePost(postId)
})

const showContent = ref(false)
</script>

<style scoped>

</style>    