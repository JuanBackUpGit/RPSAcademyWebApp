namespace RPSAcademyWeb.Models
{
    public class Game
    {
        public Game()
        {
            
        }

        public string UsersName { get; set; }

        public string OppName { get; set; }

        public string OppImage { get; set; }

        public string OppDescription { get; set; }

        public string OppStats { get; set; }

        public List<int> OppDifficulty { get; set; }

    }
}
