<template>
    <div id="home">
        <app-header></app-header>  
        <br>
        <b-container>
          <router-view></router-view>
        </b-container>
    </div>
</template>

<script>
import Header from './components/Header';

export default {
    components: {
        appHeader: Header,
    },
 }
</script>

<style lang="scss">
</style>