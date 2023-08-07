
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenWebOnClick : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private string website;

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(website);
    }
}
