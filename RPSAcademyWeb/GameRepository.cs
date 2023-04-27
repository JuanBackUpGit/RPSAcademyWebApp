using RPSAcademyWeb.Models;
using System.Data;

namespace RPSAcademyWeb
{
    public class GameRepository : IGameRepository
    {
        public  Game SetName (string name, Game game)
        { 
            game.UsersName = name;
            return game;
        }

    }
}
