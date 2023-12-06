import { createRouter, createWebHistory } from 'vue-router';

import { useAuthStore } from '@/stores';
import { HomeView, LoginView ,LandingPage,Dashboard} from '@/views';
 

export const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    linkActiveClass: 'active',
    routes: [
        { path: '/', component: LandingPage },
        { path: '/landing', component: LandingPage },
        { path: '/login', component: LoginView },
        { path: '/dashboard', component: Dashboard }
    ]
});

 
