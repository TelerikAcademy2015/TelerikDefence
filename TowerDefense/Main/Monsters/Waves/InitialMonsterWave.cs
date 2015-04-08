namespace TowerDefense.Main.Monsters.Waves
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TowerDefense.Interfaces;

    public class InitialMonsterWave : MonsterWave
    {
        public InitialMonsterWave(TimeSpan spawnTime, IMonsterFactory factory)
            : base(spawnTime, factory)
        {
        }

        protected override IEnumerable<IMonsterGroup> CreateGroups()
        {
            return Enum.GetValues(typeof(MonsterType)).Cast<MonsterType>().Select(type => new MonsterGroup(new TimeSpan(0, 0, 0, 1), type, 10 + 2 * this.Level, this.factory));
        }
    }
}
