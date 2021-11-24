using UnityEngine;
using Shooty.UI;
using TMPro;

namespace Shooty.Core
{
    public class ApplyWeaponChoice : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void Start()
        {
            if (PersistentData.ChosenWeaponType == PersistentData.WeaponType.Pistol)
            {
                text.text = "Pistol";
            }
            else if (PersistentData.ChosenWeaponType == PersistentData.WeaponType.Rifle)
            {
                text.text = "Rifle";
            }
        }
    }
}
