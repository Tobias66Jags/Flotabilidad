using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public List<GameObject> ballsContainer = new List<GameObject>();


    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private int _amount = 5;
    [SerializeField] private float _timeBetweenShoots;

    private void Awake()
    {
        for (int i = 0; i < _amount; i++)
        {
            var prefabInstance = Instantiate(_ballPrefab);
            prefabInstance.SetActive(false);
            ballsContainer.Add(prefabInstance);
        }
    }



    public GameObject getNewBall()
    {
        if (_amount > 0)
        {
            for (int i = 0; i <= _amount; i++)
            {
                if (!ballsContainer[i].activeInHierarchy)
                {
                    return ballsContainer[i];
                }
            }
        }

        return null;
    }

    public IEnumerator ShootBall(Transform reference)
    {
        var bullet = getNewBall(); //lama al objeto 
      
            
            bullet.transform.position = reference.position;
            var rot = reference.transform.rotation;
        bullet.transform.rotation = rot;
        //   bullet.transform.eulerAngles = new Vector3(0,_reference.rotation.y,0);
        bullet.SetActive(true);
            
        
        yield return new WaitForSeconds(_timeBetweenShoots);
       
    }
}
