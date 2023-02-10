import {defineStore} from "pinia";
import $axios from "@/plugins/axios";
import type {Category, Post} from "@/data/interfaces";
import {tr} from "vuetify/locale";

export const usePostsStore = defineStore('posts', {
    state: (): State => {
        return {
            posts: [],
            filteredPosts: [],
            categories: [],
            filterStatus: false
        }
    },
    getters: {
        categoryItems: state => state.categories.map(x => (x.id))
    },
    actions: {
        initialize() {
            $axios.get('/api/post').then(res => {
                this.posts = res.data
            })
            $axios.get('/api/categories').then(res => {
                this.categories = res.data
            })
        },
        addPost(post: Post) {
            this.posts.push(post)
        },
        filterByCategory(selectedCategories: Array<string>) {
            this.filteredPosts = this.posts.filter(post => post.categories.some(category => selectedCategories.includes(category.id)))
            this.filterStatus = true
        }
    }
})

interface State {
    posts: Array<Post>
    filteredPosts: Array<Post>
    categories: Array<Category>
    filterStatus: boolean
}

