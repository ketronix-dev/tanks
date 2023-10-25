using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject enemy;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private float Amount;

    private int axis;

    private float period = 1;
    private float firePeriod = 1.5f;
    
    void Start()
    {
        enemy = gameObject;
        RandomAxis();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (axis >= 0 && axis < 25)
            {
                axis += 60;
            }
            if(axis > 25 && axis < 50)
            {
                axis += 30;
            }
            if(axis > 50 && axis < 75)
            {
                axis = 0;
            }
            if(axis > 75)
            {
                axis = 51;
            }
        }
    }
    
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        RandomDirection();
    }

    private void Update()
    {
        period -= Time.deltaTime;
        if (period <= 0)
        {
            RandomAxis();
            period = 1;
        }
        firePeriod -= Time.deltaTime;
        if (firePeriod <= 0)
        {
            Shoot();
            firePeriod = 1.5f;
        }
    }

    void RandomAxis()
    {
        System.Random rand = new System.Random();
        int result = rand.Next(0, 100);

        axis = result;
    }

    void RandomDirection()
    {
        if (axis >= 0 && axis < 25)
        {
            enemy.transform.rotation = Quaternion.Euler(0,0,90);
            enemy.transform.position = new Vector3(transform.position.x - Amount * Time.fixedDeltaTime, transform.position.y, 0);
        }
        if(axis > 25 && axis < 50)
        {
            enemy.transform.rotation = Quaternion.Euler(0,0,-90);
            enemy.transform.position = new Vector3(transform.position.x + Amount * Time.fixedDeltaTime, transform.position.y, 0);
        }
        if(axis > 50 && axis < 75)
        {
            enemy.transform.rotation = Quaternion.Euler(0,0,0);
            enemy.transform.position = new Vector3(transform.position.x, transform.position.y + Amount * Time.fixedDeltaTime, 0);
        }
        if(axis > 75)
        {
            enemy.transform.rotation = Quaternion.Euler(0,0,180);
            enemy.transform.position = new Vector3(transform.position.x, transform.position.y - Amount * Time.fixedDeltaTime, 0);
        }
    }
    
    void Shoot()
    {
        if (bulletPrefab != null && gunTransform != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            // Тут ви створюєте пулю і робите її летіти в напрямку пушки танка
        }
    }
}
