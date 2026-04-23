using UnityEngine;
using UnityEngine.UI;

public class SelectedMaterial : MonoBehaviour
{
    private static int currentIndex = 0;
    private int ownIndex;

    private void Start()
    {
        ownIndex = currentIndex;
        currentIndex++;

        gameObject.GetComponent<Button>().onClick.AddListener(SendIndex);
    }

    public void SendIndex()
    {
        MaterialsCollector.Instance.onMaterialRemoved.Invoke(ownIndex);
    }
}
