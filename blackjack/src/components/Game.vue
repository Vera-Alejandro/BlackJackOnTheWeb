<template>
  <div class="bg-black">
    <div class="p-5">
      <div v-if="gameStarted" class="flex flex-col">
        <div class="flex flex-row p-5 justify-between">
          <div class="pr-5">
            <img
              src="https://alejandropersonalstorage.blob.core.windows.net/public-images/BackJack-Title.png"
              alt="logo"
            />
          </div>
          <div class="px-16">
            <h1 class="text-white text-2xl"><u>Dealer</u></h1>
            <h2 class="text-white">Score: {{ dealerScore }}</h2>
          </div>
          <div class="px-16">
            <h1 class="text-white text-2xl"><u> {{ playerName }} </u></h1>
            <h2 class="text-white">Score: {{ playerScore }}</h2>
            <h2 class="text-white">Cash: ${{ playerCash }}</h2>
          </div>
        </div>

        <div class="grid grid-cols-2 gap-4 p-5">
          <div
            v-for="cardImg in dealerCards"
            :key="cardImg.id"
            class="relative h-96 bg-white"
          >
            <img
              class="absolute left-0 top-2"
              :src="cardImg.src"
              alt="card back"
            />
          </div>
          <div class="h-96 bg-white relative">
            <img
              class="absolute left-0 top-8"
              src="https://alejandropersonalstorage.blob.core.windows.net/public-images/Ace-of-Diamonds.png"
              alt="card back"
            />
            <img
              class="absolute left-10 top-8"
              src="https://alejandropersonalstorage.blob.core.windows.net/public-images/Ace-of-Diamonds.png"
              alt="card back"
            />
          </div>
        </div>

        <div class="p-5 grid grid-cols-3">
          <div class="col-span-2 inline-block">
            <h3 class="text-white text-4xl pl-4">Bet</h3>
          </div>
          <div class="">
            <button class="btn">Hit</button>
            <button class="btn">Stay</button>
          </div>
        </div>
        <div class="flex flex-row p-5 justify-between">
          <div v-for="bet in possibleBets" :key="bet.Amount">
            <button class="btn mx-2 px-4">{{ bet.Text }}</button>
          </div>
        </div>
      </div>

      <div v-if="!gameStarted" class="h-96">
        <div class="flex justify-center mt-80">
          <button class="btn" @click="StartGame">Start Game</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import gamePlayDataAccess from "../dataAccess/gamePlayDataAccess";

export default {
  name: "Game",
  data: () => ({
    gameStarted: false,
    gamePlayDAO: new gamePlayDataAccess(),
    playerCash: null,
    dealerScore: null,
    playerScore: null,
    playerName: null,
    possibleBets: [
      { Amount: "All", Text: "Bet All" },
      { Amount: 1, Text: "$1" },
      { Amount: 5, Text: "$5" },
      { Amount: 10, Text: "$10" },
      { Amount: 25, Text: "$25" },
      { Amount: 50, Text: "$50" },
      { Amount: 100, Text: "$100" },
      { Amount: 250, Text: "$250" },
      { Amount: 500, Text: "$500" },
      { Amount: 1000, Text: "$1,000" },
    ],
    dealerCards: [
      {
        id: 1,
        src: "https://alejandropersonalstorage.blob.core.windows.net/public-images/Ace-of-Diamonds.png",
        name: "Ace of Diamonds",
      },
    ],
  }),
  computed: {},
  methods: {
    async StartGame() {
      this.gameStarted = true;
      this.playerCash = await this.gamePlayDAO.getPlayerCash();
      this.dealerScore = await this.gamePlayDAO.getPlayerScore();
      this.playerScore = await this.gamePlayDAO.getDealerScore();
    },
  },
};
</script>

<style>
.btn {
  @apply bg-transparent hover:bg-gray-700 text-gray-300 font-semibold hover:text-white py-2 px-7 border border-gray-500 hover:border-transparent rounded mx-4;
}
</style>