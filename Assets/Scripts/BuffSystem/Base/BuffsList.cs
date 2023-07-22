using System;
using System.Collections.Generic;
using BuffSystem.NewBuffSystem;
using Entity.Core;
using UnityEngine;

namespace BuffSystem.Base
{
    public interface IBuffsList
    {
        public event Action<BaseBuff> OnAddBuff;
        public event Action<BaseBuff> OnRemoveBuff;
        public void Add(BaseBuff buff);
        public void Tick();
        public void ApplyOnAttack(IEntity entity);
        bool Contains(BaseBuff buff);
        bool HasFreeSpace();
    }
    
    [Serializable]
    public class BuffsList : IBuffsList
    {
        public event Action<BaseBuff> OnAddBuff;
        public event Action<BaseBuff> OnRemoveBuff;

        [SerializeField]
        private readonly List<BaseBuff> buffs = new();

        private const int MaxSize = 2;
        
        public void Add(BaseBuff buff)
        {
            if (!HasFreeSpace())
                return;
            
            buffs.Add(buff);
            buff.Activate();
            
            OnAddBuff?.Invoke(buff);
        }

        public void Tick()
        {
            foreach (var buff in buffs)
            {
                buff.Tick();
            }

            RemoveFinishedBuffs();
        }

        private void RemoveFinishedBuffs()
        {
            var finishedBuffs = buffs.FindAll((buff) => buff.isFinished);
            foreach (var buff in finishedBuffs)
            {
                OnRemoveBuff?.Invoke(buff);
            }

            buffs.RemoveAll((buff) => buff.isFinished);
        }

        public void ApplyOnAttack(IEntity entity)
        {
            foreach (var buff in buffs)
            {
                buff.ApplyOnAttack(entity);
            }  
        }

        public bool Contains(BaseBuff buff)
        {
            return buffs.Contains(buff);
        }

        public bool HasFreeSpace()
        {
            return buffs.Count < MaxSize;
        }
    }
}