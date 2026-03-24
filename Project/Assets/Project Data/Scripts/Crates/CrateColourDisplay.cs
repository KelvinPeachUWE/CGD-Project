using UnityEngine;
using static CrateExtensions;

/// <summary>
/// Changes the object's material's colour to whatever the current quota is.
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class CrateColourDisplay : MonoBehaviour
{
    [SerializeField] Renderer _renderer;
    float alpha;

    private void Awake()
    {
        // Should apply alpha of whats currently on the material
        alpha = _renderer.material.GetColor("_BaseColor").a;
    }

    // Changes the colour of this object's material.
    // Should be called whenever a scheduler's update is called.
    public void UpdateColourDisplay(ScheduleQuota quota)
    {
        var color = quota.requiredTag.GetColourFromTag();
        color.a = alpha;
        _renderer.material.SetColor("_BaseColor", color);
    }
}