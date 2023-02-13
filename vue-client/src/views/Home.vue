<template>
  <div class="d-flex mt-3 justify-center align-start">
    <v-text-field
        class="mx-2"
        label="Search"
        placeholder="e.g. title/description"
        prepend-inner-icon="mdi-magnify"
        variant="outlined"
        v-model="filter"
        @input="filteredPosts"
    >
    </v-text-field>
  </div>
  
  <div class="d-flex">
    <left-navigation/>
    <posts-view :posts="filteredPosts()"/>

  </div>
  <!--  <left-navigation-->
  <!--      class="d-none d-sm-none d-md-block"/>-->
</template>

<script setup lang="ts">
import {usePostsStore} from "@/stores/posts";
import PostsView from "@/components/posts-view.vue";
import LeftNavigation from "@/components/left-navigation.vue";
import {ref} from "vue";
import type {Post} from "@/data/interfaces";

const postsStore = usePostsStore()

const filter = ref("")
const offsetTop = ref(0)

const filteredPosts = (): Array<Post> => {
  const normalize = filter.value.trim().toLowerCase();
  const posts = postsStore.filterByCategoryStatus
      ? postsStore.filteredPostsByCategory
      : postsStore.posts;

  return filter
      ? posts.filter(p => p.title?.toLowerCase().includes(normalize) || p.content?.toLowerCase().includes(normalize))
      : posts;
}

// const onScroll = (e: Event) => {
//   offsetTop.value = (e.target as HTMLInputElement).scrollTop as number
// }
</script>

<style scoped>

</style>    