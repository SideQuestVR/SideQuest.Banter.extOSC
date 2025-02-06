using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Button button; // Reference to the button component
    public Color onColor = Color.green; // Color when toggled on
    public Color offColor = Color.red; // Color when toggled off

    private bool isToggled = false; // Tracks the toggle state
    private Image buttonImage; // Reference to the button's image component

    void Start()
    {
        if (button == null)
        {
            button = GetComponent<Button>();
        }

        buttonImage = button.GetComponent<Image>();

        if (buttonImage != null)
        {
            buttonImage.color = offColor; // Set initial color
        }

        button.onClick.AddListener(ToggleButtonColor);
    }

    private void ToggleButtonColor()
    {
        isToggled = !isToggled; // Flip the toggle state

        if (buttonImage != null)
        {
            buttonImage.color = isToggled ? onColor : offColor;
        }
    }
}
