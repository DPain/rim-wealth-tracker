<template>
  <div class="home">
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
  .home {
    margin-left: auto;
    margin-right: auto;
    width: 90%;
  }
}

@include media-breakpoint-between(sm, md) {
  .home {
    margin-left: auto;
    margin-right: auto;
    width: 80%;
  }
}

@include media-breakpoint-between(md, lg) {
  .home {
    margin-left: auto;
    margin-right: auto;
    width: 75%;
  }
}

@include media-breakpoint-between(lg, xl) {
  .home {
    margin-left: auto;
    margin-right: auto;
    width: 60%;
  }
}

@include media-breakpoint-up(xl) {
  .home {
    margin-left: auto;
    margin-right: auto;
    width: 50%;
  }
}

.banner {
  background-color: get_overlay('primary', '4dp') !important;
}

#news-section {
  text-align: center;
}

.column {
  margin-bottom: 2vh;
}
</style>
