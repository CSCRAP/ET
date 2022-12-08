using System;
using System.Collections.Generic;
using ET.Codes.Model.Module.BehaviorTree;

namespace ET
{
    public class ValueObjectPool : IDisposable
    {
        private readonly Dictionary<Type, Queue<object>> pool = new Dictionary<Type, Queue<object>>();

        public static ValueObjectPool Instance = new ValueObjectPool();
       
        private ValueObjectPool()
        {
        }

        public Value<T> Fetch<T>()
        {
            Queue<object> queue = null;
            if (!pool.TryGetValue(typeof(T), out queue))
            {
                return new Value<T>();
            }

            if (queue.Count == 0)
            {
                return new Value<T>();
            }
            
            return queue.Dequeue() as Value<T>;
        }
        
        public void Recycle<T>(Value<T> obj)
        {
            Type type = typeof (T);
            Queue<object> queue = null;
            if (!pool.TryGetValue(type, out queue))
            {
                queue = new Queue<object>();
                pool.Add(type, queue);
            }
            queue.Enqueue(obj);
        }
        
        public void Dispose()
        {
            this.pool.Clear();
        }
    }
}