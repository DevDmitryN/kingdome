using System.Collections.Generic;
using System.Linq;

namespace Gameplay.Core.StateMachine
{
    public class BaseStateSwitcher : IStateSwitcher
    {
        private readonly List<IState> _states;
        private IState _currentState;

        public BaseStateSwitcher(List<IState> states)
        {
            _states = states;
        }


        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(_ => _ is T);
            
            _currentState?.Exit();
            _currentState = state;
            _currentState?.Enter();
        }

        public void Replace<T>(IState state) where T : IState
        {
            IState curState = _states.FirstOrDefault(_ => _ is T);
            if (curState == default)
            {
                _states.Add(state);
            }
            else
            {
                _states.Remove(curState);
                _states.Add(state);
            }
        }
    }
}