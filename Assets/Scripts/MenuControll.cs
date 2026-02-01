using UnityEngine;

public class MenuControll : MonoBehaviour
{
    public static MenuControll Instance;

    public Canvas[] canvases;

    public bool menuIsShowed = false;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        LevelEnvironment.Instance.onGameStarted.AddListener(DisableCanvases);

        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].enabled = false;
        }
    }

    public void DisableCanvases(bool a)
    {
        if (!a) return;
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].enabled = false;
        }

        menuIsShowed = true;
    }
}
