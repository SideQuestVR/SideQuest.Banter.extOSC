using UnityEngine;
using UnityEngine.UI;

public class SingleSliderAnimator : MonoBehaviour
{
    private Slider animatedSlider; // The slider to animate
    private float animationSpeed = 1.5f; // Default animation speed
    private float currentValue;
    private bool isIncreasing = true; // For ping-pong mode
    private bool isAnimated = false; // Toggle for enabling/disabling animation

    public enum AnimationMode
    {
        Loop,
        PingPong
    }

    private AnimationMode animationMode = AnimationMode.PingPong; // Default animation mode

    void Start()
    {
        animatedSlider = GetComponent<Slider>();
        if (animatedSlider == null)
        {
            return;
        }

        currentValue = animatedSlider.value;
    }

    void Update()
    {
        if (!isAnimated || animationSpeed <= 0f)
            return;

        AnimateSlider();
    }

    private void AnimateSlider()
    {
        if (animationMode == AnimationMode.Loop)
        {
            currentValue += animationSpeed * Time.deltaTime;
            if (currentValue > animatedSlider.maxValue)
            {
                currentValue = animatedSlider.minValue;
            }
        }
        else if (animationMode == AnimationMode.PingPong)
        {
            if (isIncreasing)
            {
                currentValue += animationSpeed * Time.deltaTime;
                if (currentValue >= animatedSlider.maxValue)
                {
                    isIncreasing = false;
                }
            }
            else
            {
                currentValue -= animationSpeed * Time.deltaTime;
                if (currentValue <= animatedSlider.minValue)
                {
                    isIncreasing = true;
                }
            }
        }

        animatedSlider.value = currentValue;
    }

    public void SetAnimationSpeed(float speed)
    {
        animationSpeed = speed;
    }

    public void SetAnimationMode(int mode)
    {
        animationMode = (AnimationMode)mode;
    }

    public void ToggleAnimation()
    {
        isAnimated = !isAnimated;
    }
}
