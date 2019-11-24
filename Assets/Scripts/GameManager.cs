using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    public Joueur joueur;
    public Monstre monstre;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        uIManager.pulseManager.stresse = joueur.peur / 100;
    }
}
