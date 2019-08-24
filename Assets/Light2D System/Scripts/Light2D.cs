using UnityEngine;
using UnityEngine.Rendering;

public abstract class Light2D : MonoBehaviour
{
    [SerializeField]
    [HideInInspector]
    private Light2DSet _lightSet = default;
    [SerializeField]
    [HideInInspector]
    private Shader _lightShader;

    public Material LightMaterial
    {
        get
        {
            if (_lightMaterial == null)
            {
                _lightMaterial = new Material(_lightShader);
                _lightMaterial.hideFlags = HideFlags.DontSave;
            }

            return _lightMaterial;
        }
    }

    private Material _lightMaterial;

    protected virtual void OnEnable()
    {
        _lightSet.AddLight(this);
    }

    protected virtual void OnDisable()
    {
        _lightSet.RemoveLight(this);

        if (_lightMaterial != null)
        {
            DestroyImmediate(_lightMaterial);
        }
    }

    public virtual void RenderLight(CommandBuffer commandBuffer) { }
}