
using UnityEngine;

[System.Serializable]
public class TurretBlueprint 
{
   public GameObject prefab;
   public int cost;
   public Vector3 offset;

   public GameObject Upgradedprefab;
   public int upgradeCost;

   public int GetSellAmount()
   {
   		return cost / 4;
   }
}
