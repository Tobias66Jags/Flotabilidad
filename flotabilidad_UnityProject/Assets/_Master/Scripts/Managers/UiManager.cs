using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Image _lifeBar;
    [SerializeField] private Image _shootIndicator;

    private float _currentLife;
    public Health health;
    public PlayerController playerController;


    void Update()
    {
        _currentLife = health.maxHealth;
        _lifeBar.fillAmount = _currentLife / 100;
        _shootIndicator.fillAmount = playerController._currentTime / 2;  
    }



    }
