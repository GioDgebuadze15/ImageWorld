import {defineStore} from "pinia";
import $axios from "@/plugins/axios";

export const usePostStore = defineStore('post', {
    state: (): State => {
        return {
            post: null
        }
    },
    getters:{
        getCategories: state => state.post?.categories
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

interface Post {
    id: number
    title: string | null
    imageName: string
    content: string | null
    categories: Array<string>
}