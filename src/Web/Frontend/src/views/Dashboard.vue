<script setup>
import { storeToRefs } from 'pinia';

import { useAuthStore, useUsersStore } from '@/stores';

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
                                    <div
                                            class="inline-flex items-center rounded-full border border-blue-500 bg-blue-500 py-1 px-3 text-xs capitalize leading-none text-white">

                                    <span class="mr-1 inline-flex h-4 w-4 items-center justify-center">
                                        <svg viewBox="0 0 24 24" width="14" height="14" class="inline-block">
                                        <path fill="currentColor"
                                              d="M11,15H13V17H11V15M11,7H13V13H11V7M12,2C6.47,2 2,6.5 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12A10,10 0 0,0 12,2M12,20A8,8 0 0,1 4,12A8,8 0 0,1 12,4A8,8 0 0,1 20,12A8,8 0 0,1 12,20Z">
                                        </path>
                                        </svg>
                                    </span>
                                        <span>notice</span>
                                    </div>
                                </div>
                            </div>
                            <div class="text-sm">
                               resit issues
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-span-12 sm:col-span-6 xl:col-span-3">
                    <div class="flex flex-col rounded-2xl bg-white">
                        <div class="flex-1 p-6">
                            <div class="mb-3 flex items-center justify-between">
                                <div class="flex items-center justify-center">
                                    <div
                                            class="inline-flex items-center rounded-full border border-blue-500 bg-blue-500 py-1 px-3 text-xs capitalize leading-none text-white">
                                    <span class="mr-1 inline-flex h-4 w-4 items-center justify-center">
                                        <svg viewBox="0 0 24 24" width="14" height="14" class="inline-block">
                                        <path fill="currentColor"
                                              d="M11,15H13V17H11V15M11,7H13V13H11V7M12,2C6.47,2 2,6.5 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12A10,10 0 0,0 12,2M12,20A8,8 0 0,1 4,12A8,8 0 0,1 12,4A8,8 0 0,1 20,12A8,8 0 0,1 12,20Z">
                                        </path>
                                        </svg>
                                    </span>
                                        <span>notice</span>
                                    </div>
                                </div>
                            </div>

                            <div class="text-sm">
                                ssss
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-span-12 sm:col-span-6 xl:col-span-3">
                    <div class="flex flex-col rounded-2xl bg-white">
                        <div class="flex-1 p-6">
                            <div class="mb-3 flex items-center justify-between">
                                <div class="flex items-center justify-center">
                                    <div
                                            class="inline-flex items-center rounded-full border border-red-500 bg-red-500 py-1 px-3 text-xs capitalize leading-none text-white"
                                    >
                <span
                        class="mr-1 inline-flex h-4 w-4 items-center justify-center"
                ><svg
                        viewBox="0 0 24 24"
                        width="14"
                        height="14"
                        class="inline-block"
                >
                    <path
                            fill="currentColor"
                            d="M7.41,8.58L12,13.17L16.59,8.58L18,10L12,16L6,10L7.41,8.58Z"
                    ></path></svg></span
                ><span>Academics%</span>
                                    </div>
                                </div>
                            </div>
                            <div class="flex items-center justify-between">
                                <div class="flex items-center justify-center">
                                    <div>
                                        <h3 class="text-sm leading-tight text-gray-500">
                                            Calender
                                        </h3>
                                        <h1 class="text-1xl font-semibold leading-tight">
                                            {{$year ?? ''}} - Sem {{$sem ?? ''}}
                                        </h1>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <!---->
                    </div>
                </div>
                <div class="col-span-12 sm:col-span-6 xl:col-span-3">
                    <div class="flex flex-col rounded-2xl bg-white">
                        <div class="flex-1 p-6">
                            <div class="mb-3 flex items-center justify-between">
                                <div class="flex items-center justify-center">
                                    <div
                                            class="inline-flex items-center rounded-full border border-yellow-500 bg-yellow-500 py-1 px-3 text-xs capitalize leading-none text-white">
                                    <span class="mr-1 inline-flex h-4 w-4 items-center justify-center">
                                        <svg viewBox="0 0 24 24" width="14" height="14" class="inline-block">
                                        <path fill="currentColor"
                                              d="M11,15H13V17H11V15M11,7H13V13H11V7M12,2C6.47,2 2,6.5 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12A10,10 0 0,0 12,2M12,20A8,8 0 0,1 4,12A8,8 0 0,1 12,4A8,8 0 0,1 20,12A8,8 0 0,1 12,20Z">
                                        </path>
                                        </svg>
                                    </span>
                                        <span>Performance</span>
                                    </div>
                                </div>
                            </div>
                            <div class="flex items-center justify-between">
                                <div class="flex items-center justify-center">
                                    <div>
                                        <h3
                                                class="text-sm leading-tight text-gray-500"
                                        >
                                            Class
                                        </h3>
                                        <h1 class="text-1xl font-semibold leading-tight">
                                            <div>

                                                {{$class ?? ''}}
                                            </div>
                                        </h1>
                                    </div>
                                    &nbsp; &nbsp; &nbsp;
                                    <div>
                                        <h3
                                                class="text-sm leading-tight text-gray-500"
                                        >
                                            CGPA
                                        </h3>
                                        <h1 class="text-1xl font-semibold leading-tight">
                                            <div>

                                                {{$newCgpa ?? ''}}
                                            </div>
                                        </h1>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- start new card -->
            <div class="mb-6 grid grid-cols-1 gap-6 xl:grid-cols-2">
                <div class="rounded-2xl relative !bg-white pb-5" style="background: white; padding-bottom: 120px;">
                    <div class="p-3 rounded-t-2xl !h-36" style="">
                        <div class="flex justify-between items-center">
                            <span class="rounded-lg p-2 text-sm capitalize leading-none text-blue bg-white">
                                {{$currentStatus ?? ''}}
                            </span>
                            @if($register1 === 'REGISTERED')
                            <div
                                    class="inline-flex items-center rounded-full border border-blue-500 bg-blue-500 py-1 px-4 text-sm leading-none text-white">
                                          <span class="mr-2 inline-flex h-4 w-4 items-center justify-center">
                                              <svg viewBox="0 0 24 24" width="16" height="16" class="inline-block">
                                              <path fill="currentColor"
                                                    d="M23,12L20.56,9.22L20.9,5.54L17.29,4.72L15.4,1.54L12,3L8.6,1.54L6.71,4.72L3.1,5.53L3.44,9.21L1,12L3.44,14.78L3.1,18.47L6.71,19.29L8.6,22.47L12,21L15.4,22.46L17.29,19.28L20.9,18.46L20.56,14.78L23,12M10,17L6,13L7.41,11.59L10,14.17L16.59,7.58L18,9L10,17Z">
                                              </path>
                                              </svg>
                                          </span>
                                <span>{{$register1}}</span>
                            </div>
                            @else
                            <a href="/biodataUpdate"
                               class="border-2 rounded-lg border-white p-2 text-sm capitalize leading-none text-white">
                                Edit Profile
                            </a>
                            @endif
                        </div>
                        <div class="absolute">
                            <div class="flex items-end gap-2 relative" style="top: 42px">
                                <img alt=""
                                     class="shadow-lg h-20 w-20 rounded-full ring-white"
                                     src='<?php echo url("https://photos.ttuportal.com/public/albums/thumbnails/$studentDetail->STNO.jpg")?>'
                                 />
                                <div class="">
                                    biodata
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="flex flex-col gap-2">
                    @if($currentStatus=="In school")
                    <a href="{{route('teaching-time-table')}}">
                        <div class="mb-6 p-6 flex flex-col rounded-2xl bg-white transition-shadow duration-500 last:mb-0 hover:shadow-lg">
                            <h4 class="text-ellipsis text-sm">Click to see Upcoming Lectures</h4>
                        </div>
                    </a>
                    @endif

                    @if($register1 === 'REGISTERED')
                    <a href="{{route('download-registration-slip')}}" target="_blank">
                        <div class="mb-6 p-6 flex flex-col rounded-2xl bg-white transition-shadow duration-500 last:mb-0 hover:shadow-lg">
                            <h4 class="text-ellipsis text-sm">Download Registration Slip</h4>
                        </div>
                    </a>
                    @endif
                </div>
            </div>

        </section>
    </div>


</template>
