<template>
  <posts-view :posts="postsStore.posts"/>
</template>

<script setup lang="ts">
import {usePostsStore} from "@/stores/posts";
import PostsView from "@/components/posts-view.vue";

const postsStore = usePostsStore()
</script>

<style scoped>

</style>    