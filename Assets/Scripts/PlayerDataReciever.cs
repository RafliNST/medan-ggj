using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataReciever : MonoBehaviour
{
    float normalization_val, current_error_margin;    

    public static PlayerDataReciever Instance;

    public Color playerColor;

    public List<ObstacleType> obstacles = new List<ObstacleType>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (Player.Instance != null)
        {
            normalization_val = Player.Instance.normalization_val;
            current_error_margin = Player.Instance.current_error_margin;
        }

        playerColor = SuitRenderer.Instance.finalColor;
        GenerateRandomObstacles();
    }

    void GenerateRandomObstacles()
    {
        obstacles.Clear();

        obstacles.AddRange(new ObstacleType[]
        {
        ObstacleType.HEAT,
        ObstacleType.AIR,
        ObstacleType.SOUND,
        ObstacleType.LIGHT,
        ObstacleType.SCENT
        });

        Shuffle(obstacles);
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    public IEnumerator WaitForResult(float time)
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
        }
    }
}

public enum ObstacleType
{
    HEAT = 0,
    AIR = 1,
    SOUND = 2,
    LIGHT = 3,
    SCENT = 4,
} 
