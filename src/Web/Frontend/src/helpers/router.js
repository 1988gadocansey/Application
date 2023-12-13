import { createRouter, createWebHistory } from 'vue-router';

import { useAuthStore } from '@/stores';


import MainLayout from '../views/layouts/MainLayout.vue';
import PrintLayout from '../views/layouts/PrintLayout.vue';
import HomeLayout from '../views/layouts/HomeLayout.vue';
import {HomeView, LoginView, LandingPage, Dashboard, Preview} from '@/views';

const routes = [
    {
        path: '/',
        component: LoginView,
        meta: { layout: HomeLayout } // Assign default layout
    },
    {
        path: '/login',
        component: LoginView,
        meta: { layout: HomeLayout } // Assign default layout
    },
    {
        path: '/dashboard',
        component: Dashboard,
        meta: { layout: MainLayout } // Assign custom layout
    },
    {
        path: '/preview',
        component: Preview,
        meta: { layout: PrintLayout } // Assign custom layout
    },
    // Other routes with their respective layouts
];

export const router = createRouter({
    //history: createWebHistory(),
    history: createWebHistory(import.meta.env.BASE_URL),
    linkActiveClass: 'active',
    routes
});



