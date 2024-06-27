using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfUpgrades : MonoBehaviour
{
    [SerializeField] GameObject attackUpgrades;
    [SerializeField] GameObject defendUpgrades;
    [SerializeField] GameObject economyUpgrades;

    public void openAttackUpgrades()
    {
        attackUpgrades.SetActive(true); 
        defendUpgrades.SetActive(false);
        economyUpgrades.SetActive(false);
    }
    public void openDefendUpgrades()
    {
        attackUpgrades.SetActive(false);
        defendUpgrades.SetActive(true);
        economyUpgrades.SetActive(false);
    }
    public void openEconomyUpgrades()
    {
        attackUpgrades.SetActive(false);
        defendUpgrades.SetActive(false);
        economyUpgrades.SetActive(true);
    }
}