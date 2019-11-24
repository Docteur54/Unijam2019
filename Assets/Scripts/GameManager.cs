﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    public Joueur joueur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uIManager.pulseManager.stresse = joueur.peur / 100;

        if (joueur.peur >= 99){
            uIManager.GameOver();
            joueur.Dead();
            joueur.vitesseActuelle = 0;
            joueur.vitesseDesiree = 0;
            joueur.peur = 102;
        }
    }
}
