using System.Collections.Generic;
using Isaac.Enemy.State;
using Zenject;

namespace Isaac.Enemy
{
    public class EnemyStateHandler : ITickable, IInitializable
    {
        private List<IEnemyState> _states;

        private IEnemyState _currentStateHandler;
        private EnemyState _currentState;
        
        [Inject]
        public void Construct(
            EnemyAttack attack,
            EnemyIdle idle)
        {
            _states = new List<IEnemyState>
            {
                // WARNING!!! ЗАПИСЫВАЕМ В ТОЙ ЖЕ ПОСЛОЛЕДОВАТЕЛЬНОСТИ КАК В ENUM!!!
                idle, attack
            };
        }
        
        public void Initialize()
        {
            ChangeState(EnemyState.Idle);
        }

        private void ChangeState(EnemyState state)
        {
            _currentStateHandler?.ExitState();

            _currentState = state;
            _currentStateHandler = _states[(int) state];
            
            _currentStateHandler.EnterState();
        }

        public void Tick()
        {
            _currentStateHandler.Update();
        }
    }
}