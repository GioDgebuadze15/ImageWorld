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
        initializePost(id: number) {
            $axios.get(`/api/post/${id}`)
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
    title: string
    imageName: string
    content: string
    categories: Array<string>
}