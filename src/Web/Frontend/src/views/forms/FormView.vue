<script setup>
import { storeToRefs } from "pinia";

import { useAuthStore, useUsersStore } from "@/stores";

const authStore = useAuthStore();
const { user: authUser } = storeToRefs(authStore);

const usersStore = useUsersStore();
const { users } = storeToRefs(usersStore);

usersStore.getAll();
</script>
<template>
  <div
    class="flex flex-row items-center rounded-2xl bg-white dark:bg-slate-900/70"
  >
    <div class="flex-1 p-6">
      <div class="block items-center justify-around md:flex lg:justify-center">
        <div class="mb-6 flex items-center justify-center md:mb-0">
          <div class="lg:mx-12">
            <span v-if="users?.pictureUploaded">
              <img
                class="w-full h-full rounded-full"
                src="https://photos.ttuportal.com/public/albums/thumbnails/2022103563.jpg"
                alt=""
              />
            </span>

            <span v-if="!users?.pictureUploaded">
              <router-link
                class="flex items-center px-6 py-2 mt-4 duration-200 border-l-4"
                :class="[$route.name === 'Modal' ? activeClass : inactiveClass]"
                to="/modal"
              >
                <button
                  class="rounded bg-blue-500 py-2 px-4 font-bold text-white hover:bg-blue-700"
                >
                  Start application
                </button>
              </router-link>
            </span>
          </div>
        </div>
        <div class="flex items-center justify-center">
          <div class="space-y-3 text-center md:text-left lg:mx-12">
            <div class="flex justify-center md:block">
              <label class="switch"
                ><input
                  type="checkbox"
                  name="notifications-switch"
                  value="true"
                /><span class="check"></span
                ><span class="pl-2">Notifications</span></label
              >
            </div>
            <h1 class="text-1xl">
              Howdy, <b> {{ users?.fullName }}</b
              >!
            </h1>
            <p class="text-1xl">
              Form No:
              <b>{{ users?.formNo }} </b>
            </p>
            <p class="text-1xl">
              Application Type
              <b>{{ users?.category }}</b>
            </p>

            <span v-if="users?.category == 'Undergraduate'">
              Best Six Grade <b>9 </b>
            </span>

            <div class="flex justify-center md:block">
              <div
                class="inline-flex items-center rounded-full border border-blue-500 bg-blue-500 py-1.5 px-4 text-sm capitalize leading-none text-white"
              >
                <span
                  class="mr-2 inline-flex h-4 w-4 items-center justify-center"
                  ><svg
                    viewBox="0 0 24 24"
                    width="16"
                    height="16"
                    class="inline-block"
                  >
                    <path
                      fill="currentColor"
                      d="M23,12L20.56,9.22L20.9,5.54L17.29,4.72L15.4,1.54L12,3L8.6,1.54L6.71,4.72L3.1,5.53L3.44,9.21L1,12L3.44,14.78L3.1,18.47L6.71,19.29L8.6,22.47L12,21L15.4,22.46L17.29,19.28L20.9,18.46L20.56,14.78L23,12M10,17L6,13L7.41,11.59L10,14.17L16.59,7.58L18,9L10,17Z"
                    ></path></svg
                ></span>
                <span v-if="users?.admitted">Admitted!</span>

                <span class="text-red-500" v-if="!users.admitted"
                  >Admitted!</span
                >
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!---->
  </div>
</template>

<script>
export default {
  data() {
    return {
      imageUrl: null,
    };
  },
  methods: {
    handleFileUpload(event) {
      const file = event.target.files[0];
      if (file) {
        this.imageUrl = URL.createObjectURL(file);
      }
    },
  },
};
</script>

<style>
/* Additional styling for the centered div */
label.relative {
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
