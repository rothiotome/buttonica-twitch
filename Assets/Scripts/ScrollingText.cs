using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private RectTransform textRectTransform;
    private Vector3 startPosition;

    [SerializeField]private float scrollPosition = 0;

    [SerializeField]private float width;

    [SerializeField] private float scrollSpeed = 10;
    
    void Awake()
    {
        TryGetComponent(out tmp);
        TryGetComponent(out textRectTransform);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        width = tmp.preferredWidth;
        startPosition = textRectTransform.localPosition;
    }

    void Update()
    {
        textRectTransform.localPosition = new Vector3(-scrollPosition % width, startPosition.y, startPosition.z);
        scrollPosition += scrollSpeed * 20 * Time.deltaTime;
        if (textRectTransform.localPosition.x + textRectTransform.rect.width < 0) scrollPosition = 0;
    }
}
