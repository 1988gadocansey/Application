<script setup>
import { RouterLink, RouterView } from 'vue-router';

import {useAuthStore, useUsersStore} from '@/stores';
import {storeToRefs} from "pinia";
import Menu from "@/views/layouts/Menu.vue";
import Header from "@/views/layouts/Header.vue";

const authStore = useAuthStore();
const { user: authUser } = storeToRefs(authStore);

const usersStore = useUsersStore();
const { users } = storeToRefs(usersStore);
</script>

<template>
<!--    <div class="flex h-screen">
        &lt;!&ndash; Sidebar &ndash;&gt;
        <aside class="w-1/4 bg-gray-200">
            &lt;!&ndash; Sidebar content &ndash;&gt;
            <RouterLink to="/" class="nav-item nav-link">Home</RouterLink>
        </aside>

        &lt;!&ndash; Main Content &ndash;&gt;
        <main class="w-3/4 bg-white">
            &lt;!&ndash; Main content &ndash;&gt;

        </main>
    </div>-->

    <div class="flex">
         <Menu/>

        <div class="w-full flex flex-col h-screen overflow-y-hidden">
             <Header/>
            <div class="w-full overflow-x-hidden border-t flex flex-col relative">
                <main class="w-full flex-grow p-6 h-screen overflow-auto">
                    <RouterView />
                </main>
                <footer class="w-full bg-white text-right p-4 absolute bottom-0">
                    <small>&copy; {{ new Date().getFullYear() }} | Takoradi Technical University | Designed by DoICT.</small>
                </footer>
            </div>
        </div>
    </div>
</template>

<style scoped>
@import '../../assets/app.css';
</style>
