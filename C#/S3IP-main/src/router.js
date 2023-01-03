
import { createRouter, createWebHistory } from 'vue-router'


  const routes = [
    {
      path: "/",
      alias: "/posts",
      name: "posts",
      component: () => import("./components/IndexPage")
    },
    {
      path: "/add",
      name: "add",
      component: () => import("./components/AddPost")
    }
  ]

  const router = createRouter({
    history: createWebHistory(),
    routes
  });

export default router;

