<script setup>

import { RouterLink, RouterView } from 'vue-router';

import { useAuthStore } from '@/stores';

const authStore = useAuthStore();
</script>

<template>
    <component :is="layout">
        <router-view></router-view>
    </component>
</template>

<script>
import HomeLayout from "@/views/layouts/HomeLayout.vue";

export default {
    computed: {
        layout() {
            // Get the layout component from route meta or use a default layout
            return this.$route.meta.layout || HomeLayout;
        }
    }
};
</script>




<style>
@import 'assets/base.css';
</style>