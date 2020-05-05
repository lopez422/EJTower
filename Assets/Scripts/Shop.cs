
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint cannon;
    public TurretBlueprint cannonWithBase;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

    public void SelectStandardTurret()
    {
    	Debug.Log("Standard Turret Selected");
    	buildManager.SelectTurretToBuild(cannon);
    }

    public void SelectUpgradeTurret()
    {
    	Debug.Log("Another Turret Selected");
    	buildManager.SelectTurretToBuild(cannonWithBase);
    }
}
