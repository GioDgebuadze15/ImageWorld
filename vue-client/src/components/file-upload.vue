<template>
  <v-dialog
      v-model="imageStore.active"
      persistent
      width="500"
  >
    <v-card>
      <v-card-title class="d-flex text-h6 justify-space-between align-center">
        <div class="d-flex align-center">
          <span v-if="imageStore.step === 1">Upload Image</span>
          <span v-if="imageStore.step === 2">Category</span>
          <span v-if="imageStore.step === 3">Description</span>
          <span v-if="imageStore.step === 4">Confirmation</span>
          <v-avatar
              color="secondary-darken-1"
              size="24"
              v-text="imageStore.step"
              class="ml-2"
          ></v-avatar>
        </div>
        <v-icon class="" @click="close">mdi-close</v-icon>
      </v-card-title>

      <v-window v-model="imageStore.step">
        <v-window-item :value="1">
          <v-card-text>
            <v-file-input
                v-model="selectedFile"
                show-size
                clearable
                label="Image Upload..."
                variant="underlined"
                prepend-icon="mdi-camera"
                accept="image/*"
                @change="handleFile"/>
          </v-card-text>
        </v-window-item>

        <v-window-item :value="2">
          <v-card-text>
            <v-select
                clearable
                chips
                label="Select Category Here"
                :items="postStore.categoryItems"
                multiple
                variant="underlined"
                v-model="form.categories"
            ></v-select>
          </v-card-text>
        </v-window-item>

        <v-window-item :value="3">
          <v-card-text>
            <v-text-field
                placeholder="Enter Description Here..."
                v-model="form.content"
            >

            </v-text-field>
          </v-card-text>
        </v-window-item>

        <v-window-item :value="4">
          <v-card-text>
            <div v-if="form.imageName">
              <v-img :src="`https://localhost:7058/api/image/${form.imageName}`"/>
            </div>
            <div class="d-flex align-center">
              <div v-if="form.content">{{ form.content }}</div>
              <v-spacer/>
              <v-icon
                  color="white"
                  @click="imageStore.step = 2"
              >
                mdi-pencil
              </v-icon>
            </div>
          </v-card-text>
        </v-window-item>
      </v-window>

      <v-divider v-if="imageStore.step ===2 || imageStore.step === 3"></v-divider>

      <v-card-actions v-if="imageStore.step === 2 || imageStore.step ===3">
        <v-spacer></v-spacer>
        <v-btn
            variant="text"
            @click="goNext"
        >
          Next
        </v-btn>

        <v-btn
            variant="text"
            @click="goBack"
        >
          Back
        </v-btn>
      </v-card-actions>

      <div class="d-flex justify-center align-center mb-2">
        <v-btn
            v-if="imageStore.step === 4"
            color="secondary"
            variant="text"
            @click="savePost"
        >
          Save
        </v-btn>
      </div>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import {ref} from "vue";
import {useImageStore} from "@/stores/image-upload";
import '../data/category'
import {Categories} from "@/data/category";
import {usePostStore} from "@/stores/post";

const selectedFile = ref<File | null>(null);

const form = ref({
  imageName: '',
  content: '',
  categories: []
})

// interface Form {
//   selectedFile: Ref<File | null>,
//   imageName: Ref<string>,
//   content: Ref<string>,
//   categories: Ref<Array<string>>
// }


const imageStore = useImageStore()
const postStore = usePostStore()

const handleFile = async (event: Event) => {
  const file: File | undefined = (event.target as HTMLInputElement).files?.[0]
  if (!file) return

  const form = new FormData()
  form.append("image", file)
  imageStore.startImageUpload(form)
  imageStore.step++
}

const savePost = async () => {
  if (!imageStore.uploadPromise) {
    console.log("Upload task is null")
    return
  }

  await imageStore.savePost(form.value)

  imageStore.$reset()
  resetInput()
}


const goNext = async () => {
  if (imageStore.step === 2) {
    const image = await imageStore.uploadPromise
    form.value.imageName = image.data
  }
  imageStore.step++
}
const goBack = () => {
  imageStore.step--
}
const close = () => {
  imageStore.$reset()
  resetInput()
}

const resetInput = () => {
  selectedFile.value = null
  form.value.imageName = ""
  form.value.content = ""
  form.value.categories = []
}


</script>

<style scoped>

</style>