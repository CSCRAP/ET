using System;
using System.Collections.Generic;
using ET.Codes.Model.Module.BehaviorTree;
using ET.Common;

namespace ET
{
    public class Blackboard : IDisposable
    {

        public Blackboard(Entity entity, BTEventType eventType, ETCancellationToken ct)
        {
            this.Entity = entity;
            this.EventType = eventType;
            this.Ct = ct;
        }

        public Entity Entity { get; private set; }

        public BTEventType EventType { get; private set; }

        public ETCancellationToken Ct { get; private set; }
        
        

        private Dictionary<string, object> Outputs = new Dictionary<string, object>();

        public void Add<T>(string key, T value)
        {
            if (!typeof (T).IsValueType)
            {
                this.Outputs.Add(key, (object)value);
                
                return;
            }

            
            Value<T> obj = ValueObjectPool.Instance.Fetch<T>();
            
            obj.t = value;
           
            Outputs.Add(key, obj);
        }

        public T Get<T>(string key) 
        {
           
            if ( !Outputs.TryGetValue(key, out var obj))
            {
                throw new Exception($"Blackboard.Outputs don't have k : {key}:" );
                
            }

            if (!typeof(T).IsValueType)
            {
                return (T)obj;

            }
            
            Value<T> value  = obj as Value<T>;
                
            return value.t;

        }

        public void Dispose()
        {
            foreach (object obj in this.Outputs.Values)
            {
               
                if (obj.GetType().IsGenericType)
                {
                    
                    ValueObjectPool.Instance.Recycle(obj);
                }

            }
            
            this.Outputs.Clear();
            
        }
    }
}