<template>
  <posts-view :posts="categoriesStore.posts"/>
</template>

<script setup lang="ts">
import PostsView from "@/components/posts-view.vue";
import {useCategoriesStore} from "@/stores/categories";
import {onBeforeMount} from "vue";
import {useRoute} from "vue-router";

const categoriesStore = useCategoriesStore()
const route = useRoute()

onBeforeMount(() => {
  const categoryId = route.params.categoryId as string
  categoriesStore.initialize(categoryId)
})
</script>

<style scoped>

</style>