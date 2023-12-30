import { defineStore } from "pinia";
import { fetchWrapper, router } from "@/helpers";

const photoUrl = "https://localhost:5001/api/PhotoUpload";

export const usePhotoStore = defineStore({
  id: "photo",
  state: () => ({
    // initialize state from local storage to enable user to stay logged in
    user: JSON.parse(localStorage.getItem("user")),
    returnUrl: null,
  }),
  actions: {
    async uploadPhoto(images) {
      const formData = new FormData();

      for (let i = 0; i < images.length; i++) {
        const file = images[i];
        // Validating file type (JPEG/JPG) and size (not more than 250KB)
        if (
          file.type === "image/jpeg" ||
          file.type === "image/jpg" ||
          file.size / 1024 <= 250
        ) {
          formData.append("images", file);
        } else {
          console.error(`Invalid file: ${file.name}`);
          // Handle invalid file type or size error (display message, skip, etc.)
        }
      }

      try {
        const response = await fetch(photoUrl, {
          method: "POST",
          body: formData,
        });
        console.log("form data " + formData);
        if (response.ok) {
          const responseData = await response.json();
          console.log("Upload successful:", responseData);
          // Handle success - API response
        } else {
          console.error("Upload failed:", response.statusText);
          // Handle failure - HTTP error status
        }
      } catch (error) {
        console.error("Error occurred:", error);
        // Handle any other error during fetch request
      }
    },
  },
});
