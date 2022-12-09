using System;

namespace ET.Common
{
    [Serializable]
    public abstract class Node
    {
        public int Id { get; private set; }

        public Node(int Id) 
        {
            this.Id = Id;
        }
        
    }
}