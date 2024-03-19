<script setup>
import { storeToRefs } from "pinia";
import { Form, Field } from "vee-validate";
import { usePhotoStore } from "@/stores";
function uploadPassport(values) {
  alert("values be .." + values);
  const photoStore = usePhotoStore();
  const { photo } = values;
  console.log("values are ..", values);
  return photoStore.uploadPhoto(photo).catch((error) => console.log(error));
}
</script>
<template>
  <Form
    class="my-10 space-y-6"
    autocomplete="off"
    method="post"
    accept-charset="utf-8"
    @submit="uploadPassport"
    enctype="multipart/form-data"
  >
    <div
      class="flex flex-row items-center rounded-2xl bg-white dark:bg-slate-900/70"
    >
      <div class="flex items-center justify-center mx-auto">
        <label for="photo" class="relative cursor-pointer">
          <div class="w-32 h-32 flex items-center justify-center">
            <img
              v-if="imageUrl"
              :src="imageUrl"
              alt="Uploaded Image"
              class="w-full h-full rounded-full object-cover"
            />
            <div
              v-else
              class="w-full h-full flex items-center justify-center bg-gray-200 text-gray-500 rounded-full"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                class="h-12 w-12"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <!-- ... SVG path for default icon -->
              </svg>
            </div>
          </div>
          <Field
            type="file"
            id="photo"
            name="photo"
            class="hidden"
            accept="image/*"
            @change="handleFileUpload"
          />
        </label>
      </div>
    </div>

    <div class="max-auto">
      <button
        @click="uploadPassport"
        class="flex items-center justify-center px-4 py-2 border border-gray-300 rounded bg-gray-100 hover:bg-gray-200 cursor-pointer"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          class="w-6 h-6 mr-2"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M12 4v7m0 0v3m0-3h3m-3 0H9m9 0a5 5 0 0 0-5-5 5 5 0 0 0-5 5h2a3 3 0 0 1 3 3 3 3 0 0 1-3 3 3 3 0 0 1-3-3H4a2 2 0 0 1 2-2h3a2 2 0 0 1 2 2h2a2 2 0 0 0 2-2 2 2 0 0 0-2-2H7"
          />
        </svg>
        Upload
      </button>
    </div>
  </Form>
  
  
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
