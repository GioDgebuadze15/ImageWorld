import {defineStore} from "pinia";
import $axios from "@/plugins/axios";
import type {Post} from "@/data/interfaces";

export const useCategoriesStore = defineStore('categories', {
    state: (): State => {
        return {
            posts: []
        }
    },
    actions: {
        initialize(categoryId: string) {
            $axios.get(`/api/categories/${categoryId}/posts`)
                .then(res => {
                    this.posts = res.data
                })
        }
    }
})

interface State {
    posts: Array<Post>
}