using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 10f;
    WinOrLose lose;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        lose = FindObjectOfType<WinOrLose>();
    }
    private void Update()
    {
        currentHealth = lose.currentHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
    
    
}