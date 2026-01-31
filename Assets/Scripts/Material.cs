using UnityEngine;
using UnityEngine.UI;

public class Material : MonoBehaviour
{
    public Sprite icon;
    public Color color_influenced;

    public Image material_image { get; private set; }
    

    private void Start()
    {
        material_image = GetComponent<Image>();

        material_image.sprite = icon;
        material_image.color = Color.white;
    }
}
