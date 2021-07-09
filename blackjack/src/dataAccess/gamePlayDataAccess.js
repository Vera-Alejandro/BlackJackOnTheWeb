import apiWWrapper from "../apiWrapper";
import store from "../store";

class gamePlayDataAccess {
    async getPlayerCash() {
        const response = await apiWWrapper.getPlayerCashCall(null);
        store.commit("updatePlayerCash", response.data);

        return store.getters.playerCash;
    }

    async getPlayerScore() {
        const response = await apiWWrapper.getPlayerScoreCall(null);
        store.commit("updatePlayerCash", response.data);

        return store.getters.playerCash;
    }

    async getDealerScore() {
        const response = await apiWWrapper.getDealerScoreCall();
        store.commit("updatePlayerCash", response.data);

        return store.getters.playerCash;
    }

}

export default gamePlayDataAccess;