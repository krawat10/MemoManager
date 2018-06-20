<template>
    <div>
        <b-navbar toggleable="md" type="dark" variant="info">

        <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>

        <b-navbar-brand href="#">Memo Manager</b-navbar-brand>

        <b-collapse is-nav id="nav_collapse">

            <b-navbar-nav>
            <router-link to="/memos" is="b-nav-item">Memos</router-link>
            <b-nav-item href="#" disabled>Account</b-nav-item>
            <b-nav-item href="#" disabled>Sign-In</b-nav-item>
            <b-nav-item href="#" disabled>Sign-Up</b-nav-item>
            </b-navbar-nav>
        </b-collapse>
        </b-navbar>
    </div>
</template>

<script>
export default {
    
}
</script>

