using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour
{
    public Transform targetTujuan;
    public KeyCode tombolPindah = KeyCode.S;
    public SceneFader fader; // Tarik objek Image Hitam ke sini

    private bool playerDiArea = false;
    private Collider2D playerCollider;

    private void Update()
    {
        if (playerDiArea && Input.GetKeyDown(tombolPindah))
        {
            StartCoroutine(ProsesPindah());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDiArea = true;
            playerCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerDiArea = false;
    }

    IEnumerator ProsesPindah()
    {
        // 1. Layar jadi hitam
        yield return StartCoroutine(fader.FadeToBlack());

        // 2. Pindahkan Player
        playerCollider.transform.position = targetTujuan.position;
        Rigidbody2D rb = playerCollider.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;

        // Tunggu sebentar agar mata pemain tidak kaget
        yield return new WaitForSeconds(0.5f);

        // 3. Layar jadi terang kembali
        yield return StartCoroutine(fader.FadeToClear());
    }
}