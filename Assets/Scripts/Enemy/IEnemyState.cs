namespace Isaac.Enemy
{
    public interface IEnemyState
    {
        void EnterState();
        void ExitState();
        void FixedUpdate();
    }
}