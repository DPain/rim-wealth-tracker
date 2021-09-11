<template>
  <div id="container">
    <h2 class="p-2">Leaderboard</h2>
    <div v-for="(el, i) in ranks" :key="i">
      <b-card class="mb-1 mt-1 p-3" raised no-body>
        <b-card-title v-text="i + 1" />
        <b-card-sub-title v-text="el.name" />
        <b-card-text class="mt-4">Wealth: {{ el.wealth }}</b-card-text>
        <b-card-text>Days: {{ el.days }}</b-card-text>
      </b-card>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Config from '@/config/config';
import Rank from '@/model/Rank';

@Component
export default class Leaderboard extends Vue {
  private ranks: Rank[] = [];

  created() {
    this.loadLeaderboard();
  }

  loadLeaderboard(): void {
    let wealth_url: string = Config.wealth_url;
    fetch(wealth_url)
      .then((response) => {
        // Status code: 204 means no data in DB.
        if (response.status === 200) {
          return response.json() as Promise<Rank[]>;
        } else {
          return [];
        }
      })
      .then((data: Rank[]) => {
        this.ranks = data;
      })
      .catch((err) => console.error(err));
  }
}
</script>

<style scoped lang="scss">
@import '@/style/variables.scss';

/* responsive, form small screens */
@include media-breakpoint-down(sm) {
  #container {
    margin-left: auto;
    margin-right: auto;
    width: 90%;
  }
}

@include media-breakpoint-between(sm, md) {
  #container {
    margin-left: auto;
    margin-right: auto;
    width: 80%;
  }
}

@include media-breakpoint-between(md, lg) {
  #container {
    margin-left: auto;
    margin-right: auto;
    width: 75%;
  }
}

@include media-breakpoint-between(lg, xl) {
  #container {
    margin-left: auto;
    margin-right: auto;
    width: 60%;
  }
}

@include media-breakpoint-up(xl) {
  #container {
    margin-left: auto;
    margin-right: auto;
    width: 50%;
  }
}

#container {
  text-align: center;
}
</style>
