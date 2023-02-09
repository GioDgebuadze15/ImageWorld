﻿import {defineStore} from "pinia";
import $axios from "@/plugins/axios";
import {usePostStore} from "@/stores/post";

export const useImageStore = defineStore('image', {
    state: (): State => {
        return {
            uploadPromise: null as Promise<any> | null,
            active: false,
            step: 1
        }
    },
    actions: {
        startImageUpload(form: FormData) {
            this.uploadPromise = $axios.post('/api/image', form)
        },
        toggleActivity() {
            this.active = !this.active
        },
        async savePost(form: Object) {
            const result = await $axios.post('/api/post', form)
            const homeStore = usePostStore()
            homeStore.addPost(result.data)
        }
    }
})

interface State {
    uploadPromise: Promise<any> | null,
    active: boolean | false,
    step: number
}