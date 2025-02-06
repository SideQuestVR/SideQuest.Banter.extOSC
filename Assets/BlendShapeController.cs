using UnityEngine;
using UnityEngine.UI;

public class BlendShapeController : MonoBehaviour
{
    // Reference to the SkinnedMeshRenderer
    public SkinnedMeshRenderer skinnedMeshRenderer;

    // Index of the blend shape you want to control
    public int blendShapeIndex;

    // This function is called when the slider's value changes
    public void OnSliderValueChanged(float value)
    {
        // Update the blend shape weight with the slider value
        skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, value);
    }
}
