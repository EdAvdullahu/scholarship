<template>
<div class="header">
  <div class="header-routes">
    <ul class="header-routes-item">
      <li class="link">
        <router-link class="link-item" to="/home">Home</router-link>
      </li>
      <li class="link">
        <router-link class="link-item" to="">Other pages</router-link>
      </li>
      <li class="link">
        <router-link class="link-item" to="">Other pages</router-link>
      </li>
      <li class="link">
        <router-link class="link-item" to="">Other pages</router-link>
      </li>
      <li class="link">
        <router-link class="link-item" to="">Other pages</router-link>
      </li>
    </ul>
  </div>
  <div class="header-profile">
    profile
  </div>
</div>
</template>

<script>
export default {
  name: "TheNavigation"
}
</script>

<style scoped>
@import '@/assets/Variables.css';
.header{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  margin: 0;
  width: 100%;
  height: 70px;
  background-color: var(--mainColor2);
  position: fixed;
  top: 0;
}
.header-routes{
  display: flex;
  flex-direction: row;
}
.header-routes-item{
  display: flex;
  flex-direction: row;
  list-style: none;
  gap: 20px;
}
.link{
  padding: 5px;
  transition: all ease-in-out 300ms;
}
.link:hover{
  padding: 5px 10px;
}
.link-item{
  text-decoration: none;
  color: var(--mainColor1);
  font-size: 1.3rem;
}
/*.router-link-active{*/
/*  color: red;*/
/*}*/
</style>