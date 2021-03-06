﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject spawnPoint;
    public int numberOfEnemies;
    [HideInInspector] public List<SpawnPoint> enemySpawnPoints;
	// Use this for initialization
	void Start () {

        //set the randmo spawn points over here
		for(int i = 0; i < numberOfEnemies; i++)
        {
            var spawnPosition = new Vector3(Random.Range(-16f, 16f), 1,Random.Range(-16f, 16f));
            var spawnRotation = Quaternion.Euler(0f, Random.Range(0, 180), 0);
            SpawnPoint enemySpawnPoint = (Instantiate(spawnPoint, 
                                                        spawnPosition, 
                                                        spawnRotation) 
                                                        as GameObject).GetComponent<SpawnPoint>();
            enemySpawnPoints.Add(enemySpawnPoint);
        }

        SpawnEnemies();
	}
    public void SpawnEnemies(/*List<SpawnPoint>/*TODO networking*/)
    {
        //TODO 
        int i = 0;
        foreach(SpawnPoint sp in enemySpawnPoints)
        {
            Vector3 position = sp.transform.position;
            Quaternion rotation = sp.transform.rotation;
            GameObject newEnemy = Instantiate(enemy, position, rotation) as GameObject;
            newEnemy.name = i+"";
            PlayerController pc = newEnemy.GetComponent<PlayerController>();
            pc.isLocalPlayer = false;
            Health h = newEnemy.GetComponent<Health>();
            h.currentHealth = 100;
            h.OnChangeHealth();
            h.isEnemy = true;
            i++;
        }
    }
}
