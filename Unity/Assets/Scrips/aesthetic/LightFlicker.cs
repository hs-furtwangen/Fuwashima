using UnityEngine;

[RequireComponent (typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    Light lt;

    [SerializeField]
    public float intensityMultiplyer = 5, timeScale = 5, flickerFactor = 0.5f;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * timeScale, 1);
        lt.intensity = Mathf.Lerp(1, noise, flickerFactor) * intensityMultiplyer;
    }
}
