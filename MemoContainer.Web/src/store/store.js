import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        isAuthorized: false,
        memos: [{
                id: 'sdasd21312',
                name: 'Memo one',
                description: 'Some description',
                createdAt: '6/20/2018 12:37',
                updatedAt: '6/22/2018 13:37',
                isFinished: false,
            },
            {
                id: 'sdasd2sds12',
                name: 'Memo two',
                description: 'Some more description',
                createdAt: '5/12/2018 2:37',
                updatedAt: '7/22/2018 3:37',
                isFinished: true,
            }
        ]
    },
    getters: {
        getMemos: state => {
            return state.memos;
        }
    },
    mutations: {
        fetchAuthentication(state, credentials){

        }
    },
    actions: {
        logIn({ commit }, credentials){
            
        }
    },
});