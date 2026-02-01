using UnityEngine;

public class MenuControll : MonoBehaviour
{
    public Canvas[] canvases;

    public void Start()
    {
        LevelEnvironment.Instance.onGameStarted.AddListener(DisableCanvases);
    }

    public void DisableCanvases(bool a)
    {
        if (!a) return;
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].enabled = false;
        }
    }
}
