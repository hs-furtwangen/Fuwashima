using UnityEngine;

public class Blinklight : MonoBehaviour
{
    public float Interval = 1;

    private float timer;
    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = this.gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = Interval;

            light.enabled = !light.enabled;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
