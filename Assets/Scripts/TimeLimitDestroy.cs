using System.Collections;
using UnityEngine;

public class TimeLimitDestroy : MonoBehaviour
{
    public float timer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);        
    }
}
