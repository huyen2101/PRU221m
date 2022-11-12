using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloattingText : MonoBehaviour
{
    [SerializeField]
    public float destroyTime = 3f;

    Vector3 offset = new Vector3(0,1,0);
    Vector3 randomizeIntensity = new Vector3(0.5f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,destroyTime);
        transform.localPosition+= offset;
        transform.localPosition+= new Vector3(
            Random.RandomRange(-randomizeIntensity.x,randomizeIntensity.x),
            Random.RandomRange(-randomizeIntensity.y,randomizeIntensity.y),
            Random.RandomRange(-randomizeIntensity.z,randomizeIntensity.z)
            
            );
    }

}
