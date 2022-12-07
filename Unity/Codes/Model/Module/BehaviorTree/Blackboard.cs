using System.Collections.Generic;
using ET.Common;

namespace ET
{
    public class Blackboard : IDestroy
    {

        public Blackboard(Entity entity, BTEventType eventType, ETCancellationToken ct)
        {

        }

        public Entity Entity { get; init; }

        public BTEventType EventType { get; init; }

        public ETCancellationToken Ct { get; init; }

        private Dictionary<string, Object> Outputs = new Dictionary<string, Object>();

        public void add<T>(string key, T value)
        {
               
        }

        public T get<T>(string key)
        {
            return this.Outputs[key] as  T ;
        }

    }
}