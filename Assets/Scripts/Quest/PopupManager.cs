using UnityEngine;
using UnityEngine.UIElements;

public class PopupManager : MonoBehaviour
{
    private VisualElement root;
    private VisualElement popup;

    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        popup = new VisualElement();
        popup.style.width = new Length(200, LengthUnit.Pixel);
        popup.style.height = new Length(150, LengthUnit.Pixel);
        popup.style.backgroundColor = new Color(0, 0, 0, 0.8f);
        popup.style.position = Position.Absolute;
        popup.style.left = 100;
        popup.style.top = 100;

        var closeButton = new Button(() => { popup.style.display = DisplayStyle.None; });
        closeButton.text = "Close";
        popup.Add(closeButton);

        root.Add(popup);
        popup.style.display = DisplayStyle.None; // Initially hidden
    }

    public void ShowPopup()
    {
        popup.style.display = DisplayStyle.Flex;
    }
}
