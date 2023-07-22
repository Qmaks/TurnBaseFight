using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class BuffsUI : MonoBehaviour
    {
        public event Action OnAddBuffButtonClick;
        
        public Button addBuffButton;
        public BuffsListView buffsListView;

        private void Awake()
        {
            addBuffButton.onClick.AddListener(AddBuffButtonClick);
        }

        private void AddBuffButtonClick()
        {
            OnAddBuffButtonClick?.Invoke();
        }
    }
}
