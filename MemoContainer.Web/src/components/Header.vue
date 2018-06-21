<template>
    <div>
        <b-navbar toggleable="md" type="dark" variant="info">

        <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>

        <b-navbar-brand href="#">Memo Manager</b-navbar-brand>

        <b-collapse is-nav id="nav_collapse">

            <b-navbar-nav>
            <router-link :to="{ name: 'Memos' }" is="b-nav-item">Memos</router-link>
            <router-link :to="{ name: 'SignIn' }" is="b-nav-item">Sign-In</router-link>
            <router-link  :to="{ name: 'SignUp' }" is="b-nav-item">Sign-Up</router-link>
            </b-navbar-nav>
        </b-collapse>
        </b-navbar>
    </div>
</template>

<script>
export default {
    
}
</script>

