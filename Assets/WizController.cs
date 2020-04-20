using System.Collections;
using UnityEngine;

public class WizController : MonoBehaviour
{

	private Transform target;
	public float range = 15f;

	public string enemyTag = "enemy";

	public Transform partToRotate;

	public float turnSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
    	GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

    	float shortestDistance = Mathf.Infinity;
    	GameObject nearestEnemy = null;

    	foreach(GameObject enemy in enemies)
    	{
    		float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
    		if(distanceToEnemy < shortestDistance)
    		{
    			shortestDistance = distanceToEnemy;
    			nearestEnemy = enemy;
    		}
    	}

    	if(nearestEnemy != null && shortestDistance <= range)
    	{
    		target = nearestEnemy.transform;
    	}
    	else 
    	{
    		target = null;
    	}
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
        	return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(-90f, rotation.y, 0f);
        
    }

    void onDrawGizmosSelected()
    {
    	Gizmos.color = Color.blue;
    	Gizmos.DrawWireSphere(transform.position, range);
    }
}
