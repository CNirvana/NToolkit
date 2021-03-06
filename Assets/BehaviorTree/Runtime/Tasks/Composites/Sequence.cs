namespace Nirvana.BT
{
    public class Sequence : Composite
    {
        public override TaskStatus Tick(float deltaTime)
        {
            var childStatus = this.children[this.ActiveChild].Tick(deltaTime);
            switch (childStatus)
            {
                case TaskStatus.Success:
                    {
                        this.ActiveChild++;
                        if(this.ActiveChild >= this.ChildCount)
                        {
                            this.ActiveChild = 0;
                            return TaskStatus.Success;
                        }
                        else
                        {
                            return TaskStatus.Running;
                        }
                    }
                case TaskStatus.Running:
                    {
                        return TaskStatus.Running;
                    }
                case TaskStatus.Failure:
                    {
                        this.ActiveChild = 0;
                        return TaskStatus.Failure;
                    }
                default:
                    return TaskStatus.Success;
            }
        }
    }
}