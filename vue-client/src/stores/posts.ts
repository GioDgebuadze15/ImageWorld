import {defineStore} from "pinia";
import $axios from "@/plugins/axios";
import type {Category, Post} from "@/data/interfaces";

export const usePostsStore = defineStore('posts', {
    state: (): State => {
        return {
            posts: [],
            filteredPostsByCategory: [],
            categories: [],
            filterByCategoryStatus: false
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
            this.filteredPostsByCategory = this.posts.filter(post => post.categories.some(category => selectedCategories.includes(category.id)))
            this.filterByCategoryStatus = true
        }
    }
})

interface State {
    posts: Array<Post>
    filteredPostsByCategory: Array<Post>
    categories: Array<Category>
    filterByCategoryStatus: boolean
}

