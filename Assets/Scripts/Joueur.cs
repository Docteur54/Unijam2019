using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    [SerializeField] GameObject elementPrefab;
    public SpriteRenderer sprite;
    public Rigidbody2D body;
    public Monstre monstre;

    Animator animator;

    [SerializeField]
    [Range(0, 100)]
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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Faire décroitre la vitesse au fil du temps
        vitesseDesiree -= coefDecroissancePassive * Time.deltaTime * vitesseDesiree;
        if (vitesseDesiree < 0.5) vitesseDesiree = 0;
        vitesseActuelle += (vitesseDesiree - vitesseActuelle) * coefReactivite * Time.deltaTime;
        //Debug.Log(vitesseActuelle);

        peur -= 5 * Time.deltaTime;

        // Si le perso va trop lentement, il s'arrête
        if(vitesseActuelle < 0.4 && vitesseDesiree < vitesseActuelle){
            vitesseActuelle = 0;
            monstre.transform.SetPositionAndRotation(new Vector3(transform.position.x - 10, 0, -2), Quaternion.identity);
            monstre.Vitesse = 7;
            print("monstre arrive ! " + monstre.Vitesse);
        }

        // Pour éviter que le perso puisse accélérer à l'infini
        if(vitesseActuelle > vitesseMax){
            vitesseActuelle = vitesseMax;
        }

        Deplacement();

        if(peur >= 100){
            // Game Over
        }
        if(peur < 0){
            peur = 0;
        }

        animator.SetFloat("Speed", vitesseActuelle);
        if (vitesseActuelle > 4) animator.speed = (vitesseActuelle - 4) / 4 + 1;
        else if (vitesseActuelle > 0.3) animator.speed = (vitesseActuelle - 0.4f) / 6.6f + 0.5f;
        else animator.speed = 1;

       // Debug.Log(vitesseActuelle);
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
        animator.SetBool("Surprise", true);
        //vitesseDesiree += variationVitesse;
        //Debug.Log(variationVitesse);
        // Tester si la position de l'objet est devant ou derrière le perso
        // Si l'objet est devant, on ralenti le perso
        if (xObjetBrisable > transform.position.x){
            vitesseDesiree -= variationVitesse;
        }else{ // Si l'objet est derrière ou sur le perso, on accélère le perso
            vitesseDesiree += variationVitesse;
        }
    }

    // Lorsque le personnage prend un piège
    public void UtilisationPiege(float variationVitesse, float variationPeur){
        animator.SetBool("Trebuche",true);
        Debug.Log("lol");
        vitesseDesiree -= variationVitesse;
        vitesseActuelle = vitesseDesiree;
        peur += variationPeur;
    }

    private void LateUpdate()
    {
        animator.SetBool("Trebuche", false);
        animator.SetBool("Surprise", false);    
    }

}
