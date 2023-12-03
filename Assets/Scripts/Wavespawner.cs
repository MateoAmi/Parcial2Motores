using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavespawner : MonoBehaviour
{

    public enum SpawnState{SPAWNING, WAITING, COUNTING };
    [System.Serializable]
   public class Wave
   {
        public string name;     
        public Transform enemyPrefab;
        public int count;
        public float rate;

   }
   public Wave[] waves;
   private int nextWave = 0;
    public float Timer = 25f;
    private float countdown;

    public Text waveCountdownText;

    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;
  
  void Start()
  {
    countdown = Timer;
  }
    void Update ()
    {

        if (state == SpawnState.WAITING)
        {
            // ver si los enemigos siguen vivios
            if(!EnemyisAlive())
            {
                //empezar una nueva oleada
                
                WaveCompleted();

            }
            else
            {
                return;

            }
             
        }


        if(countdown<= 0f)
        {
            if(state != SpawnState.SPAWNING)
            {
                //empieza a generar la oleada 
                StartCoroutine(SpawnWave( waves[nextWave] ));
            }
        }
        else
        {
            countdown -= Time.deltaTime;
        }
        
        
    }
    
    void WaveCompleted()
    {
      Debug.Log("oleada completa");

        state = SpawnState.COUNTING;
        countdown = Timer;

        if (nextWave + 1> waves.Length-1 )
        {
            nextWave=0;
            Debug.Log("Todas las oleadas completadas! Looping...");
        }
        else
        {
           nextWave++; 
        }

        
    }
    //revisa si hay enemigos vivos para no generar otra wave cuando la anterior sigue viva
    bool EnemyisAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
          if(GameObject.FindGameObjectWithTag("Enemy")==null)
         {

            return false;
         }
        }
        return true;
    }

        //use un Ienumerator para poder pedirle al codigo que espere unos segundos despues de ejecutarse
     IEnumerator SpawnWave(Wave _wave)
     {
        Debug.Log("Spawning Wave: "+ _wave.name);
        state = SpawnState.SPAWNING;
        //Spawn
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemyPrefab);

            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
     }

     void SpawnEnemy(Transform _enemy)
     {
        //spwnear enemigo
        Debug.Log("Spawning enemy: "+ _enemy.name );
       Instantiate(_enemy, transform.position, transform.rotation);
        
     }
}
