using RPSAcademyWeb.Models;

namespace RPSAcademyWeb
{
    public interface IGameRepository
    {
        public Game CreateGame();


        public Game SetName(string name, Game game);



        public string SetOppNoviceNancy(Game game);
        
    }
}
