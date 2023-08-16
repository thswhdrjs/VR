using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private Transform tr;

    private float y;

    // Start is called before the first frame update
    void Start()
    {
        tr = GameObject.Find("RightHand Controller").transform;
        y = tr.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y >= 0.26f && transform.localPosition.y <= 0.36f)
                transform.localPosition += new Vector3(0, (tr.localPosition.y - y), 0);

        if (transform.localPosition.y < 0.26f)
        {
            transform.localPosition = new Vector3(0, 0.26f, 0);
            y = tr.localPosition.y;
        }
        
        if (transform.localPosition.y > 0.36f)
        {
            transform.localPosition = new Vector3(0, 0.36f, 0);
            y = tr.localPosition.y;
        }
    }
}
