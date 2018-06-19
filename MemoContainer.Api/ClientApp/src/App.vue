<template>
  <div>
    <app-header/>
    <router-view></router-view>
  </div>
</template>

<script>
import Header from './components/Header';

export default {
  components:{
    appHeader: Header
  }
}
</script>