namespace ET.Common
{
    public abstract class Node
    {
        public  int Id
        {
            get
            {
                return this.Id;
            }
            private set
            {
                this.Id = this.Id;
            }
        }

        public Node() 
        {
        }
        
        public Node(int Id) 
        {
            this.Id = Id;
        }
        
    }
}