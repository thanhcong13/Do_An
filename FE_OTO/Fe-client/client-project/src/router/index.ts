import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  //history: createWebHistory(import.meta.env.BASE_URL),
  history: createWebHistory("/"),
  routes: [
    {
      path: "/",
      redirect: "/home",
      component: () => import("@/layouts/FullLayout.vue"),

      children: [
        {
          name: "Dashboard",
          path: "/home",
          component: () => import("@/views/ui-views/UIHome.vue"),
        },
        {
          name: "CarPage",
          path: "products",
          component: () => import("@/views/ui-views/CarPage.vue"),
        },
        {
          name: "AboutPage",
          path: "about",
          component: () => import("@/views/ui-views/AboutPage.vue"),
        },
        {
          name: "Blog",
          path: "blog",
          component: () => import("@/views/ui-views/BlogPage.vue"),
        },
        {
          name: "Contact",
          path: "baoduong",
          component: () => import("@/views/BaoDuong/BaoDuongPage.vue"),
        },
        {
          name: "Order",
          path: "hotels/:id/:roomId",
          component: () => import("@/views/Order/OrderIndex.vue"),
        },
        {
          name: "OrderEdit",
          path: "/order/:id",
          component: () => import("@/views/Order/OrderEdit.vue"),
        },
        {
          name: "Thanks",
          path: "/thankspage",
          component: () => import("@/views/Order/ThanksPage.vue"),
        },
        {
          name: "OrderList",
          path: "/orderlist",
          component: () => import("@/views/Order/OrderList.vue"),
        },
        {
          name: "Accout",
          path: "/accout",
          component: () => import("@/views/Accout/AccoutIndex.vue"),
        },
        {
          name: "OrderEdit",
          path: "/order/:id",
          component: () => import("@/views/Order/OrderEdit.vue"),
        },
        {
          name: "LienHe",
          path: "/products/lienhe",
          component: () => import("@/views/LienHe/LienHePage.vue"),
        },
        {
          name: "LaiThu",
          path: "/products/laithu",
          component: () => import("@/views/LaiThu/LaiThuPage.vue"),
        },
        {
          path: "products/:id",
          name: "Car",
          component: () => import("@/views/CarDetail/CarDetailIndex.vue"),
          children: [],
        },
        {
          path: "blog",
          name: "BlogDetail",
          component: () => import("@/views/BLog/BlogDetail.vue"),
        },
      ],
    },
    {
      name: "login",
      path: "/login",
      component: () => import("@/views/ui-views/Accouts/LoginPage.vue"),
    },
    {
      name: "Register",
      path: "/register",
      component: () => import("@/views/ui-views/Accouts/RegisterPage.vue"),
    },
    // {
    //   name: "Login",
    //   path: "/login",
    //   component: () => import("@/views/Login.vue"),
    // },
  ],
});
// router.beforeEach(async (to, from) => {
//   const isAuthenticated = localStorage.getItem("token");
//   console.log(isAuthenticated);

//   if (
//     // make sure the user is authenticated
//     !isAuthenticated &&
//     // Avoid an infinite redirect
//     to.name !== "Login"
//   ) {
//     // redirect the user to the login page
//     return { name: "Login" };
//   }
// });
export default router;
