using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

public class LevelEnvironment : MonoBehaviour
{
    public static LevelEnvironment Instance;

    public MaterialValue materialRequired;
    public float timeForResult;

    public List<SuitMaterial> selectedMaterials { get; private set; }

    [HideInInspector]
    public UnityEvent<bool> onGameStarted;

    public int normalizeConstant = 10;

    private void Awake()
    {
        Instance = this;
        selectedMaterials = new List<SuitMaterial>();
        onGameStarted = new UnityEvent<bool>();
    }

    private void Start()
    {
        MaterialsCollector.Instance.onMaterialSelected.AddListener(StoreMaterial);
        MaterialsCollector.Instance.onMaterialRemoved.AddListener(RemoveMaterial);
    }

    public void StartLevel()
    {
        if (selectedMaterials.Count < MaterialsCollector.Instance.max_materials)
        {
            onGameStarted?.Invoke(false);
            return;
        }
        float N = CalculateValues();

        onGameStarted?.Invoke(true);
        StartCoroutine(WaitForResult(timeForResult, N));
    }

    public float CalculateValues()
    {
        float val = materialRequired.Sum();

        for (int i = 0; i < selectedMaterials.Count; i++)
        {
            val += selectedMaterials[i].material_value.Sum();
        }

        float N = val / normalizeConstant;
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
    }

    void StoreMaterial(SuitMaterial material)
    {
        selectedMaterials.Add(material);
    }

    void RemoveMaterial(int idx)
    {
        if (selectedMaterials.Count > 0 && idx < MaterialsCollector.Instance.currentIndex)
            selectedMaterials.RemoveAt(idx);
    }
}
