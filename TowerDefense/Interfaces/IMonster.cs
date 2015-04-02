namespace TowerDefense.Interfaces
{
    public interface IMonster : IGameObject, IMovable, ITarget
    {
        int Health
        {
            get;
        }

        int GoldValue
        {
            get;
        }

        int ScoreValue
        {
            get;
        }

        bool ReachedEnd
        {
            get;
        }
    }
}
