using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private float Amount;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.rotation = Quaternion.Euler(0,0,90);
            player.transform.position = new Vector3(transform.position.x - Amount * Time.fixedDeltaTime, transform.position.y, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            player.transform.rotation = Quaternion.Euler(0,0,-90);
            player.transform.position = new Vector3(transform.position.x + Amount * Time.fixedDeltaTime, transform.position.y, 0);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            player.transform.rotation = Quaternion.Euler(0,0,0);
            player.transform.position = new Vector3(transform.position.x, transform.position.y + Amount * Time.fixedDeltaTime, 0);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            player.transform.rotation = Quaternion.Euler(0,0,180);
            player.transform.position = new Vector3(transform.position.x, transform.position.y - Amount * Time.fixedDeltaTime, 0);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
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
