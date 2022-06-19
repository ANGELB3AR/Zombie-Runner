using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        return slot.ammoAmount;
    }

    public void IncreaseAmmo(AmmoType ammoType, int ammoAmount)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        slot.ammoAmount += ammoAmount;
    }

    public void DecreaseAmmo(AmmoType ammoType)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        slot.ammoAmount--;
    }

    AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
