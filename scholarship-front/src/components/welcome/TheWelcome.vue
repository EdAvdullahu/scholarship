<template>
 <div class="welcome">
  <div class="title">Welcome to SPMS</div>
  <div class="split"></div>
  <div class="other">
   <pre>SPMS is not simply a </pre>
   <pre>new way of applying for </pre>
   <pre>scholarships but represents a new </pre>
   <pre>approach to expanding the opportunities </pre>
   <pre>that students get. Applying, evaluating and </pre>
   <pre>communicating with a fast and easy way like </pre>
   <pre>experience like never before.</pre>
  </div>
 </div>
</template>
<script>
export default {};
</script>
<style scoped>
.welcome {
 display: flex;
 width: 100%;
 height: auto;
 margin: 0;
 padding: 0;
 flex-direction: row;
 justify-content: space-around;
 background-color: transparent;
 height: 80vh;
 overflow: hidden;
 position: relative;
}
.title {
 display: flex;
 background-color: var(--mainColor1);
 font-size: 3.9rem;
 clip-path: polygon(0 0, 100% 0%, 59% 100%, 0% 100%);
 height: 60vh;
 width: 40vw;
 color: var(--mainColor8);
 padding: 20px;
 text-transform: uppercase;
 align-items: center;
 position: absolute;
 left: 0;
 margin: 40px;
 margin-left: 0;
}
.split {
 display: flex;
 height: 80vh;
 width: 28vw;
 background-color: var(--mainColor1);
 clip-path: polygon(93% 0, 94% 0, 15% 100%, 14% 100%);
 position: absolute;
 margin-right: 200px;
}
.other {
 display: flex;
 background-color: transparent;
 font-size: 2vw;
 clip-path: polygon(100% 0, 38% 0, 0 100%, 100% 100%);
 height: 60vh;
 width: 55vw;
 color: var(--mainColor1);
 padding: 20px;
 position: absolute;
 right: 0;
 margin: 40px;
 margin-right: 0;
 flex-direction: column;
 justify-content: flex-end;
}
.other > pre {
 margin: 0;
 padding: 0;
 text-align: right;
 padding-right: 20px;
}
</style>
