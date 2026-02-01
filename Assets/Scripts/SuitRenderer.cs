using System.Collections.Generic;
using UnityEngine;

public class SuitRenderer : MonoBehaviour
{
    public static SuitRenderer instance;

    public SpriteRenderer spriteRenderer;

    List<Color> color_blender = new List<Color>();

    private void Awake()
    {
        instance = this;

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.color = Color.black;
        
        MaterialsCollector.Instance.onMaterialSelected.AddListener(UpdateSuitScheme);
        MaterialsCollector.Instance.onMaterialRemoved.AddListener(ReduceColorScheme);
    }

    public void UpdateSuitScheme(SuitMaterial a)
    {
        if (MaterialsCollector.Instance.currentIndex >= MaterialsCollector.Instance.max_materials) return;

        Color blend = (spriteRenderer.color + a.color_influenced) 
            / ((MaterialsCollector.Instance.currentIndex == 0) ? 1 : MaterialsCollector.Instance.currentIndex);
        blend.a = 1f;

        spriteRenderer.color = blend;

        color_blender.Add(a.color_influenced);
    }

    public void ReduceColorScheme(int a)
    {
        if (MaterialsCollector.Instance.currentIndex <= 0 ||
            a >= MaterialsCollector.Instance.currentIndex) return;

        Color blend = Color.black;
        for (int i = 0; i < color_blender.Count; i++)
        {
            blend += color_blender[i];
        }
        blend -= color_blender[a];
        blend /= color_blender.Count;

        blend.a = 1f;

        color_blender.RemoveAt(a);

        spriteRenderer.color = blend;
    }
}
