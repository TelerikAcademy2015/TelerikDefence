namespace TowerDefense.Interfaces
{
    public interface IValidatable
    {
        string ErrorMessage
        {
            get;
        }
        bool IsValid();
    }
}
