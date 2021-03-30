namespace Isaac.Enemy
{
    public interface IEnemyState
    {
        void Initialize();
        void EnterState();
        void ExitState();
        void FixedUpdate();
    }
}