using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCategorizer_Level : MonoBehaviour
{
    public enum ShipLevels
    {
        Level1, Level2, Level3, Level4
    };
    public ShipLevels shipLevel;

    public int shipHealth;
    public int shipMenHealth;
    private float shipSpeed;
    private int shipCost;

    public float weaponRange;
    public int weaponDamage;
    //weapon max ammo and weapon reload speed handled in other scripts

    private TargetingSystem_PhysicsOverlapSphere targetingSystem_PhysicsOverlapSphereScript;

    //Move this code to update or another approach if level of ship upgrades within game
    private void Awake()
    {
        targetingSystem_PhysicsOverlapSphereScript = GetComponent<TargetingSystem_PhysicsOverlapSphere>();

        if (shipLevel == ShipLevels.Level1)
        {
            AssignValue(0);
        }
        else if (shipLevel == ShipLevels.Level2)
        {
            AssignValue(1);
        }
        else if (shipLevel == ShipLevels.Level3)
        {
            AssignValue(2);
        }
        else if (shipLevel == ShipLevels.Level4)
        {
            AssignValue(3);
        }
    }

    private void AssignValue(int index)
    {
        if (targetingSystem_PhysicsOverlapSphereScript.thisShipType == TargetingSystem_PhysicsOverlapSphere.ShipType.ArcherShip)
        {
            weaponRange = SetParameters.ArcherWeaponRange[index];
            shipHealth = SetParameters.ArcherShipHealth[index];
            shipMenHealth = SetParameters.ArcherShipMenHealth[index];
            weaponDamage = SetParameters.ArcherWeaponDamage[index];
        }
        else if (targetingSystem_PhysicsOverlapSphereScript.thisShipType == TargetingSystem_PhysicsOverlapSphere.ShipType.CannonShip)
        {
            weaponRange = SetParameters.CannonWeaponRange[index];
            shipHealth = SetParameters.CannonShipHealth[index];
            shipMenHealth = SetParameters.CannonShipMenHealth[index];
            weaponDamage = SetParameters.CannonWeaponDamage[index];
        }
        else if (targetingSystem_PhysicsOverlapSphereScript.thisShipType == TargetingSystem_PhysicsOverlapSphere.ShipType.GunmanShip)
        {
            weaponRange = SetParameters.GunmanWeaponRange[index];
            shipHealth = SetParameters.GunmanShipHealth[index];
            shipMenHealth = SetParameters.GunmanShipMenHealth[index];
            weaponDamage = SetParameters.GunmanWeaponDamage[index];
        }
        else if (targetingSystem_PhysicsOverlapSphereScript.thisShipType == TargetingSystem_PhysicsOverlapSphere.ShipType.MortarShip)
        {
            weaponRange = SetParameters.MortarWeaponRange[index];
            shipHealth = SetParameters.MortarShipHealth[index];
            shipMenHealth = SetParameters.MortarShipMenHealth[index];
            weaponDamage = SetParameters.MortarWeaponDamage[index];
        }

        shipSpeed = SetParameters.ShipSpeed[index];
        shipCost = SetParameters.ShipCost[index];
    }
}
