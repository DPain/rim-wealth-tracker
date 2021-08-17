<template>
  <div class="home">
    <div class="banner">Leaderboard</div>
    <div id="news">
      <h2>News</h2>
      <News v-for="(el, i) in data" :key="i" :title="el.title" :msg="el.msg" />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import News from '@/components/News.vue';

@Component({
  components: {
    News,
  },
})
export default class Leaderboard extends Vue {
  constructor() {
    super();
    this.data = [];
  }

  mounted() {
    this.loadNews();
  }

  @Prop() private data: News[];

  loadNews(): void {
    for (let i = 0; i < 4; i++) {
      const news: News = new News({
        propsData: {
          title: 'title wow',
          msg: 'msg',
        },
      });
      this.data.push(news);
    }
  }
}
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
