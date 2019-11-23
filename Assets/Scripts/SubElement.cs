using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubElement : MonoBehaviour
{
    public bool instacie;
    public GameObject piege;
    public float peur = 0f;
    public float vitesse = 0f;


    // Start is called before the first frame update
    void Start()
    {
        if (instacie)
        {
            Instantiate(piege, new Vector3(transform.position.x,0), transform.rotation);
        }
        Debug.Log("ok");
        GameObject joueur = GameObject.Find("personnage");
        joueur.GetComponent<Joueur>().UtilisationElement(vitesse, peur, transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
