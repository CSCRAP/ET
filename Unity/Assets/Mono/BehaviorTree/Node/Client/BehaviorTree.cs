using ET.Common;
using UnityEngine;

namespace ET.Client
{
    public class BehaviorTree : ScriptableObject
    {
        public long Id;
        
        public long NodeNum;

        public long MaxFloor;

        
        [SerializeReference]
        public Node Head;

        
        public BehaviorTree()
        {
            this.Head = new RootNode(1);
            this.NodeNum = 1;
        }

    }
}