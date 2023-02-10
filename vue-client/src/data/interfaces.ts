export interface Post {
    id: number
    title: string | null
    imageName: string
    content: string | null
    categories: Array<Category>
}

export interface Category {
    id: string
    deleted: boolean
}