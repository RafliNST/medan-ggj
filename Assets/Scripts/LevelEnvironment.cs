using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelEnvironment : MonoBehaviour
{
    public static LevelEnvironment Instance;

    public MaterialValue materialRequired;
    public float timeForResult;

    public List<SuitMaterial> selectedMaterials { get; private set; }

    public int normalizeConstant = 10;

    private void Awake()
    {
        Instance = this;
        selectedMaterials = new List<SuitMaterial>();
    }

    private void Start()
    {
        MaterialsCollector.Instance.onMaterialSelected.AddListener(StoreMaterial);
        MaterialsCollector.Instance.onMaterialRemoved.AddListener(RemoveMaterial);
    }

    public void StartLevel()
    {
        if (selectedMaterials.Count < MaterialsCollector.Instance.max_materials)
            return;
        float N = CalculateValues();

        StartCoroutine(WaitForResult(timeForResult, N));
    }

    public float CalculateValues()
    {
        MaterialValue val = new MaterialValue();

        for (int i = 0; i < selectedMaterials.Count; i++)
        {
            val = val.Add(selectedMaterials[i].material_value);
            Debug.Log($"Current: {val.GetValues()}");
        }

        float N = val.Normalize(normalizeConstant);
        N = Mathf.Abs(N);
        return N;
    }

    IEnumerator WaitForResult(float time, float N)
    {
        yield return new WaitForSeconds(time);        

        if (N > 0f && N <= 1f)
        {
            Debug.Log("Level Completed!");
        }
        else
        {
            Debug.Log("Level Failed!");
        }

        Debug.Log($"N val: {N}");
    }

    void StoreMaterial(SuitMaterial material)
    {
        selectedMaterials.Add(material);
    }

    void RemoveMaterial(int idx)
    {
        selectedMaterials.RemoveAt(idx);
    }
}
