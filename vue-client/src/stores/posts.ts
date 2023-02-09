import {defineStore} from "pinia";
import $axios from "@/plugins/axios";

export const usePostsStore = defineStore('posts', {
    state: (): State => {
        return {
            posts: [],
            categories:[]
        }
    },
    getters:{
      categoryItems: state => state.categories.map(x=>(x.id))
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
        addPost(post: Object){
            this.posts.push(post)
        }
    }
})

interface State {
    posts: Array<object>
    categories: Array<any>
}