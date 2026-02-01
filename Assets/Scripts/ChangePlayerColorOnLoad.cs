using UnityEngine;
using UnityEngine.Events;

public class ChangePlayerColorOnLoad : MonoBehaviour
{
    public static ChangePlayerColorOnLoad Instance;

    public SpriteRenderer playerRenderer;

    public UnityEvent onSceneChanged;

    public float timeBeforeEmit = 2f;

    private void Awake()
    {
        onSceneChanged = new UnityEvent();

        Instance = this;
    }

    void Start()
    {
        playerRenderer.color = PlayerDataReciever.Instance.playerColor;
        

        StartCoroutine(PlayerDataReciever.Instance.WaitForResult(timeBeforeEmit));
    }
}
