<template>
 <div class="the-uni">
  <div class="uni-name">
   {{ name }}
  </div>
  <div class="uni-description">
   {{ description }}
   <router-link :to="{ name: 'faculties', params: { uniIndex: id } }">
    more
   </router-link>
  </div>
  <div class="uni-communicate">
   <button>Send email</button>
   <button>Send Message</button>
  </div>
 </div>
</template>

<script>
export default {
 props: ["name", "id", "description"],
};
</script>

<style scoped>
@import "@/assets/Variables.css";
.uni-name {
 font-size: 2rem;
 color: var(--mainColor1);
}
.uni-description {
 font-size: 1.2rem;
 color: var(--mainColor1);
}
</style>
