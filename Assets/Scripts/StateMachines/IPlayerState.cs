namespace StateMachines
{
    public interface IPlayerState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}