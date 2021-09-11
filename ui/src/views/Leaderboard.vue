<template>
  <div id="leaderboard">
    <h2 class="p-2 mb-1">Leaderboard</h2>
    <div v-for="(el, i) in ranks" :key="i">
      <b-card class="mb-3 p-3" raised no-body>
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

#leaderboard {
  text-align: center;
}
</style>
