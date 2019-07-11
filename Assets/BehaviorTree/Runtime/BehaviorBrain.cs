using UnityEngine;

namespace Nirvana.BT
{
    public class BehaviorBrain : MonoBehaviour
    {
        public BehaviorGraph graph;

        private EntryTask _entryTask;

        private void Awake()
        {
            if(this.graph == null)
            {
                this.enabled = false;
                return;
            }

            _entryTask = this.graph.GetEntryTask();
            if(_entryTask == null)
            {
                this.enabled = false;
                return;
            }

            this.graph.Initialize();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _entryTask.Tick(deltaTime);
        }
    }
}