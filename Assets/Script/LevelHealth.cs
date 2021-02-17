using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelHealth : MonoBehaviour
{
    [SerializeField] float health;
    TextMeshProUGUI healthText;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.SetText("HP = " + health.ToString());
    }

    public void SpendHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            FindObjectOfType<Level>().LoadGameOver();
        }
        UpdateDisplay();
    }
}
