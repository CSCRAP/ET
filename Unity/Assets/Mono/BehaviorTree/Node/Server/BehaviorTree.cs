using ET.Common;

namespace ET.Server
{
    public class BehaviorTree
    {


        public long id;
        
        
        public RootNode Head;

        public BehaviorTree()
        {
            this.Head = new RootNode(1);
           
        }
        

    }
}