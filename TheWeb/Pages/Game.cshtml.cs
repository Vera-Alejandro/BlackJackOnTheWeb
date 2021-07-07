using Blackjack.GamePlay;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheWeb.Pages
{
    public class GameModel : PageModel
    {
        public string Username { get; set; } = "Guest";
        public int DealerScore { get; set; } = 0;
        public int PlayerScore { get; set; } = 0;
        public int PlayerCash { get; set; } = 0;
        public GameInstance CurrentGame { get; set; } = new GameInstance();


        public void OnGet()
        {
        }
    }
}
