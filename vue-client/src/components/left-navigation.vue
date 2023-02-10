<template>
  <v-navigation-drawer
      elevation="1"
      location="left"
      permanent
  >
    <div class="d-flex">
      <v-spacer/>
      <v-icon
          class="ma-3"
          size="large"
          @click="showContent = !showContent"
      >
        {{ !showContent ? 'mdi-filter-menu-outline' : 'mdi-filter-outline' }}
      </v-icon>
    </div>

    <div
        class="d-flex flex-column align-start justify-center w-75 float-end"
        v-if="showContent"
    >
      <v-checkbox
          v-for="c in postsStore.categories" :key="`category-${c.id}`"
          v-model="selectedCategories"
          :label="`${c.id}`"
          :value="c.id"
          color="info"
          hide-details="true"
          @change="selectCategory"/>
    </div>

  </v-navigation-drawer>
</template>

<script lang="ts" setup>
import {usePostsStore} from "@/stores/posts";
import {ref} from "vue";

const postsStore = usePostsStore()

const selectedCategories = ref([] as Array<string>)
const showContent = ref(false)

const selectCategory = () => {
  if (selectedCategories.value.length < 1) {
    postsStore.filteredPosts = []
    postsStore.filterStatus = false
    return
  }

  postsStore.filterByCategory(selectedCategories.value)
}

</script>

<style scoped>

</style>