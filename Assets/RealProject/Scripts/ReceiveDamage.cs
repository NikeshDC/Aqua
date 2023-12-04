using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamage : MonoBehaviour
{
    private HealthAmmoSystem healthSystemScript;
    private ShipCategorizer_Player shipCategorizer_PlayerScript;

    private bool thisShipIsPlayer1;

    private void Awake()
    {
        healthSystemScript = GetComponent<HealthAmmoSystem>();
        shipCategorizer_PlayerScript = GetComponent<ShipCategorizer_Player>();
    }

    private void Start()
    {
        thisShipIsPlayer1 = shipCategorizer_PlayerScript.isP1Ship;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ProjectileController>(out ProjectileController projectileControllerScript))
        {
            bool projectileIsOfPlayer1 = projectileControllerScript.isPlayer1Projectile;
            bool attackerShipIsArcherOrGunmanShip = projectileControllerScript.isArcherOrGunmanProjectile;

            if (thisShipIsPlayer1 != projectileIsOfPlayer1)
            {
                int damage = projectileControllerScript.weaponDamage;

                if (attackerShipIsArcherOrGunmanShip)//Damage only to ship men health
                {
                    healthSystemScript.ShipMenTakeDamage(damage);
                    print(this.name + " took only MAN damage: " + damage + " from archer/gunman ship.");
                }
                else//Damage to both ship as well as ship men
                {
                    healthSystemScript.ShipTakeDamage(damage);
                    healthSystemScript.ShipMenTakeDamage(damage);
                    print(this.name + " took whole damage: " + damage + " from cannon/mortar ship.");
                }
            }          
        }
    }
}
