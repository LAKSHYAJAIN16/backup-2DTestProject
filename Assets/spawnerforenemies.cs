using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerforenemies : MonoBehaviour
{
    [Header("Spawnrates")]
    public float EnemySpawnRate = 3f;
    public float ChestSpawnRate = 3f;
    public float CoinSpawnRate = 3f;
    public float MedSpawnRate = 3f;
    [Header("GameObjects cause idk man")]
    public GameObject Medkit;
    [Header("ARRAYS AND ARRAYS AND ARRAYS")]
    public Transform[] chestspawnpoints;
    public Transform[] coinspawnpoints;
    public Transform[] spawnPointsTotal;
    public GameObject[] enemies;
    public GameObject[] chests;
    public GameObject[] Stage2enemies;
    // Start is called before the first frame update
    void Start()
    {
        //Enemies
        InvokeRepeating("SpawnFollow", 0f,EnemySpawnRate);
        Invoke("SpawnFollow", 0.1f);

        //Poiwerups/Chest/Powers/Idk
        InvokeRepeating("SpawnChest", 3f,ChestSpawnRate);
        InvokeRepeating("SpawnMeds", 2f, MedSpawnRate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnFollow()
    {
        int Follow = Random.Range(0,spawnPointsTotal.Length);
        int whichEnemy = Random.Range(0, enemies.Length);
        Instantiate(enemies[whichEnemy], spawnPointsTotal[Follow].position, spawnPointsTotal[Follow].rotation);
    }
    private void SpawnChest()
    {
        int Follow1 = Random.Range(0, spawnPointsTotal.Length);
        int whichEnemy = Random.Range(0, chests.Length);
        Debug.Log(Follow1);
        Instantiate(chests[whichEnemy], chestspawnpoints[Follow1].position, chestspawnpoints[Follow1].rotation);
    }
    private void SpawnMeds()
    {
        int Follow12 = Random.Range(0, 31);
        Debug.Log(Follow12);
        Instantiate(Medkit, chestspawnpoints[Follow12].position, chestspawnpoints[Follow12].rotation);
    }

    //Difficulty level
    public void veryeasy()
    {
        EnemySpawnRate = 3f;
    }
    public void easy()
    {
        EnemySpawnRate = 3f;
        InvokeRepeating("SpawnStage2", 0f,5f);
    }
    public void medium()
    {
        EnemySpawnRate = 4f;
    }
    private void SpawnStage2()
    {
        int Follow = Random.Range(0, spawnPointsTotal.Length);
        int whichEnemy = Random.Range(0, Stage2enemies.Length);
        Instantiate(Stage2enemies[whichEnemy], spawnPointsTotal[Follow].position, spawnPointsTotal[Follow].rotation);
    }
    //SHOP $#!7
    public void SummerBreak()
    {
        EnemySpawnRate = 2f;
        Debug.Log(EnemySpawnRate);
    }
}
