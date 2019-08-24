using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
[ImageEffectAllowedInSceneView]
[RequireComponent(typeof(Camera))]
public class Light2DCamera : MonoBehaviour
{
    private static int _lightMapID = Shader.PropertyToID("_LightMap_2D");
    private static int _screenTex = Shader.PropertyToID("_ScreenTex");

    public Color ambientLightColor = Color.white;
    [Min(0.0f)]
    public float intensity = 1.0f;

    [SerializeField]
    [HideInInspector]
    private Light2DSet _lightSet = default;
    [SerializeField]
    [HideInInspector]
    private Shader _lightingShader;

    public Material LightingMaterial
    {
        get
        {
            if (_lightingMaterial == null)
            {
                _lightingMaterial = new Material(_lightingShader);
                _lightingMaterial.hideFlags = HideFlags.DontSave;
            }

            return _lightingMaterial;
        }
    }
    private Material _lightingMaterial;

    private Camera _renderCamera;
    private CommandBuffer _cb;

    private void Awake()
    {
        _renderCamera = this.GetComponent<Camera>();
    }

    private void OnEnable()
    {
        _cb = new CommandBuffer();
        _renderCamera.AddCommandBuffer(CameraEvent.BeforeImageEffects, _cb);
    }

    private void OnDisable()
    {
        _renderCamera.RemoveCommandBuffer(CameraEvent.BeforeImageEffects, _cb);
        _cb.Release();

        if (_lightingMaterial != null)
        {
            DestroyImmediate(_lightingMaterial);
        }
    }

    private void OnPreRender()
    {
        this.PopulateCommandBuffer();
    }

    private void PopulateCommandBuffer()
    {
        _cb.Clear();

        _cb.GetTemporaryRT(_lightMapID, -1, -1, 0, FilterMode.Bilinear);
        _cb.SetRenderTarget(_lightMapID);
        _cb.ClearRenderTarget(true, true, this.ambientLightColor * this.intensity);

        var lights = GetAllLights();
        foreach (var light in lights)
        {
            light.RenderLight(_cb);
        }

        _cb.SetGlobalTexture(_lightMapID, _lightMapID);

        _cb.GetTemporaryRT(_screenTex, -1, -1, 0, FilterMode.Bilinear);
        _cb.Blit(BuiltinRenderTextureType.CameraTarget, _screenTex);
        _cb.Blit(_screenTex, BuiltinRenderTextureType.CameraTarget, this.LightingMaterial);

        _cb.ReleaseTemporaryRT(_lightMapID);
        _cb.ReleaseTemporaryRT(_screenTex);
    }

    private List<Light2D> GetAllLights()
    {
        if (Application.isPlaying)
        {
            return _lightSet.Lights;
        }
        else
        {
            return FindObjectsOfType<Light2D>().ToList();
        }
    }
}