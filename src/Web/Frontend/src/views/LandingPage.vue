<template>
  <nav class="bg-blue-500 p-4">
    <div class="container mx-auto">
      <div class="flex justify-between items-center">
        <a href="#" class="text-white text-xl font-bold"
          >TTU Admission Portal</a
        >
        <ul class="flex space-x-4">
          <li><a href="#" class="text-white hover:text-gray-300">Home</a></li>
          <li>
            <a href="#" class="text-white hover:text-gray-300">Programs</a>
          </li>
          <li>
            <a href="Login" class="text-white hover:text-gray-300">Apply Now</a>
          </li>
          <li>
            <a href="#" class="text-white hover:text-gray-300">Contact</a>
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <!-- Hero Section -->
  <section class="bg-blue-900 text-white py-16">
    <div class="container mx-auto text-center">
      <h1 class="text-4xl font-extrabold mb-6">Welcome to Our University</h1>
      <p class="text-lg mb-8">
        Apply now to start your academic journey with us.
      </p>
      <a
        href="#"
        class="bg-yellow-500 hover:bg-yellow-400 text-blue-900 font-semibold py-2 px-6 rounded-full transition duration-300 ease-in-out transform hover:scale-105"
        >Apply Now</a
      >
    </div>
  </section>

  <!-- Programs Section -->
  <section class="bg-white py-16">
    <div class="container mx-auto">
      <h2 class="text-2xl font-semibold mb-8 text-center">
        Explore Our Programs
      </h2>
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        <!-- Program 1 -->
        <div class="bg-blue-100 p-6 rounded-lg">
          <h3 class="text-xl font-semibold mb-4">Computer Science</h3>
          <p class="text-gray-600">
            Explore the world of computer science with our comprehensive
            program.
          </p>
        </div>
        <!-- Program 2 -->
        <div class="bg-blue-100 p-6 rounded-lg">
          <h3 class="text-xl font-semibold mb-4">Engineering</h3>
          <p class="text-gray-600">
            Get hands-on experience in various engineering disciplines.
          </p>
        </div>
        <!-- Program 3 -->
        <div class="bg-blue-100 p-6 rounded-lg">
          <h3 class="text-xl font-semibold mb-4">Business Administration</h3>
          <p class="text-gray-600">
            Prepare for a successful career in the business world with our
            program.
          </p>
        </div>
      </div>
    </div>
  </section>

  <!-- Contact Section -->
  <section class="bg-blue-900 text-white py-16">
    <div class="container mx-auto text-center">
      <h2 class="text-2xl font-semibold mb-6">Contact Us</h2>
      <p class="text-lg mb-8">
        Have questions or need assistance? Contact our admissions team.
      </p>
      <a
        href="#"
        class="bg-yellow-500 hover:bg-yellow-400 text-blue-900 font-semibold py-2 px-6 rounded-full transition duration-300 ease-in-out transform hover:scale-105"
        >Contact Admissions</a
      >
    </div>
  </section>

  <!-- Footer Section -->
  <footer class="bg-gray-800 text-white py-8">
    <div class="container mx-auto text-center">
      <p>&copy; 2023 University Portal. All rights reserved.</p>
    </div>
  </footer>
</template>
