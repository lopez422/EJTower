
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

	void Start()
	{
		turretToBuild = cannonPrefab;
	}

    private GameObject turretToBuild;



    public GameObject GetTurretToBuild()
    {
    	return turretToBuild;
    }
}
