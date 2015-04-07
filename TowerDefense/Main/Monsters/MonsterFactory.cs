namespace TowerDefense.Main
{
    using System;
    using TowerDefense.Interfaces;
    using TowerDefense.Main.Monsters;

    public class MonsterFactory : IMonsterFactory
    {
        private IRoute route;

        public MonsterFactory(IRoute route)
        {
            this.route = route;
        }

        public IMonster CreateMonster(MonsterType type)
        {
            switch (type)
            {
                case MonsterType.Deamon:
                    {
                        return new Deamon(this.route);
                    }
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }
    }
}
