using System;
using UnityEngine;
using XNode;

namespace Nirvana.BT
{
    [Serializable]
    public class TaskConnection
    {
        [SerializeField]
        private Task _host;
        [SerializeField]
        private Task _connected;

        public Task Host { get { return _host; } }
        public Task Connected { get { return _connected; } }

        public TaskConnection(Node node, Node connected)
        {
            _host = node as Task;
            _connected = connected as Task;
        }
    }
}