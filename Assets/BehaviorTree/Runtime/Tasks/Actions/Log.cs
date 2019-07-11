using UnityEngine;

namespace Nirvana.BT
{
    public class Log : Action
    {
        public string info;

        public override TaskStatus Tick(float deltaTime)
        {
            Debug.Log(this.info);
            return TaskStatus.Success;
        }
    }
}