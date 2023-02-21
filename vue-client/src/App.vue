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
        <v-btn
            @click="api('test')"
        >
          test
        </v-btn>
        <v-spacer></v-spacer>
        <div class="text-center">
          <v-menu
          >
            <template v-slot:activator="{ props }">
              <v-btn
                  class="font-weight-bold"
                  color="secondary-darken-1"
                  flat
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
          <v-btn @click="logout">Logout</v-btn>
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
    <v-footer border class="d-flex flex-column pa-0 flex-grow-0" color="#21293b">
      <div class="px-4 py-1 text-center w-100">
        &copy;{{ new Date().getFullYear() }} —
        <strong>Image World</strong>
      </div>
    </v-footer>
  </v-app>
</template>

<script lang="ts" setup>
import FileUpload from "@/components/file-upload.vue";
import {useImageStore} from "@/stores/image-upload";
import {usePostsStore} from "@/stores/posts";
import {onBeforeMount} from "vue";
import {UserManager, WebStorageStateStore} from "oidc-client"
import {useRoute, useRouter} from "vue-router";
import $axios from "@/plugins/axios";

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
  redirect_uri: 'http://localhost:5173/public/static/oidc/callback.html',
  response_type: 'code',
  scope: 'openid profile IdentityServerApi role',
  post_logout_redirect_uri: 'http://localhost:5173',
  // silent_redirect_uri: 'http://localhost:5173',

})


const login = () => {
  return userManager.signinRedirect()
}

const logout = () => {
  return userManager.signoutRedirect()
}

const api = async (x: any) => {

  const user = await userManager.getUser()
  if (!user) return
  $axios.defaults.headers.common['Authorization'] = `bearer ${user.access_token}`
  return $axios.get('api/post/' + x)
      .then(msg => console.log(msg))
}
</script>

<style>
:root {
  overflow-y: auto;
}


</style>
