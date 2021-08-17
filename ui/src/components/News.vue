<template>
  <b-card class="mb-1 mt-1 p-3" raised no-body>
    <b-card-title v-text="title"></b-card-title>
    <b-card-text v-html="msg"></b-card-text>
  </b-card>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class News extends Vue {
  constructor(options: any) {
    super(options);
  }
  @Prop({ default: '' }) public title!: string;
  @Prop({ default: '' }) public msg!: string;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
