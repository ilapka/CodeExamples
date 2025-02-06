namespace Codebase.Infrastructure.StateMachine
{
    public interface IState
    {
        void Enter(IStateArgs args = null);
        void Exit();
    }
}