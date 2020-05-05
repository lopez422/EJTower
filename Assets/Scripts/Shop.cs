
using UnityEngine;

public class Shop : MonoBehaviour
{
	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

    public void PurchaseStandardTurret()
    {
    	Debug.Log("Standard Turret Selected");
    	buildManager.SetTurretToBuild(buildManager.cannonPrefab);
    }

    public void PurchaseUpgradeTurret()
    {
    	Debug.Log("Another Turret Selected");
    	buildManager.SetTurretToBuild(buildManager.cannonWithBasePrefab);
    }
}
