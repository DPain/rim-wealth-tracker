<template>
  <div id="home">
    <b-jumbotron class="banner" header-level="4">
      <template #header>Rimworld Tracker</template>

      <template #lead>
        Top 100 user submitted highest wealths in Rimworld.
      </template>

      <hr class="my-4" />

      <p>Powered by Node.js, Firebase, Vue.js, and a C# Rimworld Mod.</p>

      <b-button
        variant="primary-dark"
        href="https://github.com/DPain/rim-wealth-tracker"
        target="_blank"
      >
        Github
      </b-button>
    </b-jumbotron>
    <div id="news-section">
      <h2 class="p-2">News</h2>
      <News
        v-for="(el, i) in news"
        :key="i"
        :title="el.title"
        :msg="el.msg"
        class="mb-3"
      />
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
  private news: News[] = [];

  created() {
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

.banner {
  background-color: get_overlay('primary', '4dp') !important;
}

#news-section {
  text-align: center;
}
</style>
