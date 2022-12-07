namespace ET.Common
{
    public interface INodeHandler
    {
       public ETTask Run(Blackboard blackboard, Node node);
    }
}