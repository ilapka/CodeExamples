namespace Codebase.Infrastructure.StateMachine
{
    public interface IApplicationStateMachine
    {
        void Enter<TState>(IStateArgs args = null) where TState : ApplicationState;
    }
}