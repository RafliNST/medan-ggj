using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelEnvironment : MonoBehaviour
{
    public MaterialValue materialRequired;
    public float timeForResult;

    List<SuitMaterial> selectedMaterials;

    public int normalizeConstant = 10;

    private void Awake()
    {
        selectedMaterials = new List<SuitMaterial>();
    }

    private void Start()
    {
        MaterialsCollector.Instance.onMaterialSelected.AddListener(StoreMaterial);
    }

    public void StartLevel()
    {
        for (int i = 0; i < selectedMaterials.Count; i++)
        {
            materialRequired = materialRequired.Add(selectedMaterials[i].material_value);
        }

        StartCoroutine(WaitForResult(timeForResult));
    }

    IEnumerator WaitForResult(float time)
    {
        yield return new WaitForSeconds(time);

        float N = materialRequired.Normalize(normalizeConstant);
        N = Mathf.Abs(N);

        if (N > 0f && N < 1f)
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
}
