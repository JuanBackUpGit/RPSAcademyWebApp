using RPSAcademyWeb.Models;

namespace RPSAcademyWeb
{
    public interface IGameRepository
    {
        public Game SetName(string name, Game game);
    }
}
