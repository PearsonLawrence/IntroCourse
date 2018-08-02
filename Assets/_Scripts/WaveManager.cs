using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveManager : MonoBehaviour {

    public Spawner[] Spawners;

    public int Wave;
    public Text WaveText;

    // Use this for initialization
    void Start () {
        Spawners = GameObject.FindObjectsOfType<Spawner>();
       
	}
	
    public void UpdateWaves()
    {
        Wave++;

        for(int i = 0; i < Spawners.Length; i++)
        {
            Spawners[i].SpawnerDead = false;
            Spawners[i].DestroyAI();
            Spawners[i].SpawnedMonsters.Clear();
            Spawners[i].AIAlive = 0;

            Spawners[i].MaxAI = 1 + Wave;
        }
    }

    public void CheckSpawners()
    {
        for(int i = 0; i < Spawners.Length; i++)
        {
            if (!Spawners[i].SpawnerDead) return;
        }

        UpdateWaves();
    }

	// Update is called once per frame
	void Update () {
        if (WaveText) WaveText.text = Wave.ToString();
	}
}
