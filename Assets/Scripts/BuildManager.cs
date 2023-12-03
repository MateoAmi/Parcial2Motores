using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake()
    {
        instance = this;
    }
    public GameObject standarTurretPrefab;
    public GameObject missileTurretPrefab;
   private TurretBlueprint turretToBuild;
   public bool CanBuild{get{return turretToBuild != null;}}
    public bool HasMoney{get{return PlayerStats.Money>= turretToBuild.cost;}}
   public void BuildTurretOn(node Node)
   {
     if(PlayerStats.Money < turretToBuild.cost)
     {
        Debug.Log("No te da la plata");
        return;
     }

     PlayerStats.Money -= turretToBuild.cost;
     Debug.Log("te queda " + PlayerStats.Money + " pesos");
     GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, Node.GetBuildPosition(), Quaternion.identity);
        Node.currentTurret = turret;
   }
  
   public void SelectTurretToBuild(TurretBlueprint turret)
   {
    turretToBuild = turret;
   }
}
