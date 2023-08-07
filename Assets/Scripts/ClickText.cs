using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ClickText : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private bool visibleText;

    private float counter = 0;
    private float visibleTime = 0.4f;

    private int currentPosition = 0;
    void Start()
    {
        TryGetComponent(out textMeshProUGUI);
    }

    public void ShowText(string txt)
    {
        counter = 0;
        SetRandomPosition();
        if (txt.Equals("rothiocuchillo")) txt = "<size=200%><color=black>STAB</color></size>";
        textMeshProUGUI.SetText($"*{txt}*");
        visibleText = true;
    }

    private void Update()
    {
        if (visibleText)
        {
            counter += Time.deltaTime;
            if (counter > visibleTime)
            {
                textMeshProUGUI.SetText("");
                visibleText = false;
            }
        }
    }

    private void SetRandomPosition()
    {
        int newPosition = Random.Range(0, 5);
        while (currentPosition == newPosition)
        {
            newPosition = Random.Range(0, 5);
        }
        
        switch (newPosition)
        {
            case 0:
                transform.localRotation = Quaternion.Euler(0, 0, 35);
                textMeshProUGUI.alignment = TextAlignmentOptions.Left;
                break;
            case 1:
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                textMeshProUGUI.alignment = TextAlignmentOptions.Center;
                break;
            case 2:
                transform.localRotation = Quaternion.Euler(0, 0, -35);
                textMeshProUGUI.alignment = TextAlignmentOptions.Right;
                break;
            case 3:
                transform.localRotation = Quaternion.Euler(0, 0, 10);
                textMeshProUGUI.alignment = TextAlignmentOptions.Left;
                break;
            case 4:
                transform.localRotation = Quaternion.Euler(0, 0, -10);
                textMeshProUGUI.alignment = TextAlignmentOptions.Right;
                break;
            default:
                break;
        }
        currentPosition = newPosition;

    }
}
