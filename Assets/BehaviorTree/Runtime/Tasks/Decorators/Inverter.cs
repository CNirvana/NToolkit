namespace Nirvana.BT
{
    public class Inverter : Decorator
    {
        public override TaskStatus Tick(float deltaTime)
        {
            var childStatus = this.child.Tick(deltaTime);
            switch (childStatus)
            {
                case TaskStatus.Running:
                    return TaskStatus.Running;
                case TaskStatus.Success:
                    return TaskStatus.Failure;
                case TaskStatus.Failure:
                    return TaskStatus.Success;
            }

            return TaskStatus.Success;
        }
    }
}