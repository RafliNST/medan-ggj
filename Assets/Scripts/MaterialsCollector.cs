using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MaterialsCollector : MonoBehaviour
{
    int currentIndex = 0;
    public GameObject parent_material_GO, material_GO;
    [Range(3,10)]
    public int max_materials = 5;

    private Image[] materials_sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        materials_sprite = new Image[max_materials];

        for (int i = 0; i < max_materials; i++)
        {
            GameObject new_material = Instantiate(material_GO, parent_material_GO.transform);
            new_material.name = $"Material_{i}";
            new_material.transform.localPosition = new Vector3(i * 1.5f, 0, 0);

            materials_sprite[i] = new_material.GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendSprite(Image material_icon)
    {
        Debug.Log($"Nama Sprite: {material_icon.sprite.name}, Objek: {material_icon.gameObject.name}");
        materials_sprite[currentIndex].sprite = material_icon.sprite;
    }
}
