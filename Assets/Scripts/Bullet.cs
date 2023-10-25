using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager manager;
    [SerializeField] private float Speed = 1;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            manager.Enemies.Remove(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("WallToDestroy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
}
