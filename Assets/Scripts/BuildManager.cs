
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

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
    	return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
    	turretToBuild = turret;
    }
}
