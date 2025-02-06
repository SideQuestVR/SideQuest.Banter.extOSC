using UnityEngine;
using UnityEngine.UI;

public class SliderAnimator : MonoBehaviour
{
    public Slider[] sliders; // Array of sliders to animate
    public float[] animationSpeeds; // Individual speed for each slider
    public bool[] animateSliders; // Toggle for each slider animation
    public bool globalAnimate = false; // Global toggle for animation
    public AnimationMode animationMode = AnimationMode.Loop; // Animation mode

    private float[] sliderValues;
    private bool[] direction; // For ping-pong mode

    public enum AnimationMode
    {
        Loop,
        PingPong
    }

    void Start()
    {
        if (sliders.Length != animationSpeeds.Length || sliders.Length != animateSliders.Length)
        {
            Debug.LogError("Ensure sliders, animationSpeeds, and animateSliders arrays are of the same length!");
            return;
        }

        sliderValues = new float[sliders.Length];
        direction = new bool[sliders.Length];

        // Initialize slider values and direction
        for (int i = 0; i < sliders.Length; i++)
        {
            sliderValues[i] = sliders[i].value;
            direction[i] = true; // Start moving forward for ping-pong
        }
    }

    void Update()
    {
        if (globalAnimate)
        {
            AnimateSliders();
        }
    }

    private void AnimateSliders()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            if (!animateSliders[i]) continue; // Skip sliders that are not toggled for animation

            if (animationMode == AnimationMode.Loop)
            {
                sliderValues[i] += animationSpeeds[i] * Time.deltaTime;
                if (sliderValues[i] > sliders[i].maxValue)
                {
                    sliderValues[i] = sliders[i].minValue;
                }
            }
            else if (animationMode == AnimationMode.PingPong)
            {
                if (direction[i])
                {
                    sliderValues[i] += animationSpeeds[i] * Time.deltaTime;
                    if (sliderValues[i] >= sliders[i].maxValue)
                    {
                        direction[i] = false; // Reverse direction
                    }
                }
                else
                {
                    sliderValues[i] -= animationSpeeds[i] * Time.deltaTime;
                    if (sliderValues[i] <= sliders[i].minValue)
                    {
                        direction[i] = true; // Reverse direction
                    }
                }
            }

            sliders[i].value = sliderValues[i];
        }
    }

    // Call this method to manually set slider values when not animating
    public void SetSliderValue(int index, float value)
    {
        if (index < 0 || index >= sliders.Length)
        {
            Debug.LogError("Index out of range");
            return;
        }

        if (!globalAnimate)
        {
            sliders[index].value = value;
            sliderValues[index] = value;
        }
    }
}
