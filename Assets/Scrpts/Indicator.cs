using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; // Dibutuhkan untuk List

public class Indicator : MonoBehaviour
{
    public Slider indicatorSlider;
    public Transform player;
    
    [Header("Settings")]
    public float currentAmount = 100f;
    public float maxAmount = 100f;
    public float dangerDistance = 4f; 
    public float decreaseSpeed = 15f; 
    public float increaseSpeed = 8f;

    private GameObject[] allEnemies;

    void Start()
    {
        currentAmount = maxAmount;
        indicatorSlider.maxValue = maxAmount;
        
        // Mencari semua musuh di awal game
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        bool isNearAnyEnemy = false;

        // Cek setiap musuh yang ada
        foreach (GameObject enemy in allEnemies)
        {
            if (enemy != null) // Pastikan musuh belum hancur/mati
            {
                float distance = Vector2.Distance(player.position, enemy.transform.position);
                if (distance < dangerDistance)
                {
                    isNearAnyEnemy = true;
                    break; // Jika sudah ketemu 1 yang dekat, berhenti mengecek yang lain
                }
            }
        }

        // Logika bertambah atau berkurang
        if (isNearAnyEnemy)
        {
            currentAmount -= decreaseSpeed * Time.deltaTime;
        }
        else
        {
            currentAmount += increaseSpeed * Time.deltaTime;
        }

        // Update Slider
        currentAmount = Mathf.Clamp(currentAmount, 0, maxAmount);
        indicatorSlider.value = currentAmount;

        // Efek jika bar habis
        if (currentAmount <= 0)
        {
            Debug.Log("Pemain terlalu stress/tertekan!");
            // Tambahkan logika Game Over di sini
        }
    }

    // Panggil ini jika kamu memunculkan musuh baru saat game berjalan (spawning)
    public void RefreshEnemyList()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}