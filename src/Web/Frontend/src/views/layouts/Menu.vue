<script setup>
import { useAuthStore } from '@/stores';

const authStore = useAuthStore();
</script>

<template>
  <aside class="relative bg-sidebar h-screen w-64 hidden sm:block shadow-xl">
      <div class="sidebar_main_header" style="background-color: rgb(253,243,3,1)">


          <center>
              <img style="width:100px" src="/icons/ttu.png" alt="logo">
          </center>
          <div style="color: rgb(26,52,126,1);margin-top: -6px">
              <center>TTU | Admissions</center>
          </div>

      </div>
    <nav class="text-white text-base font-semibold pt-3" style="font-weight: 300; font-size: 0.9rem;">
      <a href='#' class="flex items-center text-white opacity-75 hover:opacity-100 py-4 pl-6 nav-item">

        Course Registration
      </a>
        <a @click="authStore.logout()" class="flex items-center   opacity-75 hover:opacity-100 py-4 pl-6 nav-item">
            <font-awesome-icon icon="fa-solid fa-user-secret" />

            Logout
        </a>
    </nav>
  </aside>
<!--    <aside class="bg-gray-800 text-white w-64">
        <div class="p-4">
            <h3 class="text-xl font-bold">Menu</h3>
        </div>

        <nav>
            <ul>
                <li class="py-2 px-4 cursor-pointer hover:bg-gray-700">
                    <i class="fas fa-home mr-2"></i> Home
                </li>
                <li class="py-2 px-4 cursor-pointer hover:bg-gray-700">
                    <i class="fas fa-user mr-2"></i> Profile
                </li>
                &lt;!&ndash; Add more menu items &ndash;&gt;
            </ul>
        </nav>
    </aside>-->

</template>

<style scoped>

</style>