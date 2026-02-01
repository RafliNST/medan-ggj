using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    public float timeForResult, normalization_val, current_error_margin;

    public string gameplaySceneName;

    private CinemachineCamera virtualCamera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LevelEnvironment.Instance.onGameStarted.AddListener((started) =>
        {
            normalization_val = LevelEnvironment.Instance.CalculateValues();
            Debug.Log($"Game Started: {started}, Value: {normalization_val}");
            
            StartCoroutine(WaitForResult(timeForResult, normalization_val));
        });
    }

    IEnumerator WaitForResult(float time, float N)
    {
        yield return new WaitForSeconds(time);

        if (normalization_val <= 0 && normalization_val > 1f)
        {
            current_error_margin += 20f / 100f;

            float chance = Random.Range(0f, 1f);
            if (chance <= current_error_margin)
            {
                Debug.Log("you failed, cant continue");
            }            
        }
        else
        {
            Debug.Log("berhasil");
            NextObstacle();
        }
    }

    public void NextObstacle()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }
}
