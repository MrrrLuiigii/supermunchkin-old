namespace Models
{
    public class Monster
    {
        public int Level { get; set; }
        public int Modifier { get; set; }

        public Monster()
        {
            Level = 0;
            Modifier = 0;
        }
    }
}
