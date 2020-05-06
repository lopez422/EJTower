
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint cannon;
    public TurretBlueprint cannonWithBase;
    public TurretBlueprint wiz;

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

    public void SelectWizTurret()
    {
        Debug.Log("A Wiz Turret Selected");
        buildManager.SelectTurretToBuild(wiz);
    }
}
