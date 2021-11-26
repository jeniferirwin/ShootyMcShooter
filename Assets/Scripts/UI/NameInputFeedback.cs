using UnityEngine;
using Shooty.Core;
using UnityEngine.UI;

namespace Shooty.UI
{
    public class NameInputFeedback : MonoBehaviour
    {
        [SerializeField] private GameObject instructions;
        [SerializeField] private GameObject clickNotification;
        [SerializeField] private GameObject buttons;
        [SerializeField] private Color successColor;
        [SerializeField] private Color failColor;
        [SerializeField] private Image panel;

        public void ChangeColor()
        {
            // TODO: rewrite
        }
    }
}
