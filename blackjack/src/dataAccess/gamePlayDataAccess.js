import apiWWrapper from "../apiWrapper";
import store from "../store";

class gamePlayDataAccess {
    async getPlayerCash() {
        debugger;
        const response = await apiWWrapper.getPlayerCashCall(null);
        store.commit("updatePlayerCash", response.data);

        return store.getters.playerCash;
    }
}

export default gamePlayDataAccess;