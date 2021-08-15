<template>
  <div class="home">
    <div class="banner">
      <img alt="Vue logo" src="../assets/logo.png" />
      <HelloWorld msg="Welcome to Your Vue.js + TypeScript App" />
    </div>
    <div id="news">
      <h2>News</h2>
      <b-card class="mb-1 mt-1 p-3" raised no-body>
        <b-card-title v-text="'hi'"></b-card-title>
        <b-card-text v-html="'item.body'"></b-card-text>
      </b-card>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src

@Component({
  components: {
    HelloWorld,
  },
})
export default class Home extends Vue {}
</script>

<style scoped lang="scss">
@import '@/style/variables.scss';

#news {
  margin-left: auto;
  margin-right: auto;
  width: 50%;
}

#subreaddit-box {
  background-color: $dark;
  border-radius: 0.25rem;
  border-color: $gray-500;
}

#prepend,
#prepend:disabled {
  opacity: 1;
  border-color: $gray-500;
  margin-right: 0.5rem;
}

#enter {
  border-color: $gray-500;
  margin-left: 0.5rem;
}

a {
  color: #42b983;
}
</style>
