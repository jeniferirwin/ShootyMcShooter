using UnityEngine;
using Shooty.Core;

namespace Shooty.UI
{
    public class WeaponChoiceInput : MonoBehaviour
    {
        public void SetWeaponType(string type)
        {
            PersistentData.WeaponType playerWeapon = PersistentData.WeaponType.Pistol;
            if (type == "Rifle") playerWeapon = PersistentData.WeaponType.Rifle; 
                
            PersistentData.SetChosenWeaponType(playerWeapon);
        }
    }
}
