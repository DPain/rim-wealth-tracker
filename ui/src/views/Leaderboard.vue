<template>
  <div class="home">
    <div id="container">
      <h2 class="p-2">Leaderboard</h2>
      <div v-for="(el, i) in leaderboard" :key="i">
        <b-card class="mb-1 mt-1 p-3" raised no-body>
          <b-card-title v-text="i + 1" />
          <b-card-sub-title v-text="el.name" />
          <b-card-text class="mt-4">Wealth: {{ el.wealth }}</b-card-text>
          <b-card-text>Days: {{ el.days }}</b-card-text>
        </b-card>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Leaderboard extends Vue {
  private _leaderboard!: any[];

  get leaderboard() {
    // Sort from highest
    return this._leaderboard.sort((e1, e2) => e1.wealth - e2.wealth);
  }

  created() {
    this._leaderboard = [];
    this.loadLeaderboard();
  }

  loadLeaderboard(): void {
    for (let i = 0; i < 4; i++) {
      const entry = {
        name: `Player: ${i}`,
        wealth: 4 - i,
        days: 123,
      };
      this.leaderboard.push(entry);
    }
  }

  genLeaderboardString(wealth: number, days: number): string {
    const result = `Wealth: ${wealth}\nDays: ${days}`;
    console.log(result);
    return result;
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
</style>
