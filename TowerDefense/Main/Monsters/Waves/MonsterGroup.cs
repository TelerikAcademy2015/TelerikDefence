namespace TowerDefense.Main.Monsters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using TowerDefense.Interfaces;

    public class MonsterGroup : IMonsterGroup
    {
        public TimeSpan SpawnTime
        {
            get;
            private set;
        }

        public MonsterType MonsterType
        {
            get;
            private set;
        }

        public int Count
        {
            get;
            private set;
        }

        public bool Started
        {
            get;
            private set;
        }

        public bool Finished
        {
            get;
            private set;
        }

        protected IMonsterFactory factory;
        private TimeSpan timeElapsedSinceLastAddedGameObject;
        private IEnumerable<IMonster> monsters;
        private IEnumerator<IMonster> enumerator;

        public MonsterGroup(TimeSpan spawnTime, MonsterType monsterType, int count, IMonsterFactory factory)
        {
            this.SpawnTime = spawnTime;
            this.MonsterType = monsterType;
            this.Count = count;
            this.Finished = false;

            this.factory = factory;
            this.timeElapsedSinceLastAddedGameObject = new TimeSpan();
            this.monsters = this.CreateMonsters(factory);
            this.enumerator = this.monsters.GetEnumerator();
        }

        public IEnumerable<IMonster> GetProducedObjects(TimeSpan elapsedTime)
        {
            this.Started = true;
            TimeSpan totalElapsedTime = this.timeElapsedSinceLastAddedGameObject + elapsedTime;
            if (this.Finished)
            {
                return Enumerable.Empty<IMonster>();
            }

            if (totalElapsedTime < this.SpawnTime)
            {
                this.timeElapsedSinceLastAddedGameObject = totalElapsedTime;
                return Enumerable.Empty<IMonster>();
            }


            ICollection<IMonster> producedObjects = new List<IMonster>();
            while (totalElapsedTime > this.SpawnTime)
            {
                if (this.enumerator.MoveNext())
                {
                    producedObjects.Add(this.enumerator.Current);
                }
                else
                {
                    this.Finished = true;
                }

                totalElapsedTime -= this.SpawnTime;
            }

            this.timeElapsedSinceLastAddedGameObject = totalElapsedTime;
            return producedObjects;
        }

        protected virtual IEnumerable<IMonster> CreateMonsters(IMonsterFactory factory)
        {
            return Enumerable.Repeat<MonsterType>(this.MonsterType, this.Count).Select(type => factory.CreateMonster(type));
        }

        IEnumerable IObjectCreator.GetProducedObjects(TimeSpan elapsedTime)
        {
            return this.GetProducedObjects(elapsedTime);
        }
    }
}
