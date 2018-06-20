<template>
    <b-card  bg-variant="dark" text-variant="white" :title="content.name">
        <p class="card-text">
            {{ content.description }}
        </p>
        <b-button href="#" variant="primary">Go somewhere</b-button>
    </b-card>
</template>

<script>
    export default {
        props: ['content']
    }
</script>