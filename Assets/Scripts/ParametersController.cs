using UnityEngine;
using UnityEngine.UI;

public class ParametersController : MonoBehaviour
{
    public int lowBracket, highBracket;

    public Slider leakOfResult;
    public Image leakOfResultImage;

    public Gradient resultGradient;

    private void Awake()
    {
        #region Setup Sliders
        leakOfResult.minValue = lowBracket;
        leakOfResult.maxValue = highBracket;
        leakOfResult.interactable = false;
        #endregion
    }

    private void Start()
    {
        #region Base Values
        leakOfResult.value = Mathf.Clamp(LevelEnvironment.Instance.materialRequired.heat, lowBracket, highBracket);
        #endregion

        MaterialsCollector.Instance.onMaterialSelected.AddListener(MaterialAdded);
        MaterialsCollector.Instance.onMaterialRemoved.AddListener(MaterialRemoved);
    }

    public void MaterialAdded(SuitMaterial material)
    {
        float val = LevelEnvironment.Instance.CalculateValues();
        val = Mathf.Clamp(val, lowBracket, highBracket);
        leakOfResult.value = val;

        leakOfResult.image.color = resultGradient.Evaluate(leakOfResult.normalizedValue);
    }

    public void MaterialRemoved(int idx)
    {
        float val = LevelEnvironment.Instance.CalculateValues();
        val = Mathf.Clamp(val, lowBracket, highBracket);
        leakOfResult.value = val;

        leakOfResult.image.color = resultGradient.Evaluate(leakOfResult.normalizedValue);
    }
}
