namespace Nirvana.Toolkit
{
    public class Singleton<T> where T : Singleton<T>, new()
    {
        public static T Instance { get { return Nested.Instance; } }

        protected Singleton() { }

        private class Nested
        {
            static Nested() { }
            internal static readonly T Instance = new T();
        }
    }
}