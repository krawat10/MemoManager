<template>
    <div class="card-group mb-3">
        <Memo 
            v-for="memo in memos" 
            :key="memo.id" 
            :content="memo"
            class="card"/>
    </div>
</template>

<script>
import Memo from './Memo';


export default {
    computed: {
        memos(){
            return this.$store.getters.getMemos;
        }
    },
    components: {
        Memo
    }
}
</script>
