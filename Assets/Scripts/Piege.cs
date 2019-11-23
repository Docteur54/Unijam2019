using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege : MonoBehaviour
{

    public float peur;
    public float vitesseSortie;
    public AudioSource sound;

    private bool actif = true;


    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false); // transforme.PrendreEnfant(1).jeuObjet.mettreActif(FAUX);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnMouseDown()
    {
        if (actif)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            actif = false;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(actif){
            other.GetComponent<Joueur>().UtilisationPiege(vitesseSortie, peur);
            sound.Play();
        }
        
    }
}
