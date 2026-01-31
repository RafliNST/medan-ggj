using System;
using UnityEngine;
using UnityEngine.UI;

public class SuitMaterial : MonoBehaviour
{    
    public Sprite icon;
    public Color color_influenced;

    public MaterialValue material_value = new MaterialValue();

    public Image material_image { get; private set; }
    

    private void Start()
    {
        material_image = GetComponent<Image>();

        material_image.sprite = icon;
        material_image.color = Color.white;

        gameObject.GetComponent<Button>().onClick.AddListener(GotSelected);
    }

    private void GotSelected()
    {
        MaterialsCollector.Instance.onMaterialSelected?.Invoke(this);
    }
}

[Serializable]
public class MaterialValue
{
    public float
        heat,
        air,
        sound,
        light,
        scent;

    public MaterialValue Add(MaterialValue other)
    {
        return new MaterialValue
        {
            heat = this.heat + other.heat,
            air = this.air + other.air,
            sound = this.sound + other.sound,
            light = this.light + other.light,
            scent = this.scent + other.scent
        };
    }

    public float Normalize(int constant)
    {
        return (heat + air + sound + light + scent) / constant;
    }
}
