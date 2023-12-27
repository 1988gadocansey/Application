<script setup>
import { useAuthStore } from "@/stores";
import { ref } from "vue";

const authStore = useAuthStore();
//const { isOpen } = useSidebar();
const activeClass = ref(
  "bg-gray-600 bg-opacity-25 text-gray-100 border-gray-100"
);
const inactiveClass = ref(
  "border-gray-900 text-gray-500 hover:bg-gray-600 hover:bg-opacity-25 hover:text-gray-100"
);
</script>

<template>
  <aside class="relative bg-sidebar h-screen w-64 hidden sm:block shadow-xl">
    <div class="p-6">
      <a href="/dashboard"
        ><img src="/icons/seal.png" alt="logo" style="width: 160px"
      /></a>
    </div>
    <nav
      class="text-white text-base font-semibold pt-3"
      style="font-weight: 300; font-size: 0.9rem"
    >
      <p class="pl-4 text-xs font-semibold mb-4 text-gray-400">Home</p>
      <router-link
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        :class="[$route.name === 'Dashboard' ? activeClass : inactiveClass]"
        to="/dashboard"
      >
        <svg
          class="w-5 h-5"
          fill="none"
          stroke="currentColor"
          viewBox="0 0 24 24"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"
          ></path>
        </svg>

        <span class="mx-4">Dashboard</span>
      </router-link>
      <p class="pl-4 my-2 text-xs font-semibold mb-4 text-gray-400">
        Application Process
      </p>

      <router-link
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        to="/photo/upload"
      >
        <svg
          class="w-5 h-5"
          viewBox="0 0 20 20"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            d="M5 3C3.89543 3 3 3.89543 3 5V7C3 8.10457 3.89543 9 5 9H7C8.10457 9 9 8.10457 9 7V5C9 3.89543 8.10457 3 7 3H5Z"
            fill="currentColor"
          />
          <path
            d="M5 11C3.89543 11 3 11.8954 3 13V15C3 16.1046 3.89543 17 5 17H7C8.10457 17 9 16.1046 9 15V13C9 11.8954 8.10457 11 7 11H5Z"
            fill="currentColor"
          />
          <path
            d="M11 5C11 3.89543 11.8954 3 13 3H15C16.1046 3 17 3.89543 17 5V7C17 8.10457 16.1046 9 15 9H13C11.8954 9 11 8.10457 11 7V5Z"
            fill="currentColor"
          />
          <path
            d="M11 13C11 11.8954 11.8954 11 13 11H15C16.1046 11 17 11.8954 17 13V15C17 16.1046 16.1046 17 15 17H13C11.8954 17 11 16.1046 11 15V13Z"
            fill="currentColor"
          />
        </svg>

        <span class="mx-4">Upload Picture</span>
      </router-link>
      <router-link
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        :class="[$route.name === 'Modal' ? activeClass : inactiveClass]"
        to="/modal"
      >
        <svg class="w-5 h-5" fill="currentColor" viewBox="0 0 20 20">
          <path
            d="M17.414 2.586a2 2 0 00-2.828 0L7 10.172V13h2.828l7.586-7.586a2 2 0 000-2.828z"
          ></path>
          <path
            fill-rule="evenodd"
            d="M2 6a2 2 0 012-2h4a1 1 0 010 2H4v10h10v-4a1 1 0 112 0v4a2 2 0 01-2 2H4a2 2 0 01-2-2V6z"
            clip-rule="evenodd"
          ></path>
        </svg>

        <span class="mx-4">Fill Form</span>
      </router-link>
      <router-link
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        :class="[$route.name === 'Modal' ? activeClass : inactiveClass]"
        to="/modal"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
        >
          <path d="M14 8v5h3l-4 4-4-4h3V8z" />
          <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" />
        </svg>

        <span class="mx-4">Upload Results</span>
      </router-link>
      <p class="pl-4 text-xs my-2 font-semibold mb-4 text-gray-400">About</p>
      <a
        target="_blank"
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        :class="[$route.name === 'Blank' ? activeClass : inactiveClass]"
        href="https://github.com/tal7aouy"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
        >
          <circle cx="12" cy="7" r="4" />
          <path d="M2 20c0-5 4-9 9-9h2c5 0 9 4 9 9" />
        </svg>

        <span class="mx-4">Preview Form</span>
      </a>

      <a
        @click="authStore.logout()"
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        :class="[$route.name === 'Blank' ? activeClass : inactiveClass]"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          class="h-5 w-5 mr-1"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
          stroke-width="2"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"
          ></path>
        </svg>

        <span class="mx-4">Logout</span>
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

<style scoped></style>
