using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	public Color notEnoughMoneyColor;
	//public Vector3 positionOffset;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;


	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;

	}

	public Vector3 GetBuildPosition()
	{
		return transform.position;
	}

	void OnMouseDown()
	{
		if(EventSystem.current.IsPointerOverGameObject())
    		return;
    		

		if(turret != null)
		{
			buildManager.SelectedNode(this);
			return;
		}

		if(!buildManager.CanBuild)
		{
			return;
		}

		BuildTurret(buildManager.GetTurretToBuild());
		//buildManager.BuildTurretOn(this);
	}

	void BuildTurret(TurretBlueprint blueprint)
	{
		if(PlayerStats.Money < blueprint.cost)
    	{
    		Debug.Log("Not Enough GUAP to build that");
    		return;
    	}

    	PlayerStats.Money -= blueprint.cost;

    	GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition() + blueprint.offset, Quaternion.identity);
    	turret = _turret;

    	turretBlueprint = blueprint;

    	GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
    	Destroy(effect, 5f);

    	Debug.Log("Turret built! Money left: " + PlayerStats.Money);
	}

	public void UpgradeTurret()
	{
		if(PlayerStats.Money < turretBlueprint.upgradeCost)
    	{
    		Debug.Log("Not Enough GUAP to Upgrade that");
    		return;
    	}

    	PlayerStats.Money -= turretBlueprint.upgradeCost;

		

    	//getting rid of old turret
    	Destroy(turret);

		//Building upgraded turret
    	GameObject _turret = Instantiate(turretBlueprint.Upgradedprefab, GetBuildPosition() + turretBlueprint.offset, Quaternion.identity);
    	turret = _turret;
    	
    	GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
    	Destroy(effect, 5f);

    	isUpgraded = true;

    	Debug.Log("Turret Upgraded " + PlayerStats.Money);
	}

	public void SellTurret()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount();

		//Spawn Cool effect
		GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
    	Destroy(effect, 5f);

		Destroy(turret);
		turretBlueprint = null;

	}

    void OnMouseEnter()
    {
    	if(EventSystem.current.IsPointerOverGameObject())
    		return;

    	if(!buildManager.CanBuild)
		{
			return;
		}

		if(buildManager.HasMoney)
		{
    		rend.material.color = hoverColor;
		}
		else
		{
			rend.material.color = notEnoughMoneyColor;
		}

    }

    void OnMouseExit()
    {
    	rend.material.color = startColor;
    }
}
