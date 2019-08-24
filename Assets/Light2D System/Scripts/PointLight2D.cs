using UnityEngine;
using UnityEngine.Rendering;

public class PointLight2D : Light2D
{
    private static int _LightColorID = Shader.PropertyToID("_PointLight2D_Color");

    [Min(0.0f)]
    public float range = 1.0f;
    public Color color = Color.white;
    [Min(0.0f)]
    public float intensity = 1.0f;

    [SerializeField]
    [HideInInspector]
    private Texture2D _lightTexture;

    public Mesh LightMesh
    {
        get
        {
            if (_lightMesh == null)
            {
                this.GenerateLightMesh();
                _lightMesh.hideFlags = HideFlags.DontSave;
            }

            return _lightMesh;
        }
    }
    private Mesh _lightMesh;

    protected override void OnDisable()
    {
        base.OnDisable();

        if (_lightMesh != null)
        {
            DestroyImmediate(_lightMesh);
        }
    }

    public override void RenderLight(CommandBuffer commandBuffer)
    {
        this.LightMaterial.mainTexture = _lightTexture;
        this.LightMaterial.SetColor(_LightColorID, this.color * this.intensity);

        var matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one * this.range);
        commandBuffer.DrawMesh(this.LightMesh, matrix, this.LightMaterial);
    }

    private void GenerateLightMesh()
    {
        _lightMesh = new Mesh();
        _lightMesh.name = "Point Light Quad";

        _lightMesh.vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, 0.0f),
            new Vector3(-0.5f, 0.5f, 0.0f),
            new Vector3(0.5f, 0.5f, 0.0f),
            new Vector3(0.5f, -0.5f, 0.0f)
        };

        _lightMesh.uv = new Vector2[]
        {
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f)
        };

        _lightMesh.triangles = new int[] { 0, 1, 2, 2, 3, 0 };
    }
}