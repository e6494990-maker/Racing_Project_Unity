using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraficLights : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] lights;
    void Start()
    {
        StartCoroutine(traficlighting());
    }

    IEnumerator traficlighting()
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].materials[0].color = Color.red;
            lights[i].materials[0].SetColor("_EmissionColor", Color.red);
        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].materials[0].color = Color.yellow;
            lights[i].materials[0].SetColor("_EmissionColor", Color.yellow);
        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].materials[0].color = Color.green;
            lights[i].materials[0].SetColor("_EmissionColor", Color.green);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
