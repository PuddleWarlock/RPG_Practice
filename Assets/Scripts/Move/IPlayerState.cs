namespace Move
{
    public interface IPlayerState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}