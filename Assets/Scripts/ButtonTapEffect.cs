using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTapEffect : MonoBehaviour
{
    private Button myButton;
    private Image buttonImage;

    public float shrinkScale = 0.9f;
    public float fadeDuration = 0.2f;

    private void Start()
    {
        myButton = GetComponent<Button>();
        buttonImage = GetComponent<Image>();  // Reference to the Image component

        // Adding listeners for the button click interaction
        myButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Shrink the button by changing the scale
        transform.DOScale(shrinkScale, fadeDuration).OnKill(() =>
        {
            // Reset the button scale after animation finishes
            transform.DOScale(1f, fadeDuration);
        });

        // Fade out the button image
        buttonImage.DOFade(0.5f, fadeDuration).OnKill(() =>
        {
            // Reset the opacity to 1 when animation ends
            buttonImage.DOFade(1f, fadeDuration);
        });
    }
}