using System;
using System.Collections.Generic;

namespace Nirvana.Toolkit
{
    public sealed class StateMachine<T>
    {
        public event Action OnStateChanged;

        public T Context { get; private set; }
        public State<T> currentState { get; private set; }
        public State<T> previousState { get; private set; }
        public float ElapsedTimeInState { get; private set; }

        private Dictionary<Type, State<T>> _states;

        public StateMachine(T context, State<T> initialState)
        {
            _states = new Dictionary<Type, State<T>>();

            this.Context = context;
            this.ElapsedTimeInState = 0f;

            this.previousState = null;
            this.AddState(initialState);
            this.currentState = initialState;
            this.currentState.OnEnter();
        }

        public bool AddState(State<T> state)
        {
            if (_states.ContainsKey(state.GetType()))
            {
                return false;
            }

            state.Setup(this, this.Context);
            _states.Add(state.GetType(), state);
            return true;
        }

        public void Update(float deltaTime)
        {
            this.ElapsedTimeInState += deltaTime;
            this.currentState.OnExcute(deltaTime);
        }

        public S ChangeState<S>() where S : State<T>
        {
            var type = typeof(S);
            if (this.currentState.GetType() == type)
            {
                return this.currentState as S;
            }

            this.previousState = this.currentState;
            this.currentState.OnExit();
            this.currentState = _states[type];
            this.ElapsedTimeInState = 0;
            this.currentState.OnEnter();

            if (this.OnStateChanged != null)
            {
                this.OnStateChanged();
            }

            return this.currentState as S;
        }
    }
}