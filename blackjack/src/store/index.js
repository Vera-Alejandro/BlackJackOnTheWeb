import { createStore } from "vuex";

export default createStore({
    state: {
        playerCash: 69,  
    },
    mutations: {
        updatePlayerCash(state, playerCash) {
            state.playerCash = playerCash;
        }
    },
    actions: {
        updatePlayerCash({ commit }, playerCash) {
            commit('updatePlayerCash', playerCash);
        }
    }
});
