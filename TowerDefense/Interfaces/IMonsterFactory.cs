namespace TowerDefense.Interfaces
{
    public interface IMonsterFactory
    {
        IMonster CreateMonster(MonsterType type);
    }
}
