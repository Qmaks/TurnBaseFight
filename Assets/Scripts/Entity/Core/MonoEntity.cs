using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Entity.Core
{
    public class MonoEntity : MonoBehaviour, IEntity
    {
        [ShowInInspector]
        private readonly List<object> elements;

        public MonoEntity()
        {
            elements = new List<object>();
        }

        public MonoEntity(IEnumerable<object> elements)
        {
            this.elements = new List<object>(elements);
        }

        public MonoEntity(params object[] elements)
        {
            this.elements = new List<object>(elements);
        }

        public T Get<T>()
        {
            for (int i = 0, count = this.elements.Count; i < count; i++)
            {
                if (this.elements[i] is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Element of type {typeof(T).Name} is not found!");
        }

        public object[] GetAll()
        {
            return this.elements.ToArray();
        }

        public void Add(object element)
        {
            this.elements.Add(element);
        }

        public void AddRange(IEnumerable<object> elements)
        {
            this.elements.AddRange(elements);
        }

        public void AddRange(params object[] elements)
        {
            this.elements.AddRange(elements);
        }

        public void Remove(object element)
        {
            this.elements.Remove(element);
        }

        public bool TryGet<T>(out T element)
        {
            for (int i = 0, count = this.elements.Count; i < count; i++)
            {
                if (this.elements[i] is T result)
                {
                    element = result;
                    return true;
                }
            }

            element = default;
            return false;
        }
    }
}