using UnityEngine;

public class rubberSpawner : MonoBehaviour
{
    [SerializeField]
    float rate = 0.5f, spawnRadius = 1;
    [SerializeField]
    GameObject r1, r2, r3, r4;

    void Awake()
    {
       InvokeRepeating(nameof(spawn), 0, 0.5f);
    }

    void spawn() 
    {
        if (Random.Range(0f, 1f) < rate)
        {
            int r = (int)Mathf.Floor(Random.Range(0,4));
            Vector3 pos = transform.position + new Vector3(Random.Range(-spawnRadius,spawnRadius), 0, Random.Range(-spawnRadius,spawnRadius));

            switch (r)
            {
                case 1:
                    Instantiate(r1, pos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(r2, pos, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(r3, pos, Quaternion.identity);
                    break;
                default:
                    Instantiate(r4, pos, Quaternion.identity);
                    break;
            }
        }
    }
}
