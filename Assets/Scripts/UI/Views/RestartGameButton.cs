using Events;
using Events.Base;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Utils
{
    public class RestartGameButton : MonoBehaviour
    {
        [Inject] private EventBus eventBus;
        [SerializeField] private Button button;

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
            DontDestroyOnLoad(gameObject);
        }

        private void OnClick()
        {
            eventBus.RaiseEvent(new RestartGameEvent());
        }
    }
}