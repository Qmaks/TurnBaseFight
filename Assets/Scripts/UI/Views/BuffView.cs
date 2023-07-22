using BuffSystem.NewBuffSystem;
using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class BuffView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI name;

        public void Bind(BaseBuff buff)
        {
            name.text = buff.VisualName;
        }
    }
}