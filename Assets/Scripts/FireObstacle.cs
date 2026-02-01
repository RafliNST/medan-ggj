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
        switch (PlayerDataReciever.Instance.obstacles[0])
        {
            case ObstacleType.HEAT:
                obstactleRenderer.sprite = heatOBS;
                break;
            case ObstacleType.AIR:
                obstactleRenderer.sprite = airOBS;
                break;
            case ObstacleType.LIGHT:
                obstactleRenderer.sprite = lightOBS;
                break;
            case ObstacleType.SOUND:
                obstactleRenderer.sprite= soundOBS;
                break;
            case ObstacleType.SCENT:
                obstactleRenderer.sprite = scentOBS;
                break;
        }
    }
}
