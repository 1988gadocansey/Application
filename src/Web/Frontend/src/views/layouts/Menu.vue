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
        to="/ui-elements"
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

        <span class="mx-4">UI Elements</span>
      </router-link>
      <router-link
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        :class="[$route.name === 'Modal' ? activeClass : inactiveClass]"
        to="/modal"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          class="w-5 h-5"
          viewBox="0 0 20 20"
          fill="currentColor"
        >
          <path
            d="M3 12v3c0 1.657 3.134 3 7 3s7-1.343 7-3v-3c0 1.657-3.134 3-7 3s-7-1.343-7-3z"
          />
          <path
            d="M3 7v3c0 1.657 3.134 3 7 3s7-1.343 7-3V7c0 1.657-3.134 3-7 3S3 8.657 3 7z"
          />
          <path
            d="M17 5c0 1.657-3.134 3-7 3S3 6.657 3 5s3.134-3 7-3 7 1.343 7 3z"
          />
        </svg>

        <span class="mx-4">Modal</span>
      </router-link>
      <router-link
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        :class="[$route.name === 'Modal' ? activeClass : inactiveClass]"
        to="/modal"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          class="w-5 h-5"
          viewBox="0 0 20 20"
          fill="currentColor"
        >
          <path
            d="M3 12v3c0 1.657 3.134 3 7 3s7-1.343 7-3v-3c0 1.657-3.134 3-7 3s-7-1.343-7-3z"
          />
          <path
            d="M3 7v3c0 1.657 3.134 3 7 3s7-1.343 7-3V7c0 1.657-3.134 3-7 3S3 8.657 3 7z"
          />
          <path
            d="M17 5c0 1.657-3.134 3-7 3S3 6.657 3 5s3.134-3 7-3 7 1.343 7 3z"
          />
        </svg>

        <span class="mx-4">Modal</span>
      </router-link>
      <p class="pl-4 text-xs my-2 font-semibold mb-4 text-gray-400">About</p>
      <a
        target="_blank"
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        :class="[$route.name === 'Blank' ? activeClass : inactiveClass]"
        href="https://github.com/tal7aouy"
      >
        <svg
          class="w-5 h-5 fill-current"
          viewBox="0 0 24 24"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            d="M12.026 2C7.13295 1.99937 2.96183 5.54799 2.17842 10.3779C1.395 15.2079 4.23061 19.893 8.87302 21.439C9.37302 21.529 9.55202 21.222 9.55202 20.958C9.55202 20.721 9.54402 20.093 9.54102 19.258C6.76602 19.858 6.18002 17.92 6.18002 17.92C5.99733 17.317 5.60459 16.7993 5.07302 16.461C4.17302 15.842 5.14202 15.856 5.14202 15.856C5.78269 15.9438 6.34657 16.3235 6.66902 16.884C6.94195 17.3803 7.40177 17.747 7.94632 17.9026C8.49087 18.0583 9.07503 17.99 9.56902 17.713C9.61544 17.207 9.84055 16.7341 10.204 16.379C7.99002 16.128 5.66202 15.272 5.66202 11.449C5.64973 10.4602 6.01691 9.5043 6.68802 8.778C6.38437 7.91731 6.42013 6.97325 6.78802 6.138C6.78802 6.138 7.62502 5.869 9.53002 7.159C11.1639 6.71101 12.8882 6.71101 14.522 7.159C16.428 5.868 17.264 6.138 17.264 6.138C17.6336 6.97286 17.6694 7.91757 17.364 8.778C18.0376 9.50423 18.4045 10.4626 18.388 11.453C18.388 15.286 16.058 16.128 13.836 16.375C14.3153 16.8651 14.5612 17.5373 14.511 18.221C14.511 19.555 14.499 20.631 14.499 20.958C14.499 21.225 14.677 21.535 15.186 21.437C19.8265 19.8884 22.6591 15.203 21.874 10.3743C21.089 5.54565 16.9181 1.99888 12.026 2Z"
          ></path>
        </svg>

        <span class="mx-4">Profile</span>
      </a>

      <a
        @click="authStore.logout()"
        class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
        :class="[$route.name === 'Blank' ? activeClass : inactiveClass]"
      >
        <svg
          class="w-5 h-5 fill-current"
          viewBox="0 0 24 24"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            d="M12.026 2C7.13295 1.99937 2.96183 5.54799 2.17842 10.3779C1.395 15.2079 4.23061 19.893 8.87302 21.439C9.37302 21.529 9.55202 21.222 9.55202 20.958C9.55202 20.721 9.54402 20.093 9.54102 19.258C6.76602 19.858 6.18002 17.92 6.18002 17.92C5.99733 17.317 5.60459 16.7993 5.07302 16.461C4.17302 15.842 5.14202 15.856 5.14202 15.856C5.78269 15.9438 6.34657 16.3235 6.66902 16.884C6.94195 17.3803 7.40177 17.747 7.94632 17.9026C8.49087 18.0583 9.07503 17.99 9.56902 17.713C9.61544 17.207 9.84055 16.7341 10.204 16.379C7.99002 16.128 5.66202 15.272 5.66202 11.449C5.64973 10.4602 6.01691 9.5043 6.68802 8.778C6.38437 7.91731 6.42013 6.97325 6.78802 6.138C6.78802 6.138 7.62502 5.869 9.53002 7.159C11.1639 6.71101 12.8882 6.71101 14.522 7.159C16.428 5.868 17.264 6.138 17.264 6.138C17.6336 6.97286 17.6694 7.91757 17.364 8.778C18.0376 9.50423 18.4045 10.4626 18.388 11.453C18.388 15.286 16.058 16.128 13.836 16.375C14.3153 16.8651 14.5612 17.5373 14.511 18.221C14.511 19.555 14.499 20.631 14.499 20.958C14.499 21.225 14.677 21.535 15.186 21.437C19.8265 19.8884 22.6591 15.203 21.874 10.3743C21.089 5.54565 16.9181 1.99888 12.026 2Z"
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
