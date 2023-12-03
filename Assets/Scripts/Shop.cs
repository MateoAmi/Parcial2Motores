using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
   public TurretBlueprint standarTurret;
   public TurretBlueprint missileTurret;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandarTurret()
    {
        Debug.Log("Cannon Selected");
        buildManager.SelectTurretToBuild(standarTurret);
    }
    public void SelectMissileTurret()
    {
        Debug.Log("Missile Selected");
        buildManager.SelectTurretToBuild(missileTurret);
    }
    
}
