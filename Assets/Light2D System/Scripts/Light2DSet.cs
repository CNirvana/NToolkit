using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Light Set", menuName = "Light Set")]
public class Light2DSet : ScriptableObject
{
    public List<Light2D> Lights
    {
        get
        {
            if (_lights == null)
            {
                _lights = new List<Light2D>();
            }

            return _lights;
        }
    }

    private List<Light2D> _lights;

    public void AddLight(Light2D light)
    {
        if (!this.Lights.Contains(light))
        {
            this.Lights.Add(light);
        }
    }

    public void RemoveLight(Light2D light)
    {
        this.Lights.Remove(light);
    }
}