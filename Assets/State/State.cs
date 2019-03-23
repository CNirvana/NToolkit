namespace Nirvana.Toolkit
{
    public abstract class State<T>
    {
        public StateMachine<T> StateMachine { get; private set; }
        public T Context { get; private set; }
        public float ElapsedTimeInState { get { return this.StateMachine.ElapsedTimeInState; } }

        internal void Setup(StateMachine<T> stateMachine, T context)
        {
            this.StateMachine = stateMachine;
            this.Context = context;
            this.OnInitialize();
        }

        public virtual void OnInitialize() { }
        public virtual void OnEnter() { }
        public virtual void OnExcute(float deltaTime) { }
        public virtual void OnExit() { }
    }
}