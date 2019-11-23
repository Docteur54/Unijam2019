using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    [SerializeField] GameObject elementPrefab;
    public SpriteRenderer sprite;
    public Rigidbody2D body;
    public float peur = 50;
    public float vitesseActuelle = 4;
    public float vitesseDesiree;
    public float vitesseMax = 8;
    public float coefDecroissancePassive = 0.25f, coefReactivite = 0.5f;
    public float seuilVitesseArret = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Faire décroitre la vitesse au fil du temps
        vitesseDesiree -= coefDecroissancePassive * Time.deltaTime * vitesseDesiree;
        vitesseActuelle += (vitesseDesiree - vitesseActuelle) * coefReactivite * Time.deltaTime;

        // Si le perso va trop lentement, il s'arrête
        if(vitesseActuelle < seuilVitesseArret){
            vitesseActuelle = 0;
            // Game Over
        }

        // Pour éviter que le perso puisse accélérer à l'infini
        if(vitesseActuelle > vitesseMax){
            vitesseActuelle = vitesseMax;
        }

        Deplacement();   
    }

    public void Deplacement(){
        transform.position += new Vector3(vitesseActuelle * Time.deltaTime, 0, 0);
    }

    // ***************************************
    // Lorsque le joueur accélère ou déccélère
    // ***************************************

    // Lorsque le joueur utilise un élément
    public void UtilisationElement(float variationVitesse, float variationPeur, float xObjetBrisable){ 
        peur += variationPeur;
        //vitesseDesiree += variationVitesse;
        
        // Tester si la position de l'objet est devant ou derrière le perso
        // Si l'objet est devant, on ralenti le perso
        if(xObjetBrisable > transform.position.x){
            vitesseDesiree -= variationVitesse;
        }else{ // Si l'objet est derrière ou sur le perso, on accélère le perso
            vitesseDesiree += variationVitesse;
        }
    }

    // Lorsque le personnage prend un piège
    public void UtilisationPiege(float variationVitesse, float variationPeur){
        vitesseDesiree = variationVitesse;
        peur += variationPeur;
    }

}
