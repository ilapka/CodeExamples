namespace Codebase.Infrastructure.StateMachine
{
    public abstract class ApplicationState : IState
    {
        protected IApplicationStateMachine AppStateMachine { get; private set; }

        public ApplicationState Setup(IApplicationStateMachine stateMachine)
        {
            AppStateMachine = stateMachine;
            return this;
        }

        public abstract void Enter(IStateArgs args = null);
        public abstract void Exit();
    }
}