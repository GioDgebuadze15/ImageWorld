<template>
  <v-app>
    <v-layout>
      <v-app-bar elevation="1">
        <v-btn
            icon
            @click="$router.push('/')"
        >
          <v-icon size="x-large">
            mdi-camera-metering-matrix
          </v-icon>
        </v-btn>
        <v-spacer></v-spacer>
        <div class="text-center">
          <v-menu
          >
            <template v-slot:activator="{ props }">
              <v-btn
                  flat
                  color="secondary-darken-1"
                  class="font-weight-bold"
                  v-bind="props"
                  @click="imageStore.toggleActivity"
              >
                Upload
              </v-btn>
            </template>
          </v-menu>
        </div>
        <div>
          <v-btn @click="login">Login</v-btn>
        </div>
      </v-app-bar>

      <v-main>
        <!--      <slot/>-->
        <v-container>
          <file-upload/>
          <router-view/>
        </v-container>
      </v-main>
    </v-layout>
    <v-footer class="d-flex flex-column pa-0 flex-grow-0" border color="#21293b">
      <div class="px-4 py-1 text-center w-100">
        &copy;{{ new Date().getFullYear() }} —
        <strong>Image World</strong>
      </div>
    </v-footer>
  </v-app>
</template>

<script setup lang="ts">
import FileUpload from "@/components/file-upload.vue";
import {useImageStore} from "@/stores/image-upload";
import {usePostsStore} from "@/stores/posts";
import {onBeforeMount, onMounted} from "vue";
import {UserManager, WebStorageStateStore} from "oidc-client"
import {useRoute, useRouter} from "vue-router";

const imageStore = useImageStore()
const postsStore = usePostsStore()

const route = useRoute()
const router = useRouter()


onBeforeMount(() => {
  postsStore.initialize()
})

const userManager = new UserManager({
  userStore: new WebStorageStateStore({store: window.localStorage}),
  authority: 'https://localhost:7058',
  client_id: 'vue-client',
  redirect_uri: 'http://localhost:5173',
  response_type: 'code',
  scope: 'openid profile',
  post_logout_redirect_uri: 'http://localhost:5173',
  // silent_redirect_uri: 'http://localhost:5173',

})

onBeforeMount(() => {
  const {code, scope, session_state} = route.query
  if (code && scope && session_state) {
    userManager.signinRedirectCallback()
        .then(user => {
          router.push('/')
        })
  }
})

const login = () => {
  return userManager.signinRedirect()
}
</script>

<style>
:root {
  overflow-y: auto;
}


</style>
