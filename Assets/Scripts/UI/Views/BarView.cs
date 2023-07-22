using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class BarView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Slider slider;

        public void SetText(string value)
        {
            this.text.text = value;
        }

        public void SetProgress(float value)
        {
            slider.value = value;
        }
    }
}
