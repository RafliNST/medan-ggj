using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MaterialsCollector : MonoBehaviour
{
    public static MaterialsCollector Instance;

    int currentIndex = 0;
    public GameObject parent_material_GO, material_GO;
    [Range(3,10)]
    public int max_materials = 5;

    public Image[] materials_sprite;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        materials_sprite = new Image[max_materials];

        for (int i = 0; i < max_materials; i++)
        {
            GameObject new_material = Instantiate(material_GO, parent_material_GO.transform);
            new_material.name = $"Material_{i}";
            new_material.transform.localPosition = new Vector3(i * 1.5f, 0, 0);

            materials_sprite[i] = new_material.GetComponent<Image>();
            materials_sprite[i].sprite = null;
        }
    }

    void Update()
    {
        
    }

    public void SendSprite(Material material)
    {
        if (Instance.currentIndex < Instance.max_materials)
        {
            Debug.Log($"Nama Sprite: {material.icon}, Objek: {material.gameObject.name}");
            Instance.materials_sprite[currentIndex].sprite = material.material_image.sprite;
            Instance.materials_sprite[currentIndex].color = material.color_influenced;

            Instance.currentIndex++;
        }
    }
}
