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
                case MonsterType.Bat:
                    {
                        return new Bat(this.route);
                    }
                case MonsterType.Witch:
                    {
                        return new Witch(this.route);
                    }
                case MonsterType.Bird:
                    {
                        return new Bird(this.route);
                    }
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }
    }
}
