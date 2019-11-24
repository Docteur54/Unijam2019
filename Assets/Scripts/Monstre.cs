using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    public int Vitesse;
    public UIManager UI;
    public Joueur joueur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Translate(new Vector3(Time.deltaTime * Vitesse, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        UI.GameOver();
        joueur.Dead();
    }
}
