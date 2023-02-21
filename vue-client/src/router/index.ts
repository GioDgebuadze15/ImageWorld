import {createRouter, createWebHistory} from 'vue-router'
import Home from '../views/Home.vue'
import PostView from '../views/post/PostView.vue'
import CategoryView from '../views/category/CategoryView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home
        },
        {
            path: '/post/:postId?',
            name: 'post',
            component: PostView
        },
        {
            path: '/category/:categoryId?',
            name: 'category',
            component: CategoryView
        },
        // {
        //   path: '/about',
        //   name: 'about',
        //   // route level code-splitting
        //   // this generates a separate chunk (About.[hash].js) for this route
        //   // which is lazy-loaded when the route is visited.
        //   component: () => import('../views/AboutView.vue')
        // }
    ]
})

export default router
