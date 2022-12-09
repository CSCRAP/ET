using ET.Common;
using UnityEngine;

namespace ET.Client
{
    public class BehaviorTree : ScriptableObject
    {
        public long Id;

        [SerializeReference]
        public Node Head;

        
        public BehaviorTree()
        {
            this.Head = new RootNode(1);
        }

    }
}