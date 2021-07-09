import axios from "axios";

const api = axios.create({
    baseUR: "http://localhost:3000/api/",
});

class apiWrapper {
    static async getPlayerCashCall(playerId) {
        return playerId === null ? { data: 69 } : await api.get(`/player/cash/${playerId}`);
    }
}

export default apiWrapper;