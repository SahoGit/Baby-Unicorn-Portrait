using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleScroll : MonoBehaviour
{
    public Slider slider;
    public Text valueText;
    public Button myButton;

    private bool isDragging = false;

    void Start()
    {
        // Initialize the text with the initial slider value
        UpdateValueText();

        // Set the button as inactive at the start
        myButton.interactable = false;
    }

    void Update()
    {
        // Check if the mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse pointer is over the slider
            if (IsMouseOverSlider())
            {
                isDragging = true;
            }
        }

      
        if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0))
        {
            isDragging = false;
        }

       
        if (isDragging && slider != null)
        {
            float scrollInput = Input.GetAxis("Mouse Y");
            slider.value += scrollInput;
        }

      
        UpdateValueText();

        // Check if the slider value is greater than 0 to make the button interactable
        if (slider != null && myButton != null)
        {
            myButton.interactable = (slider.value > 0);
        }
    }

    // Helper method to check if the mouse is over the slider
    bool IsMouseOverSlider()
    {
        RectTransform sliderRect = slider.GetComponent<RectTransform>();
        Vector2 localMousePosition;

        // Convert mouse position to local coordinates of the slider
        RectTransformUtility.ScreenPointToLocalPointInRectangle(sliderRect, Input.mousePosition, null, out localMousePosition);

        // Check if the local mouse position is within the slider's rect
        return sliderRect.rect.Contains(localMousePosition);
    }

    // Update the text to display the current slider value
    void UpdateValueText()
    {
        if (slider != null && valueText != null)
        {
            // Convert the slider value to an integer
            int integerValue = Mathf.RoundToInt(slider.value);
            PlayerPrefs.SetInt("Age", integerValue);
            valueText.text = "" + integerValue.ToString();
        }
    }

   
}
