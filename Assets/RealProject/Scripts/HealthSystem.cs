using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int maxShipHealth;
    private int maxShipMenHealth;

    public int currentShipHealth;
    public int currentShipMenHealth;

    private ShipHealthBar shipHealthBarScript;
    private ShipMenHealthBar shipMenHealthBarScript;

    private ShipCategorizer_Level shipCategorizer_LevelScript;
    private GameObject scaleFactorGameObject;
    private GameObject shooters;

    private bool isNotSupplyShip = false;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == "Canvas")
            {
                GameObject canvasGameObject = transform.GetChild(i).gameObject;

                for (int j = 0; j < canvasGameObject.transform.childCount; j++)
                {
                    GameObject healthbarGameObject = canvasGameObject.transform.GetChild(j).gameObject;

                    if (healthbarGameObject.TryGetComponent<ShipHealthBar>(out _))
                    {
                        shipHealthBarScript = healthbarGameObject.GetComponent<ShipHealthBar>();
                    }
                    else if (healthbarGameObject.TryGetComponent<ShipMenHealthBar>(out _))
                    {
                        shipMenHealthBarScript = healthbarGameObject.GetComponent<ShipMenHealthBar>();
                        isNotSupplyShip = true;
                    }
                }
            }
            else if (transform.GetChild(i).gameObject.name == "ScaleFactorGameObject")
            {
                scaleFactorGameObject = transform.GetChild(i).gameObject;
            }
        }
        if (scaleFactorGameObject != null)
        {
            for (int i = 0; i < scaleFactorGameObject.transform.childCount; i++)
            {
                GameObject gameObject = scaleFactorGameObject.transform.GetChild(i).gameObject;
                if (gameObject.name == "Archers" || gameObject.name == "Gunmen" || gameObject.name == "CannonUnit" || gameObject.name == "MortarUnit")
                {
                    shooters = gameObject;
                }
            }
        }
    }
    private void Start()
    {
        if (!TryGetComponent<ShipCategorizer_Level>(out _))
        {
            maxShipHealth = SetParameters.supplyShipHealth;
            maxShipMenHealth = 0;
        }
        else
        {
            shipCategorizer_LevelScript = GetComponent<ShipCategorizer_Level>();
            maxShipHealth = shipCategorizer_LevelScript.shipHealth;
            maxShipMenHealth = shipCategorizer_LevelScript.shipMenHealth;
        }

        currentShipHealth = maxShipHealth;
        currentShipMenHealth = maxShipMenHealth;
        shipHealthBarScript.SetShipMaxHealth(maxShipHealth);

        if (isNotSupplyShip)
        {
            shipMenHealthBarScript.SetShipMenMaxHealth(maxShipMenHealth);
        }

    }
    public void ShipTakeDamage(int damage)
    {
        currentShipHealth -= damage;
        shipHealthBarScript.SetShipHealth(currentShipHealth);
    }
    public void ShipMenTakeDamage(int damage)
    {
        currentShipMenHealth -= damage;
        shipMenHealthBarScript.SetShipMenHealth(currentShipMenHealth);
    }
    private void Update()
    {
        if (shooters != null)
        {
            DeactivateMen();
        }
    }
    private void DeactivateMen()//Later deactivate only men and not weapons for cannon and mortar ship
    {
        //Later Implement checks only when necessary rathen than including in Update() method to improve performance
        if (currentShipMenHealth <= 0)
        {
            shooters.SetActive(false);
        }
        else
        {
            shooters.SetActive(true);
        }
    }
}
