using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject AIPrefab;
    public GameObject Target;

    public List<GameObject> SpawnedMonsters;

    public float SpawnTimer;
    public float CurrentSpawnTimer;

    public int AIAlive;
   
    public int MaxAI;

    public bool SpawnerDead;

    public WaveManager Manager;

    public void SpawnMonster()
    {
        GameObject Monster = Instantiate(AIPrefab, transform.position, transform.rotation);
        Monster.GetComponent<AIMonsterController>().Target = Target;
        Monster.GetComponent<AIMonsterController>().MySpawner = this;
        
        SpawnedMonsters.Add(Monster);
        AIAlive++;
        CurrentSpawnTimer = SpawnTimer;

    }

    public void AIDie()
    {
        AIAlive--;
    }
    public void DestroyAI()
    {
        for(int i = 0; i < SpawnedMonsters.Count; i++)
        {
            Destroy(SpawnedMonsters[i]);
        }
    }
	// Use this for initialization
	void Start () {
        Manager = FindObjectOfType<WaveManager>();

    }
	
	// Update is called once per frame
	void Update () {

        CurrentSpawnTimer -= Time.deltaTime;

        if(CurrentSpawnTimer <= 0 && SpawnedMonsters.Count < MaxAI && !SpawnerDead)
        {
            SpawnMonster();
        }

        if(AIAlive < 1 && SpawnedMonsters.Count >= MaxAI - 1 && !SpawnerDead)
        {
            SpawnerDead = true;
            Manager.CheckSpawners();
        }
	}
}
