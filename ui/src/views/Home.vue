<template>
  <div class="home">
    <div class="banner">
      Welcome to Your Vue.js + TypeScript App.
      <br />
      <div class="logo">
        <div class="" />
      </div>
    </div>
    <div id="news">
      <h2 class="p-2">News</h2>
      <News v-for="(el, i) in news" :key="i" :title="el.title" :msg="el.msg" />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import News from '@/components/News.vue';

@Component({
  components: {
    News,
  },
})
export default class Home extends Vue {
  private _news!: News[];

  get news() {
    return this._news;
  }

  created() {
    this._news = [];
    this.loadNews();
  }

  loadNews(): void {
    for (let i = 0; i < 4; i++) {
      const entry: News = new News({
        propsData: {
          title: `title: ${i} wow`,
          msg: 'msg',
        },
      });
      this.news.push(entry);
    }
  }
}
</script>

<style scoped lang="scss">
@import '@/style/variables.scss';

/* responsive, form small screens */
@include media-breakpoint-down(sm) {
  #news {
    margin-left: auto;
    margin-right: auto;
    width: 90%;
  }
}

@include media-breakpoint-between(sm, md) {
  #news {
    margin-left: auto;
    margin-right: auto;
    width: 80%;
  }
}

@include media-breakpoint-between(md, lg) {
  #news {
    margin-left: auto;
    margin-right: auto;
    width: 75%;
  }
}

@include media-breakpoint-between(lg, xl) {
  #news {
    margin-left: auto;
    margin-right: auto;
    width: 60%;
  }
}

@include media-breakpoint-up(xl) {
  #news {
    margin-left: auto;
    margin-right: auto;
    width: 50%;
  }
}

.logo {
  margin: 1vh;
  background: url('../assets/logo.png') no-repeat center center;
  height: 256px;
}

.overlay {
  background: rgb(255, 0, 0);
  opacity: 0.5;
  mix-blend-mode: multiply;
  height: 100%;
  margin-left: auto;
  margin-right: auto;
  width: 256px;
}
</style>
