using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public ShootManager shootManager;

    [SerializeField] private float _shootDistance=5;
    [SerializeField] private float _timeBeetwenShoots=3;
    [SerializeField] private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;
        RaycastHit hit;
      
        if (Physics.Raycast(transform.position, transform.forward, out hit, _shootDistance, LayerMask.GetMask("Player"))&& _currentTime>=_timeBeetwenShoots)
        {
            StartCoroutine(shootManager.ShootBall(this.transform));
            _currentTime = 0;
        }
    }
}
