using System;
using System.Collections.Generic;
using BuffSystem.NewBuffSystem;
using UnityEngine;

namespace UI.Views
{
    public class BuffsListView  : MonoBehaviour
    {
        [SerializeField] private BuffView prefab;

        private List<(BaseBuff,BuffView)> buffs = new();

        private void Awake()
        {
            prefab.gameObject.SetActive(false);
        }

        public void Add(BaseBuff baseBuff)
        {
            var view = Instantiate(prefab,transform);

            view.Bind(baseBuff);
            view.gameObject.SetActive(true);

            buffs.Add((baseBuff,view));
        }

        public void Remove(BaseBuff baseBuff)
        {
            foreach (var tuple in buffs)
            {
                if (tuple.Item1.Equals(baseBuff))
                {
                    Destroy(tuple.Item2.gameObject);
                    buffs.Remove(tuple);
                    return;
                }
            }
        }
    }
}