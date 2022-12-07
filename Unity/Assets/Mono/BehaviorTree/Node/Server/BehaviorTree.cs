using ET.Common;

namespace ET.Server
{
    public class BehaviorTree
    {


        public BehaviorTree()
        {
            this.Head = new RootNode(1);
            this.NodeNum = 1;
        }
        
        public long NodeNum;

        public long MaxFloor;
        
        public RootNode Head;

    }
}