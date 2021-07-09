import { createStore } from "vuex";

export default createStore({
    state: {
        playerCash: 420,  
    },
    mutations: {
        updatePlayerCash(state, playerCash) {
            state.playerCash = playerCash;
        }
    },
});
