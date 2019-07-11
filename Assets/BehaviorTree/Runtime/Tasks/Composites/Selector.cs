namespace Nirvana.BT
{
    public class Selector : Composite
    {
        public override TaskStatus Tick(float deltaTime)
        {
            var childStatus = this.children[this.ActiveChild].Tick(deltaTime);
            switch (childStatus)
            {
                case TaskStatus.Success:
                    {
                        this.ActiveChild = 0;
                        return TaskStatus.Success;
                    }
                case TaskStatus.Running:
                    {
                        return TaskStatus.Running;
                    }
                case TaskStatus.Failure:
                    {
                        this.ActiveChild++;
                        if(this.ActiveChild >= this.ChildCount)
                        {
                            this.ActiveChild = 0;
                            return TaskStatus.Failure;
                        }
                        else
                        {
                            return TaskStatus.Running;
                        }
                    }
                default:
                    return TaskStatus.Success;
            }
        }
    }
}