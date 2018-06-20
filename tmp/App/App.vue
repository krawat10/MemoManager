<template>
    <div id="home">
        <app-header></app-header>  
        <router-view></router-view>
    </div>
</template>

<script>
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import Header from './components/Header';

export default {
    components: {
        appHeader: Header,
    },
 }
</script>

<style lang="scss">
</style>