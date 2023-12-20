<script setup>
import {storeToRefs} from 'pinia';

import {useAuthStore, useUsersStore} from '@/stores';

const authStore = useAuthStore();
const {user: authUser} = storeToRefs(authStore);

const usersStore = useUsersStore();
const {users} = storeToRefs(usersStore);
</script>

<template>
  <header class="w-full items-center bg-white py-2 px-6 hidden sm:flex">
    <div class="w-1/2">Hi, {{ users.fullName }}</div>
    <div x-data="{ isOpen: false }" class="relative w-1/2 flex justify-end">
      <button x-on:click="isOpen = !isOpen"
              class="realtive z-10 w-12 h-12 rounded-full overflow-hidden border-4 border-gray-400 hover:border-gray-300 focus:border-gray-300 focus:outline-none">
        <img src="https://photos.ttuportal.com/public/albums/thumbnails/2022103563.jpg">
      </button>
      <button x-show="isOpen" x-on:click="isOpen = false" class="h-full w-full fixed inset-0 cursor-default"></button>
      <div x-show="isOpen" class="absolute w-40 bg-white rounded-lg text-sm shadow-lg mt-16 z-50">
        <a href='{!! url("/biodataUpdate") !!}' class="block px-4 py-2 rounded-t-lg account-link   hover:text-white  hover:bg-blue-500">
          Profile
        </a>
        <a href="{{route('password.change')}}" class="block px-4 py-2 account-link   hover:text-white  hover:bg-blue-500">
          Change Password
        </a>
        <a @click="authStore.logout()" class="block px-4 py-2 rounded-b-lg account-link  hover:text-white   hover:bg-blue-500">
          Sign Out</a>

      </div>
    </div>
  </header>

  <!-- Mobile Header & Nav -->
  <header x-data="{ isOpen: false }" class="w-full bg-sidebar py-5 px-6 sm:hidden " style="background-color: #1a337e;">
    <div class="flex items-center justify-between">
      <div class="p-6">
        <a href="/dashboard"><img src="/icons/seal.png" alt="logo" style="width: 160px"/></a>
      </div>
      <div x-data="{ isOpen: false }" class="relative w-1/2 flex justify-end">
        <button x-on:click="isOpen = !isOpen"
                class="realtive z-10 w-12 h-12 rounded-full overflow-hidden border-4 border-gray-400 hover:border-gray-300 focus:border-gray-300 focus:outline-none">
          <img src="https://photos.ttuportal.com/public/albums/thumbnails/2022103563.jpg">
        </button>
        <button x-show="isOpen" x-on:click="isOpen = false" class="h-full w-full fixed inset-0 cursor-default"></button>
        <div x-show="isOpen" class="absolute w-40 bg-white rounded-lg text-sm shadow-lg mt-16 z-50">
          <a href='{!! url("/biodataUpdate") !!}' class="block px-4 py-2 rounded-t-lg account-link   hover:text-white  hover:bg-blue-500">
            Profile
          </a>
          <a href="{{route('password.change')}}" class="block px-4 py-2 account-link hover:text-white  hover:bg-blue-500">
            Change Password
          </a>
          <a @click="authStore.logout()" class="block px-4 py-2 rounded-b-lg account-link   hover:text-white  hover:bg-blue-500">
            Sign Out</a>

        </div>
      </div>
    </div>


    <!-- Dropdown Nav -->
    <!--    <nav x-bind:class="isOpen ? 'flex': 'hidden'" class="flex flex-col pt-4">
          <a href="index.html" class="flex items-center active-nav-link text-white py-2 pl-4 nav-item">
            <i class="fas fa-tachometer-alt mr-3"></i>
            Dashboard
          </a>
          <a href="blank.html" class="flex items-center text-white opacity-75 hover:opacity-100 py-2 pl-4 nav-item">
            <i class="fas fa-sticky-note mr-3"></i>
            Blank Page
          </a>
          <a href="tables.html" class="flex items-center text-white opacity-75 hover:opacity-100 py-2 pl-4 nav-item">
            <i class="fas fa-table mr-3"></i>
            Tables
          </a>
          <a href="forms.html" class="flex items-center text-white opacity-75 hover:opacity-100 py-2 pl-4 nav-item">
            <i class="fas fa-align-left mr-3"></i>
            Forms
          </a>
          <a href="tabs.html" class="flex items-center text-white opacity-75 hover:opacity-100 py-2 pl-4 nav-item">
            <i class="fas fa-tablet-alt mr-3"></i>
            Tabbed Content
          </a>
          <a href="calendar.html" class="flex items-center text-white opacity-75 hover:opacity-100 py-2 pl-4 nav-item">
            <i class="fas fa-calendar mr-3"></i>
            Calendar
          </a>
          <a href="#" class="flex items-center text-white opacity-75 hover:opacity-100 py-2 pl-4 nav-item">
            <i class="fas fa-cogs mr-3"></i>
            Change Password
          </a>
          <a href="#" class="flex items-center text-white opacity-75 hover:opacity-100 py-2 pl-4 nav-item">
            <i class="fas fa-user mr-3"></i>
            My Account
          </a>
          <a href="{{ url('/logout') }}"
             class="flex items-center text-white opacity-75 hover:opacity-100 py-2 pl-4 nav-item">
            <i class="fas fa-sign-out-alt mr-3">
              <form id="logout-form" action="{{ url('/logout') }}" method="POST" style="display: none;">

              </form>
            </i>
            Sign Out
          </a>

        </nav>-->
  </header>

</template>

<style scoped>

</style>