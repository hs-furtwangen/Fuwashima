using UnityEngine;

public class Blinklight : MonoBehaviour
{
    public float Interval = 1;

    private float timer;
    private Light lightc;

    // Start is called before the first frame update
    void Start()
    {
        lightc = this.gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = Interval;

            lightc.enabled = !lightc.enabled;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
