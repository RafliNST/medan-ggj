using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour
{
    [Header("Settings Level")]
    [SerializeField] private GameObject currentLevel;  
    [SerializeField] private GameObject nextLevel;     
    public SceneFader fader; // Pastikan script SceneFader kamu punya fungsi FadeToBlack & FadeToClear
    
    [Header("Settings Player (Opsional)")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 spawnPointNextLevel;

    [Header("Kondisi")]
    [SerializeField] private string targetTag = "Player";

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Tambahkan cek isTransitioning agar tidak terpanggil dua kali saat proses transisi
        if (collision.CompareTag(targetTag) && !isTransitioning)
        {
            StartCoroutine(SwitchLevelRoutine());
        }
    }

    private IEnumerator SwitchLevelRoutine()
    {
        isTransitioning = true;

        if (nextLevel != null && currentLevel != null && fader != null)
        {
            // 1. Mulai Fade Out ke Hitam
            yield return StartCoroutine(fader.FadeToBlack());

            // 2. Proses Tukar Level (Saat layar sudah gelap)
            nextLevel.SetActive(true);
            currentLevel.SetActive(false);

            // 3. Pindahkan player jika ada
            if (playerTransform != null)
            {
                playerTransform.position = spawnPointNextLevel;
            }

            // Tunggu sebentar agar mata pemain tidak kaget
            yield return new WaitForSeconds(0.5f);

            // 4. Mulai Fade In ke Terang
            yield return StartCoroutine(fader.FadeToClear());
            
            Debug.Log("Level Berhasil Berpindah!");
        }
        else
        {
            Debug.LogWarning("Pastikan Level dan Fader sudah diisi di Inspector!");
        }

        isTransitioning = false;
    }
}