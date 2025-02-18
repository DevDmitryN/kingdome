namespace Gameplay.Core.StateMachine
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
        void Replace<T>(IState state) where T : IState;
    }
}