namespace Nirvana.Toolkit
{
    public interface IEventListener { }

    public interface IEventListener<T> : IEventListener where T : IEvent
    {
        void OnEvent(T e);
    }
}