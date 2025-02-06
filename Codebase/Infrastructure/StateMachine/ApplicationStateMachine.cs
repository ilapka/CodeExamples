using System;
using System.Collections.Generic;

namespace Codebase.Infrastructure.StateMachine
{
    public class ApplicationStateMachine : IApplicationStateMachine
    {
        private readonly Dictionary<Type, ApplicationState> _states;
        private readonly DIFactory _diFactory;
        private IState _activeState;

        public ApplicationStateMachine(DIFactory diFactory)
        {
            _diFactory = diFactory;
            
            _states = new Dictionary<Type, ApplicationState>
            {
                [typeof(BootstrapState)] = _diFactory.Create<BootstrapState>().Setup(this),
                [typeof(LoadMainMenuState)] = _diFactory.Create<LoadMainMenuState>().Setup(this),
                [typeof(MainMenuState)] = _diFactory.Create<MainMenuState>().Setup(this),
                [typeof(RestartApplicationState)] = _diFactory.Create<RestartApplicationState>().Setup(this),
            };
        }

        public void Enter<TState>(IStateArgs args = null) where TState : ApplicationState
        {
            IState state = ChangeState<TState>();
            state.Enter(args);
        }

        private TState ChangeState<TState>() where TState : ApplicationState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : ApplicationState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}