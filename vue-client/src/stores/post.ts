import {defineStore} from "pinia";
import $axios from "@/plugins/axios";
import type {Post} from "@/data/interfaces";

export const usePostStore = defineStore('post', {
    state: (): State => {
        return {
            post: null
        }
    },
    getters: {
        getCategories: state => state.post?.categories.map(x => x.id)
    },
    actions: {
        initializePost(postId: number) {
            $axios.get(`/api/post/${postId}`)
                .then(res => {
                    this.post = res.data
                })
        }
    }
})

interface State {
    post: Post | null
}

