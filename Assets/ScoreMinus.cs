using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMinus : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    public void Enable()
    {
        sr.enabled = true;
        Invoke("Disable", 0.5F);
    }

    // Update is called once per frame
    private void Disable()
    {
       sr.enabled = false;
    }
}
