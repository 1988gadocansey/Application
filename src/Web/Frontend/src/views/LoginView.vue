<script setup>
import { Form, Field } from "vee-validate";
import * as Yup from "yup";
const privateEnvVar = import.meta.env.SERVER_SIDE_ONLY_VAR;
import { useAuthStore } from "@/stores";

const schema = Yup.object().shape({
  email: Yup.string().required("Serial No is required"),
  password: Yup.string().required("Pin Code is required"),
});

function onSubmit(values, { setErrors }) {
  const authStore = useAuthStore();
  const { email, password } = values;

  return authStore
    .login(email, password)
    .catch((error) => setErrors({ apiError: error }));
}
</script>

<template>
  <div class="bg-gray-100 flex items-center justify-center h-screen">
    <!--  <div class="alert alert-info">
            Username: test<br />
            Password: test
        </div>
        <h2>Login</h2>
        <Form @submit="onSubmit" :validation-schema="schema" v-slot="{ errors, isSubmitting }">
            <div class="form-group">
                <label>Username</label>
                <Field name="username" type="text" class="form-control" :class="{ 'is-invalid': errors.username }" />
                <div class="invalid-feedback">{{errors.username}}</div>
            </div>            
            <div class="form-group">
                <label>Password</label>
                <Field name="password" type="password" class="form-control" :class="{ 'is-invalid': errors.password }" />
                <div class="invalid-feedback">{{errors.password}}</div>
            </div>            
            <div class="form-group">
                <button class="btn btn-primary" :disabled="isSubmitting">
                    <span v-show="isSubmitting" class="spinner-border spinner-border-sm mr-1"></span>
                    Login
                </button>
            </div>
            <div v-if="errors.apiError" class="alert alert-danger mt-3 mb-0">{{errors.apiError}}</div>
        </Form> -->

    <Form
      method="post"
      @submit="onSubmit"
      :validation-schema="schema"
      v-slot="{ errors, isSubmitting }"
    >
      <h2 class="text-2xl font-semibold mb-4">APPLICANT LOGIN</h2>

      <div class="mb-4">
        <label
          for="serial-no"
          class="block text-gray-700 text-sm font-bold mb-2"
          >Serial No</label
        >
        <Field
          :class="{ 'is-invalid': errors.email }"
          type="text"
          id="serial-no"
          name="email"
          class="w-full border rounded-lg py-2 px-3 focus:outline-none focus:ring focus:border-blue-500"
        />
        <div class="text-orange-700">{{ errors.email }}</div>
      </div>

      <div class="mb-6">
        <label for="pin" class="block text-gray-700 text-sm font-bold mb-2"
          >Pin Code</label
        >
        <Field
          type="password"
          id="pin"
          name="password"
          class="w-full border rounded-lg py-2 px-3 focus:outline-none focus:ring focus:border-blue-500"
        />
        <div class="text-orange-700">{{ errors.password }}</div>
      </div>

      <div class="flex items-center justify-between">
        <button
          :disabled="isSubmitting"
          @click="login"
          class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full focus:outline-none focus:shadow-outline"
        >
          <span
            v-show="isSubmitting"
            class="spinner-border spinner-border-sm mr-1"
          ></span>
          Login
        </button>
        <a href="#" class="text-blue-500 hover:underline">Forgot PIN?</a>
      </div>
      <div v-if="errors.apiError" class="text-orange-700mt-3 mb-0">
        {{ errors.apiError }}
      </div>
    </Form>
  </div>
</template>
