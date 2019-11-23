using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public int nbEtat;
    public int etatInitial = 1;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < etatInitial -1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(etatInitial-1).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(etatInitial != nbEtat)
        {
            transform.GetChild(etatInitial - 1).gameObject.SetActive(false);
            transform.GetChild(etatInitial).gameObject.SetActive(true);
            etatInitial += 1;
        }
    }
}
