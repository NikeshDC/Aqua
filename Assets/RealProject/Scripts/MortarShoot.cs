using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShipCategorizer_Level;

public class MortarShoot : MonoBehaviour
{
    public int totalAmmoCount;
    public bool sufficientAmmoPresent;
    
    private ShipCategorizer_Level shipCategorizer_LevelScript;
    public HealthAmmoSystem ammoSystemScript;

    public Transform targetEnemy;

    private void Awake()
    {
        shipCategorizer_LevelScript = GetComponent<ShipCategorizer_Level>();
        ammoSystemScript = GetComponent<HealthAmmoSystem>();
    }
    private void Start()
    {
        sufficientAmmoPresent = true;

        if (shipCategorizer_LevelScript.shipLevel == ShipLevels.Level1)
        {
            AssignValue(0);
        }
        else if (shipCategorizer_LevelScript.shipLevel == ShipLevels.Level2)
        {
            AssignValue(1);
        }
        else if (shipCategorizer_LevelScript.shipLevel == ShipLevels.Level3)
        {
            AssignValue(2);
        }
        else if (shipCategorizer_LevelScript.shipLevel == ShipLevels.Level4)
        {
            AssignValue(3);
        }
        targetEnemy = null;
    }
    private void Update()
    {
        HandleAmmoCount();
    }
    private void HandleAmmoCount()
    {
        if (totalAmmoCount <= 0)
        {
            sufficientAmmoPresent = false;
        }
        else
        {
            sufficientAmmoPresent = true;
        }
    }
    private void AssignValue(int index)
    {
        totalAmmoCount = SetParameters.MortarWeaponMaxAmmo[index];
    }
}
//Other functional portion in respective Mortar Controller script
