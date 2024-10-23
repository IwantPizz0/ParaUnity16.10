using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private bool isAiming;
    [SerializeField] private GameObject bullyPrefab;
    [SerializeField] private float shootDelay;
    [SerializeField] private Transform firePoint;
    private float _currTimer;
    private Transform _player;

    private void Start()
    {
        _currTimer = shootDelay;
        _player = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    private void Update()
    {
        DelayShoot();
    }

    private void DelayShoot()
    {
        if (_currTimer > 0)
        {
            _currTimer -= Time.deltaTime;
        }
        else
        {
            Shoot();
            _currTimer = shootDelay;
        }


    }
    private void Shoot()
    {
        if (isAiming)
        {
            firePoint.LookAt(_player);
        }
        Instantiate(bullyPrefab, firePoint.position, firePoint.rotation);
    }
}
