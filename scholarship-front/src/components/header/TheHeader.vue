<template>
 <div class="header">
  <div class="logo">
   <img src="@/assets/Images/logo.jpg" alt="" />
  </div>
  <div class="routes">
   <ul class="routes-list">
    <li class="link">
     <router-link class="link-item" to="home">Home</router-link>
    </li>
    <li>Home</li>
    <li>Home</li>
    <li>Home</li>
    <li>Home</li>
    <li>Home</li>
   </ul>
  </div>
 </div>
</template>

<script>
export default {
 name: "TheHeader",
};
</script>

<style scoped>
@import "@/assets/Variables.css";
.header {
 grid-area: nav;
 display: flex;
 flex-direction: column;
 margin: 0;
 padding: 0;
 width: 120px;
 background-color: var(--mainColor1);
 left: 0;
 height: 100vh;
}
.routes {
 margin-top: 200px;
}
.routes-list {
 list-style: none;
 margin: 0;
 padding: 0;
 margin-left: 10px;
}
.link {
 padding: 5px;
 transition: all ease-in-out 300ms;
}
.link:hover {
 padding: 5px 10px;
}
.link-item {
 text-decoration: none;
 color: var(--mainColor5);
 font-size: 1.3rem;
}
/*.router-link-active{*/
/*  color: red;*/
/*}*/
img {
 clip-path: circle(40%);
 aspect-ratio: 1/1;
 width: 120px;
}
.logo {
 position: absolute;
 width: 170px;
 background-color: var(--mainColor2);
 clip-path: polygon(0 0, 100% 0, 70.5% 99%, 0% 100%);
}
</style>
