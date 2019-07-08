using UnityEngine;

namespace Nirvana.BT
{
    public class Log : Action
    {
        public string info;

        public override TaskStatue Tick(float deltaTime)
        {
            Debug.Log(this.info);
            return TaskStatue.Success;
        }
    }
}