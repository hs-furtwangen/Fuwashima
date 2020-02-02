using UnityEngine;

public class rubber : MonoBehaviour
{
    Vector3 rVec;
    void Awake()
    {
        Invoke(nameof(end), 2f);
        rVec = new Vector3(Random.Range(0, 70), Random.Range(0, 70), Random.Range(0, 70));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-5,0) * Time.deltaTime, Space.World);
        transform.Rotate(rVec * Time.deltaTime);
    }

    void end() {
        //TOOO Sound
        Destroy(this.gameObject);
    }
}
