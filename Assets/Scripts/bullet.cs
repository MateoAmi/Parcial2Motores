using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explotionRadius = 0f;
    public GameObject impactEffect;

     public AudioSource soundControl;
  public AudioClip shootSound;
  

    public int damage = 50;

    //public GameObject impactEffect;

    public void Chase(Transform _target)
    {
        target = _target;
    }
   
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude<= distanceThisFrame)
        {
            HitTarget();
            return;
        } 

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {
       GameObject effectIns =(GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
       Destroy(effectIns, 6f);
        
        if(explotionRadius>0)
        {
            
            Explode();

        }
        else
        {
            
            Damage(target);
        }
        Debug.Log("pego");
        soundControl.PlayOneShot(shootSound);
        Destroy(gameObject);
    }

    void Explode()
    {
       
      Collider[] colliders =  Physics.OverlapSphere(transform.position, explotionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);

            }
        }
   
    }

    void Damage(Transform enemy )
    {
      Enemy e = enemy.GetComponent<Enemy>();

      e.TakeDamage(damage);
        
    }
     void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.green;
      Gizmos.DrawWireSphere(transform.position,explotionRadius);
    }
}
