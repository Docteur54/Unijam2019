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
        if (transform.position.x > joueur.transform.position.x) Vitesse = 0;
        GetComponent<AudioSource>().volume = Mathf.Max(0.2f - (1f / 70f) * Mathf.Abs(joueur.transform.position.x - transform.position.x), 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        UI.GameOver();
        joueur.Dead();
    }
}
