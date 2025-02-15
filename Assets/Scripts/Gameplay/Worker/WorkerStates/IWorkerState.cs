namespace Gameplay.Worker.WorkerStates
{
    public interface IWorkerState
    {
        void Enter();
        void Exit();
        void Update();
    }
}