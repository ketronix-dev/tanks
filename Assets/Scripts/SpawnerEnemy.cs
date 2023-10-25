using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    private GameManager manager;
    [SerializeField] private float Period;
    [SerializeField] private float SpawnTime;

    private bool spawn = true;
    
    private float period;
    
    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        period = Period;
    }

    private void Update()
    {
        SpawnTime -= Time.deltaTime;
        if (SpawnTime <= 0)
        {
            spawn = false;
        }

        if (spawn != false)
        {
            period -= Time.deltaTime;
            if (period <= 0)
            {
                var enemy = Instantiate(Enemy);
                enemy.transform.position = gameObject.transform.position;
                manager.Enemies.Add(enemy);
                period = Period;
            }
        }
    }
}
