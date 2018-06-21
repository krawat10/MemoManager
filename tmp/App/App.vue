<template>
    <div id="home">
        <app-header></app-header>  
        <router-view></router-view>
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