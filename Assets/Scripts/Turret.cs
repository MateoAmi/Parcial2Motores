using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
 public Transform target;

 [Header("Stats")]
  public float fireRate = 3f;
  public float fireCountdown = 0f;
  public float range = 15f;
 
  [Header("Setup")]
  public string enemytag ="Enemy";
  public Transform turret;
  public float turnSpeed = 7f;
  public GameObject bulletPrefab;
  public Transform firePoint;
  public AudioSource soundControl;
  public AudioClip shootSound;
 
   
    void Start ()
    {
        //para llamar a la funcion solo 2 veces por segundo para no sobrecargar la pc
        InvokeRepeating("UpdateTarget",0f, 0.25f);
    }

    void UpdateTarget ()
    {
         //para que targetee al mas cercano
         GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
      
         float shortestDistance = Mathf.Infinity;
       
         GameObject nearestEnemy  = null;
       
         foreach (GameObject enemy in enemies)
            {
          
                float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
           
             if (distanceToEnemy < shortestDistance)
                {
                 shortestDistance = distanceToEnemy;
                  nearestEnemy = enemy;
                }
            }
      
         if(nearestEnemy != null && shortestDistance<=range)
            {
                target = nearestEnemy.transform;
           
             }
             else
            {
            target= null;
            }
    }
    void Update()
    {
        if(target == null)
        {  
            return;
        }
        //mirar al objetivo
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(turret.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        turret.rotation= Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0 )
        {
            Shoot();
           
            fireCountdown = 1f/fireRate;
       
        }
        
        fireCountdown -= Time.deltaTime;

    }

    void Shoot ()
    {
        Debug.Log("bang");
        soundControl.PlayOneShot(shootSound);
      GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      bullet Bullet =bulletGO.GetComponent<bullet>();
      if (Bullet != null)
      Bullet.Chase(target);

    }

    void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, range);  
    }
}
