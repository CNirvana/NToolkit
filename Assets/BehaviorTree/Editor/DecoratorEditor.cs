namespace Nirvana.BT
{
    [CustomNodeEditor(typeof(Decorator))]
    public class DecoratorEditor : TaskEditor
    {
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            var decorator = this.target as Decorator;

            var childPort = this.target.GetOutputPort("child");
            if(childPort.Connection == null)
            {
                decorator.child = null;
            }
            else
            {
                var child = childPort.Connection.node;
                if(decorator.child == null || decorator.child != child)
                {
                    decorator.child = child as Task;
                }
            }
        }
    }
}