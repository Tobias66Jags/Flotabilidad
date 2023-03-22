using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject[] objectives;
    public float[] timer = new float[2] { 3, 6 };
    public Health health;

    [SerializeField] private float _speed=1;
    private Rigidbody _rb;
    private float _currentTime;
    private Transform _currentTarget;

    private void Start()
    {
        objectives = GameObject.FindGameObjectsWithTag("Target");
        StartCoroutine(SetNewTarget());
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
            GoToNewPosition();
        
       
    }


    private GameObject NewObjective()
    {
        int newIndex = Random.Range(0, objectives.Length);
        return objectives[newIndex];
    }
    private void GoToNewPosition()
    {
        transform.LookAt(_currentTarget,Vector3.up);
        _rb.position = Vector3.Lerp(_rb.position, _currentTarget.position, _speed*Time.deltaTime);
    }


    private IEnumerator SetNewTarget()
    {
        while (true)
        {
            _currentTarget = NewObjective().transform;
            yield return new WaitForSeconds(Random.Range(timer[0], timer[1]));
        }
    }
}
