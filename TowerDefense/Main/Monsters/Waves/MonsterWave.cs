using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TowerDefense.Interfaces;

namespace TowerDefense.Main.Monsters
{
    public abstract class MonsterWave : PropertyChangedAwaredObject, IMonsterWave
    {

        public IEnumerable<IMonsterGroup> Groups
        {
            get;
            private set;
        }

        public TimeSpan SpawnTime
        {
            get;
            private set;
        }

        public bool Finished
        {
            get;
            private set;
        }

        private int level;
        public int Level
        {
            get
            {
                return this.level;
            }
            private set
            {
                this.level = value;
                this.OnPropertyChanged("Level");
            }
        }

        protected IMonsterFactory factory;
        private TimeSpan timeElapsedSinceLastGroupFinished;
        private IEnumerator<IMonsterGroup> enumerator;

        public MonsterWave(TimeSpan spawnTime, IMonsterFactory factory)
        {
            this.SpawnTime = spawnTime;
            this.Finished = false;
            this.Level = 1;
            this.Groups = this.CreateGroups();

            this.factory = factory;
            this.timeElapsedSinceLastGroupFinished = new TimeSpan();
            this.enumerator = this.Groups.GetEnumerator();
            this.enumerator.MoveNext();
        }

        public void NextLevel()
        {
            this.timeElapsedSinceLastGroupFinished = new TimeSpan();
            this.Finished = false;
            this.Level++;
            this.Groups = this.CreateGroups();
            this.enumerator = this.Groups.GetEnumerator();
            this.enumerator.MoveNext();
        }

        public IEnumerable<IMonster> GetProducedObjects(TimeSpan elapsedTime)
        {
            TimeSpan totalElapsedTime = this.timeElapsedSinceLastGroupFinished + elapsedTime;
            if (this.Finished)
            {
                return Enumerable.Empty<IMonster>();
            }

            if (!this.enumerator.Current.Started)
            {
                if (totalElapsedTime < this.SpawnTime)
                {
                    this.timeElapsedSinceLastGroupFinished = totalElapsedTime;
                    return Enumerable.Empty<IMonster>();
                }
                else
                {
                    this.timeElapsedSinceLastGroupFinished = totalElapsedTime - this.SpawnTime;
                    return this.enumerator.Current.GetProducedObjects(totalElapsedTime - this.SpawnTime);
                }
            }
            else
            {
                if (this.enumerator.Current.Finished)
                {
                    if (!this.enumerator.MoveNext())
                    {
                        this.Finished = true;
                    }
                    this.timeElapsedSinceLastGroupFinished = elapsedTime;
                    return Enumerable.Empty<IMonster>();
                }
                else
                {
                    this.timeElapsedSinceLastGroupFinished = new TimeSpan();
                    return this.enumerator.Current.GetProducedObjects(elapsedTime);
                }
            }
        }

        protected abstract IEnumerable<IMonsterGroup> CreateGroups();

        IEnumerable IObjectCreator.GetProducedObjects(TimeSpan elapsedTime)
        {
            return this.GetProducedObjects(elapsedTime);
        }
    }
}
