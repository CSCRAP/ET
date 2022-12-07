namespace ET.Common
{
    public abstract class Node
    {
        private readonly long Id;

        public Node() 
        {
        }
        
        public Node(long Id) 
        {
            this.Id = Id;
        }
        
    }
}