using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SetParameters
{
    //Values in array are in order of increasing levels
    // {Level1, Level2, Level3, Level4}

    //Common to all 4 attacking ships
    public static int mediumShipMenCount = 4;

    //Archer Values
    public static float archerLineWidth = 0.01f;
    public static float archerArrowVelocity = 2.5f;
    public static float archersleastDistanceForStraightHit = 2f;
    public static float archerAdjustCurveAngle = 0.7f;

    //Total shoot time = archer_WaitBeforeShoot_Aiming + archer_WaitAfterShoot

    //Gunmen Values
    public static float gunmanLineWidth = 0.01f;
    public static float gunmanBulletVelocity = 10f;

    //Cannon Values
    public static float cannonLineWidth = 0.02f;
    public static float cannonBallVelocity = 10f;
    public static float cannonShootAngleRange = 15f;

    //Mortar Values
    public static float mortarLineWidth = 0.07f;
    public static float mortarBombVelocity = 5f;
    public static float mortarAdjustCurveAngle = -0.7f;

    //Common Archer and Mortar Values
    public static int curvePointsTotalCount = 20;//change this value to change the number of points in curve, and control smoothness of curve by increasing the number

    //Ship Attributes on basis of Levels
    public static float[] archerWeaponRange = new float[] { 3f, 5f, 7f, 10f };
    public static float[] cannonWeaponRange = new float[] { 3f, 5f, 7f, 10f };
    public static float[] gunmanWeaponRange = new float[] { 3f, 5f, 7f, 10f };
    public static float[] mortarWeaponRange = new float[] { 3f, 5f, 7f, 10f };

    //Varying Ship Health
    public static int supplyShipHealth = 140;
    public static int[] archerShipHealth = new int[] { 160, 220, 280, 340 };
    public static int[] cannonShipHealth = new int[] { 160, 220, 280, 340 };
    public static int[] gunmanShipHealth = new int[] { 160, 220, 280, 340 };
    public static int[] mortarShipHealth = new int[] { 160, 220, 280, 340 };

    //Varying Ship Men Health
    public static int[] archerShipMenHealth = new int[] { 160, 220, 280, 340 };
    public static int[] cannonShipMenHealth = new int[] { 160, 220, 280, 340 };
    public static int[] gunmanShipMenHealth = new int[] { 160, 220, 280, 340 };
    public static int[] mortarShipMenHealth = new int[] { 160, 220, 280, 340 };

    //Varying Weapon Damage Levels
    public static int[] archerWeaponDamage = new int[] { 7, 12, 15, 20 };
    public static int[] cannonWeaponDamage = new int[] { 7, 12, 15, 20 };
    public static int[] gunmanWeaponDamage = new int[] { 7, 12, 15, 20 };
    public static int[] mortarWeaponDamage = new int[] { 7, 12, 15, 20 };

    //Weapon Reload Speed Initial encounter, same for all levels
    public static float archer_WaitBeforeShoot_FirstEncounter = 2f;
    public static float gunman_WaitBeforeShoot_FirstEncounter = 2f;
    public static float cannon_WaitBeforeShoot_FirstEncounter = 4f;
    public static float mortar_WaitBeforeShoot_FirstEncounter = 4f;

    //Weapon Reload Speed
    public static float[] archer_WaitBeforeShoot_Aiming = new float[] { 4f,3.5f,3f,2.5f };
    public static float[] archer_WaitAfterShoot = new float[] { 4f, 3.5f, 3f, 2.5f };

    public static float[] gunman_WaitBeforeShoot_Aiming = new float[] { 4f, 3.5f, 3f, 2.5f };
    public static float[] gunman_WaitAfterShoot = new float[] { 4f, 3.5f, 3f, 2.5f };

    public static float[] cannon_WaitBeforeShoot_Aiming = new float[] { 4f, 3.5f, 3f, 2.5f };
    public static float[] cannon_WaitAfterShoot = new float[] { 4f, 3.5f, 3f, 2.5f };

    public static float[] mortar_WaitBeforeShoot_Aiming = new float[] { 4f, 3.5f, 3f, 2.5f };
    public static float[] mortar_WaitAfterShoot = new float[] { 4f, 3.5f, 3f, 2.5f };

    //Weapon Ammunition
    //Ammo is total no of players times no of projectiles
    //For now, medium ship men count = 4 so all values are strictly maintained in multiples of 4
    public static int[] archerWeaponMaxAmmo = new int[] { 20, 28, 40, 56 };
    public static int[] gunmanWeaponMaxAmmo = new int[] { 20, 28, 40, 56 };
    public static int[] cannonWeaponMaxAmmo = new int[] { 20, 28, 40, 56 };
    public static int[] mortarWeaponMaxAmmo = new int[] { 20, 28, 40, 56 };

    //Ship Rotation Speed to align to enemy ship
    public static float[] shipRotationSpeed = new float[] { 0.2f, 0.5f, 1f, 2f };

    public static float[] shipSpeed = new float[] { 1.05f, 1.10f, 1.15f, 1.20f };
    public static int[] shipCost = new int[] { 80, 120, 160, 200 };
}
