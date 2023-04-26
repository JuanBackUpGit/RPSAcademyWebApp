using RPSAcademyWeb.Models;
using System.Data;

namespace RPSAcademyWeb
{
    public class GameRepository : IGameRepository
    {
        public Game CreateGame()
        {
            var game = new Game();
            return game;
        }
        public  Game SetName (string name, Game game)
        { 
            game.UsersName = name;
            return game;
        }

        public string SetOppNoviceNancy(Game game)
        {
           return game.OppName = "Novice Nancy";
        }

    }
}
