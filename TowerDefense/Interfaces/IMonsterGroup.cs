namespace TowerDefense.Interfaces
{
    using System;

    public interface IMonsterGroup : IMonsterCreator
    {
        TimeSpan SpawnTime
        {
            get;
        }

        MonsterType MonsterType
        {
            get;
        }

        int Count
        {
            get;
        }

        bool Started
        {
            get;
        }

        bool Finished
        {
            get;
        }
    }
}
