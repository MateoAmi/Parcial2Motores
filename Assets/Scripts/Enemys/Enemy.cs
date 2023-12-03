using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour 
{
    public float speed = 10f;
    private Transform target;
	private int wavepointIndex = 0;

	public int health = 100;

	public int value = 20;

	

	public virtual void Start()
	{
		target = Waipoints.points[0];
	}

	public virtual void TakeDamage(int amount)
	{
		health-= amount;
		if(health<=0)
		{
			Die();
		}
	}

	public virtual void Die()
	{
		PlayerStats.Money += value;
		Destroy(gameObject);
	}

	public virtual void Update()
	{
        //obtener la direccion del mov
		Vector3 dir = target.position - transform.position;
		//el movimiento en si 
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

	}

	
//pasar de waypoint a waypoint
   public virtual void GetNextWaypoint()
	{
		if (wavepointIndex >= Waipoints.points.Length - 1)
		{
			
			EndPath();
            return;
		}

		wavepointIndex++;
		target = Waipoints.points[wavepointIndex];
	}

	public virtual void EndPath()
	{
		PlayerStats.Lives--;
		
		Destroy(gameObject);
	}

}
