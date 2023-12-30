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
  <div>
    <section class="xl:mx-auto mb-5">
      <div class="mb-6 grid grid-cols-12 gap-6">
        <div class="col-span-12 sm:col-span-6 xl:col-span-3">
          <div class="flex flex-col rounded-2xl bg-white">
            <div class="flex-1 p-6">
              <div class="mb-3 flex items-center justify-between">
                <div class="flex items-center justify-center">
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
                    <path
                      d="M4 19.5l5-2.5 5 2.5 5-2.5V5.5a2 2 0 0 0-2-2H6a2 2 0 0 0-2 2v14z"
                    />
                    <line x1="12" y1="11" x2="12" y2="17" />
                    <line x1="12" y1="9" x2="12" y2="9.01" />
                  </svg>
                </div>
              </div>
              <div class="text-sm">
                No.{{ users.formNo }} -
                {{ users.category }}
              </div>
            </div>
          </div>
        </div>
        <div class="col-span-12 sm:col-span-6 xl:col-span-3">
          <div class="flex flex-col rounded-2xl bg-white">
            <div class="flex-1 p-6">
              <div class="mb-3 flex items-center justify-between">
                <div class="flex items-center justify-center">
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
                    <circle cx="12" cy="10" r="3" />
                    <path
                      d="M19 10c0-5-4-9-9-9s-9 4-9 9c0 3.86 3 8 9 13 6-5 9-9.14 9-13z"
                    />
                  </svg>
                </div>
              </div>

              <div class="text-sm">
                {{ users.soldBy }} - {{ users.branch }} | &nbsp; Category:
                <span v-if="users.type == 1"> HND </span>
                <span v-if="users.type == 2"> BTECH </span>
                <span v-if="users.type == 3"> DIPLOMA </span>
                <span v-if="users.type == 4"> ACCELERATED </span>
                <span v-if="users.type == 5"> MTECH </span>
              </div>
            </div>
          </div>
        </div>

        <div class="col-span-12 sm:col-span-6 xl:col-span-3">
          <div class="flex flex-col rounded-2xl bg-white">
            <div class="flex-1 p-6">
              <div class="mb-3 flex items-center justify-between">
                <div class="flex items-center justify-center">
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
                    <rect x="3" y="4" width="18" height="18" rx="2" ry="2" />
                    <line x1="16" y1="2" x2="16" y2="6" />
                    <line x1="8" y1="2" x2="8" y2="6" />
                    <line x1="3" y1="10" x2="21" y2="10" />
                  </svg>
                </div>
              </div>

              <div class="text-sm">
                Admission Year: &nbsp;{{ users.year }}
                <!-- - Status:
                <span v-if="users.formCompleted && !users.Finalized">
                  <a
                    href="#"
                    id="ama"
                    class="final md-btn md-btn-danger uk-margin-small-top"
                    >Finalized Forms</a
                  >
                </span> -->
                <span v-if="users.Finalized && users.Admitted == false">
                  Form Locked - Finalized
                </span>
                <span v-if="users.Admitted">
                  Admitted.
                  <a
                    target="_blank"
                    href="https://ttuportal.com/arms/@form.GetApplicantIdFromFormNo(user.FormNo)/letter/print"
                    >Click to print letter</a
                  >
                </span>
                <span
                  v-if="
                    !users.Admitted && !users.Finalized && !users.formCompleted
                  "
                >
                  Application Started
                </span>
              </div>
            </div>
          </div>
        </div>

        <div class="col-span-12 sm:col-span-6 xl:col-span-3">
          <div class="flex flex-col rounded-2xl bg-white">
            <div class="flex-1 p-6">
              <div class="mb-3 flex items-center justify-between">
                <div class="flex items-center justify-center">
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
                    <circle cx="12" cy="12" r="10" />
                    <line x1="12" y1="8" x2="12" y2="12" />
                    <line x1="12" y1="16" x2="12" y2="16" />
                  </svg>
                </div>
              </div>

              <div class="text-sm">
                <span v-if="users.PictureUploaded && !users.admitted">
                  <h4 class="text-sm text-green-600">
                  NB: Admission Pending.  Passport Photo uploaded.
                  </h4>
                </span>
                <span v-if="!users.PictureUploaded && !users.admitted">
                  <h4 class="text-sm text-red-600">

                      Status:  Applicant

                  </h4>
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- start new card -->
      <div class="mb-6 grid grid-cols-1 gap-6 xl:grid-cols-2">
        <div
          class="flex flex-row items-center rounded-2xl bg-white dark:bg-slate-900/70"
        >
          <div class="flex-1 p-6">
            <div
              class="block items-center justify-around md:flex lg:justify-center"
            >
              <div class="mb-6 flex items-center justify-center md:mb-0">
                <div class="lg:mx-12">
                  <span>
                    <img
                      class="w-full h-full rounded-full"
                      src="https://photos.ttuportal.com/public/albums/thumbnails/2022103563.jpg"
                      onerror="this.onerror=function my(){return this.src='https://srms.ttuportal.com/public/albums/students/USER.JPG';};this.src='https://photos.ttuportal.com/public/albums/thumbnails/0720000342.JPG';"
                      alt="https://srms.ttuportal.com/public/albums/students/USER.JPG"
                    />
                  </span>
                  <p>&nbsp;</p>

<!--                  <span v-if="!users?.pictureUploaded">
                    <router-link


                      to="/modal"
                    >
                      <button
                        class="rounded bg-blue-500 py-2 px-4 font-bold text-white hover:bg-blue-700"
                      >
                        Start application
                      </button>
                    </router-link>
                  </span>-->
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
                        v-if="users?.admitted"
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
                      <span>Admitted!</span>


                    </div>
                    <div
                        v-if="!users?.admitted"
                        class="inline-flex items-center rounded-full border border-red-500 bg-red-500 py-1.5 px-4 text-sm capitalize leading-none text-white"
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
                      <span> Pending!</span>


                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <!---->
        </div>
        <div class="flex flex-col gap-2">


          <router-link to="/photo/upload" v-if="!users?.admitted">
            <div
              class="mb-6 p-6 flex flex-col rounded-2xl bg-white transition-shadow duration-500 last:mb-0 hover:shadow-lg"
            >
              <button
                class="bg-blue-500 hover:bg-blue-500 text-white font-bold py-2 px-4 rounded-full text-sm"
              >
                Click to start application
              </button>
            </div>
          </router-link>
          <a v-if="!users?.pictureUploaded" >
            <div
                class="mb-6 p-6 flex flex-col rounded-2xl bg-white transition-shadow duration-500 last:mb-0 hover:shadow-lg"
            >
              <h4 class="text-sm text-red-600">

              1.  Passport Photo not uploaded.
                <a href=""

                   class="final md-btn md-btn-danger uk-margin-small-top"
                > click to upload.</a
                >
              </h4>
            </div>
          </a>
        </div>
      </div>
    </section>
  </div>
</template>
