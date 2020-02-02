using UnityEngine;

public class Timeruntilplay : MonoBehaviour
{
    public float Timer;
    private float timerx;

    public int playid;

    void Start()
    {
        timerx = Timer;
    }

    void Update()
    {
        timerx -= Time.deltaTime;

        if (timerx < 0)
        {
            UIAndAmbientSoundManager.staticInstance.PlaySound(playid);
            Destroy(this.gameObject);
        }
    }
}
