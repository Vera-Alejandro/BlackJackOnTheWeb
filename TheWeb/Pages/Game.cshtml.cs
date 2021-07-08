using Blackjack.GamePlay;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheWeb.Pages
{
    public class GameModel : PageModel
    {
        public GameInstance CurrentGame { get; private set; }

        public string Username { get; } = "Guest";
        public int DealerScore { get; } = 0;
        public int PlayerScore { get; } = 0;
        public float PlayerCash { get; } = 0f;
        public bool GameStarted { get; private set; } = false;


        public void OnGet()
        {
        }

        public IActionResult StartGame()
        {
            CurrentGame ??= new GameInstance();

            GameStarted = true;

            return new OkResult();
        }
    }
}
