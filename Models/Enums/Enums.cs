namespace Models.Enums
{
    public enum GameStatus
    {
        Setup = 1,
        Playing = 2,
        Finished = 3
    }

    public enum MunchkinGender
    {
        Male = 1,
        Female = 2
    }

    public enum AdjustStats
    {
        Up = 1,
        Down = 2
    }

    public enum ExecuteQueryStatus
    {
        Error,
        OK
    }

    public enum BattleStatus
    {
        Won,
        Lost,
        Ongoing
    }
}
