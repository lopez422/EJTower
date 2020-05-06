﻿using System.Collections;
using UnityEngine;

public class WizController : MonoBehaviour
{

    private Transform target;

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullet (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    
    [Header("Use Laser ")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;


    [Header("Unity Setup Fields")]

    public Transform partToRotate;
    public float turnSpeed = 10f;
    
    public string enemyTag = "enemy";
    
    public Transform firePoint;

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
            if(useLaser == true)
            {
                if(lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }

            return;
        }

        LockOnTargert();

        if(useLaser)
        {
            Laser();
        }
        else
        {
           if(fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f/ fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }  

    }

    void LockOnTargert()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(-90f, rotation.y, 0f);
    }

    void Laser()
    {
        if(!lineRenderer.enabled)
            lineRenderer.enabled = true;
          
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void Shoot()
    {
        GameObject magicGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        MagicShot magicShot = magicGo.GetComponent<MagicShot>();

        if(magicShot != null)
            magicShot.Seek(target); 
    }

    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
