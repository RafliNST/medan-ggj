using UnityEngine;
using UnityEngine.UI;

public class ParametersController : MonoBehaviour
{
    public int lowBracket, highBracket;

    public Slider
        heatParam,
        airParam,
        soundParam,
        lightParam,
        scentParam;

    private void Awake()
    {
        #region Setup Sliders
        heatParam.minValue = lowBracket;
        heatParam.maxValue = highBracket;
        heatParam.interactable = false;

        airParam.minValue = lowBracket;
        airParam.maxValue = highBracket;
        airParam.interactable = false;

        soundParam.minValue = lowBracket;
        soundParam.maxValue = highBracket;
        soundParam.interactable = false;

        lightParam.minValue = lowBracket;
        lightParam.maxValue = highBracket;
        lightParam.interactable = false;

        scentParam.minValue = lowBracket;
        scentParam.maxValue = highBracket;
        scentParam.interactable = false;
        #endregion
    }

    private void Start()
    {
        #region Base Values
        heatParam.value = Mathf.Clamp(LevelEnvironment.Instance.materialRequired.heat, lowBracket, highBracket);
        airParam.value = Mathf.Clamp(LevelEnvironment.Instance.materialRequired.air, lowBracket, highBracket);
        soundParam.value = Mathf.Clamp(LevelEnvironment.Instance.materialRequired.sound, lowBracket, highBracket);
        lightParam.value = Mathf.Clamp(LevelEnvironment.Instance.materialRequired.light, lowBracket, highBracket);
        scentParam.value = Mathf.Clamp(LevelEnvironment.Instance.materialRequired.scent, lowBracket, highBracket);
        #endregion

        MaterialsCollector.Instance.onMaterialSelected.AddListener(MaterialAdded);
        MaterialsCollector.Instance.onMaterialRemoved.AddListener(MaterialRemoved);
    }

    public void MaterialAdded(SuitMaterial material)
    {
        heatParam.value += material.material_value.heat;
        airParam.value += material.material_value.air;
        soundParam.value += material.material_value.sound;
        lightParam.value += material.material_value.light;
        scentParam.value += material.material_value.scent;
    }

    public void MaterialRemoved(int idx)
    {
        heatParam.value -= LevelEnvironment.Instance.selectedMaterials[idx].material_value.heat;
        airParam.value -= LevelEnvironment.Instance.selectedMaterials[idx].material_value.air;
        soundParam.value -= LevelEnvironment.Instance.selectedMaterials[idx].material_value.sound;
        lightParam.value -= LevelEnvironment.Instance.selectedMaterials[idx].material_value.light;
        scentParam.value -= LevelEnvironment.Instance.selectedMaterials[idx].material_value.scent;
    }
}
