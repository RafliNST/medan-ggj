using UnityEngine;

public class FireObstacle : MonoBehaviour
{
    public Sprite
        heatOBS,
        airOBS,
        soundOBS,
        lightOBS,
        scentOBS;

    public SpriteRenderer obstactleRenderer;

    private void Start()
    {
        int select = Random.Range(0, (new ObstacleType[]
        {
        ObstacleType.HEAT,
        ObstacleType.AIR,
        ObstacleType.SOUND,
        ObstacleType.LIGHT,
        ObstacleType.SCENT
        }).Length);

        if (PlayerDataReciever.Instance.obstacles.Count == 0) return;
        switch (select)
        {
            case 0:
                obstactleRenderer.sprite = heatOBS;
                break;
            case 1:
                obstactleRenderer.sprite = airOBS;
                break;
            case 2:
                obstactleRenderer.sprite = lightOBS;
                break;
            case 3:
                obstactleRenderer.sprite= soundOBS;
                break;
            case 4:
                obstactleRenderer.sprite = scentOBS;
                break;
        }
    }
}
