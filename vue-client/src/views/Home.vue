<template>
  <posts-view :posts="!postsStore.filterStatus ? postsStore.posts : postsStore.filteredPosts"/>
  <left-navigation
      class="d-none d-sm-none d-md-block"/>
</template>

<script setup lang="ts">
import {usePostsStore} from "@/stores/posts";
import PostsView from "@/components/posts-view.vue";
import LeftNavigation from "@/components/left-navigation.vue";

const postsStore = usePostsStore()
</script>

<style scoped>

</style>    