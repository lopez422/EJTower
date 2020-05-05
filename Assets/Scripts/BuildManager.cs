
using UnityEngine;

public class BuildManager : MonoBehaviour
{

	public static BuildManager instance;

	void Awake()
	{
		if(instance != null)
		{
			Debug.LogError("More than 1 BuildManager in scene!");
			return;
		}
		instance = this;

	}

	public GameObject cannonPrefab;
	public GameObject cannonWithBasePrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild{get {return turretToBuild != null;} }

    public void BuildTurretOn(Node node)
    {
    	if(PlayerStats.Money < turretToBuild.cost)
    	{
    		Debug.Log("Not Enough GUAP to build that");
    		return;
    	}

    	PlayerStats.Money -= turretToBuild.cost;

    	GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
    	node.turret = turret;

    	Debug.Log("Turret built! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
    	turretToBuild = turret;
    }
}
