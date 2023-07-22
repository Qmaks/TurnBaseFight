using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Views
{
    public class HeroUI : MonoBehaviour
    {
        public event Action OnAttackButton;

        public BuffsUI buffsUI;
        
        [SerializeField] private Button attackButton;
        [SerializeField] private BarView healthBar;
        [SerializeField] private BarView armorBar;
        [SerializeField] private BarView vampireBar;
        
        private void Awake()
        {
            attackButton.onClick.AddListener(OnAttackButtonClick);
        }

        private void OnAttackButtonClick()
        {
            OnAttackButton?.Invoke();
        }

        public void SetHealth(string text, float progress)
        {
            healthBar.SetText(text);
            healthBar.SetProgress(progress);
        }

        public void SetArmor(string text, float progress)
        {
            armorBar.SetText(text);
            armorBar.SetProgress(progress);
        }
        
        public void SetVampire(string text, float progress)
        {
            vampireBar.SetText(text);
            vampireBar.SetProgress(progress);
        }

        public void Activate()
        {
            attackButton.interactable = true;
            buffsUI.addBuffButton.interactable = true;
        }

        public void Deactivate()
        {
            attackButton.interactable = false;
            buffsUI.addBuffButton.interactable = false;
        }
    }
}