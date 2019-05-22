namespace Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Modifier { get; set; }

        public Monster(int id, int level, int modifier)
        {
            Id = id;
            Level = level;
            Modifier = modifier;
        }

        public Monster(string name)
        {
            Name = name;
            Level = 0;
            Modifier = 0;
        }
    }
}
