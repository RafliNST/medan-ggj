using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MaterialsCollector : MonoBehaviour
{
    public static MaterialsCollector Instance;

    public int currentIndex { get; private set; } = 0;
    public GameObject parent_material_GO, material_GO;
    [Range(3,10)]
    public int max_materials = 5;

    public Image[] materials_sprite { get; private set; }

    [HideInInspector]
    public UnityEvent<SuitMaterial> onMaterialSelected;
    [HideInInspector]
    public UnityEvent<int> onMaterialRemoved;

    private void Awake()
    {
        Instance = this;

        onMaterialSelected = new UnityEvent<SuitMaterial>();
        onMaterialRemoved = new UnityEvent<int>();
    }

    void Start()
    {
        materials_sprite = new Image[max_materials];        

        onMaterialSelected.AddListener(ReceiveMaterial);
        onMaterialRemoved.AddListener(RemoveMaterial);

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

    public void ReceiveMaterial(SuitMaterial material)
    {
        if (Instance.currentIndex < Instance.max_materials)
        {
            Instance.materials_sprite[currentIndex].sprite = material.material_image.sprite;
            Instance.materials_sprite[currentIndex].color = material.color_influenced;

            Instance.currentIndex++;
        }
    }

    public void RemoveMaterial(int index)
    {
        if (index >= 0 && index < currentIndex)
        {
            currentIndex--;

            for (int i = index; i < currentIndex; i++)
            {
                Instance.materials_sprite[i].sprite = Instance.materials_sprite[i + 1].sprite;
                Instance.materials_sprite[i].color = Instance.materials_sprite[i + 1].color;
            }
            
            for (int i = currentIndex; i < max_materials; i++)
            {
                Instance.materials_sprite[i].sprite = null;
                Instance.materials_sprite[i].color = Color.white;
            }
        }
    }
}
