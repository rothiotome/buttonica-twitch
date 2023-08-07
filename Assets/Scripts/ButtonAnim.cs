using System.Collections;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    // Variables
    public float animationTime = 0.2f; // Duration of the button click animation
    private Vector2 startLocalPosition;
    private Vector2 targetLocalPosition;
    private bool isAnimating;
    private bool releaseOnFinishClick;
    private AudioSource audioSource;

    [SerializeField] private bool delayedStart;

    private IEnumerator Start()
    {
        if(delayedStart) yield return new WaitForEndOfFrame();
        startLocalPosition = transform.localPosition;
        targetLocalPosition = startLocalPosition;
        audioSource = FindObjectOfType<AudioSource>();
        yield return null;
    }

    // Method to click the button
    public void Click()
    {
        PressButton(true);
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }
    
    public void PressButton(bool releaseAfter = false)
    {
        targetLocalPosition.y = 0;
        releaseOnFinishClick = releaseAfter;
    }
    
    // Method to release the button
    public void Release()
    {
        releaseOnFinishClick = false;
        targetLocalPosition.y = startLocalPosition.y;
    }

    public void OpenSteamPage()
    {
        Application.OpenURL("https://store.steampowered.com/app/1999740/THE_BUTTON/?utm_source=game&utm_medium=buttonica");
    }

    
    private void Update()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, targetLocalPosition, Time.deltaTime / animationTime);

        // Check if the animation is complete
        if (Mathf.Abs(transform.localPosition.y - targetLocalPosition.y) < 0.01f)
        {
            if(releaseOnFinishClick) Release();
        }
    }
}
