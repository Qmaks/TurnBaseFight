using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class RoundCounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void Set(string text)
        {
            this.text.text = text;
        }
    }
}
