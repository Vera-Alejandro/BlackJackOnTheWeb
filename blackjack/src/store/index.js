import { createStore } from "vuex";

export default createStore({
    state: {
        playerCash: null,
        playerScore: null,  
        dealerScore: null,
    },
    mutations: {
        updatePlayerCash(state, playerCash) {
            state.playerCash = playerCash;
        },
        updatePlayerScore(state, playerCash) {
            state.playerCash = playerCash;
        },
        updateDealerScore(state, playerCash) {
            state.playerCash = playerCash;
        },
    },
    getters: {
        playerCash: state => state.playerCash,
        playerScore: state => state.playerCash,
        dealerScore: state => state.playerCash,
    }
});
