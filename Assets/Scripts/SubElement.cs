using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubElement : MonoBehaviour
{
    public bool instacie;
    public GameObject piege;
    public GameObject joueur;
    public float peur = 0f;
    public float vitesse = 0f;


    // Start is called before the first frame update
    void Start()
    {
        if (instacie)
        {
            Instantiate(piege, new Vector3(transform.position.x,0), transform.rotation);
        }
        joueur.GetComponent<Joueur>().UtilisationElement(vitesse, peur, transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
