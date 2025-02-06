using Codebase.Infrastructure.StateMachine;

namespace Codebase.Infrastructure
{
    public class RestartApplicationService : IRestartApplicationService
    {
        private readonly IApplicationStateMachine _appStateMachine;

        public RestartApplicationService(
            IApplicationStateMachine appStateMachine)
        {
            _appStateMachine = appStateMachine;
        }

        public void Restart()
        {
            _appStateMachine.Enter<RestartApplicationState>();
        }
    }
}