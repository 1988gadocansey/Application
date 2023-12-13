<script setup>
import { RouterLink, RouterView } from 'vue-router';

import { useAuthStore } from '@/stores';

const authStore = useAuthStore();
</script>

<template>
    <div class="flex h-screen">
        <!-- Sidebar -->
        <aside class="w-1/4 bg-gray-200">
            <!-- Sidebar content -->
            <RouterLink to="/" class="nav-item nav-link">Home</RouterLink>
        </aside>

        <!-- Main Content -->
        <main class="w-3/4 bg-white">
            <!-- Main content -->
            <RouterView />
        </main>
    </div>
</template>

<style scoped>
@import '../../assets/base.css';
</style>
