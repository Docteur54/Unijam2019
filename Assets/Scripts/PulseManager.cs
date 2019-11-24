using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseManager : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    public float stresse;
    public RectTransform objectTransform;

    float dureeUnBatement;
    float amplitude;
    public Vector2 defaultPosition;
    float frequence;

    public float dureeUnBatementMIN;
    public float amplitudeMIN;
    public Vector2 defaultPositionMIN;
    public float frequenceMIN;

    public float dureeUnBatementMAX;
    public float amplitudeMAX;
    public Vector2 defaultPositionMAX;
    public float frequenceMAX;

    bool canLaunch;
    bool canBeat;
    float valeurInLaunch;
    float time;

    public AudioSource sound;
    public Joueur joueur;

    private float _factor;

    public float factor
    {
        get { return _factor; }
        set { }
    }

    // Start is called before the first frame update
    void Start()
    {
        canLaunch = true;
        objectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canLaunch)
        {
            canLaunch = false;
            time = 0;
            dureeUnBatement = (stresse) * (dureeUnBatementMAX - dureeUnBatementMIN) + dureeUnBatementMIN;
            amplitude = stresse * (amplitudeMAX - amplitudeMIN) + amplitudeMIN;
            defaultPosition = new Vector2((stresse) * (defaultPositionMAX.x - defaultPositionMIN.x) + defaultPositionMIN.x, (stresse) * (defaultPositionMAX.y - defaultPositionMIN.y) + defaultPositionMIN.y);
            frequence = stresse * (frequenceMAX - frequenceMIN) + frequenceMIN;
            sound.Play();
        }

        if (time > 1/frequence) canLaunch = true;

        _factor = transform_Factor(time, dureeUnBatement, amplitude);
        //Debug.Log(_factor);

        time += Time.deltaTime;

        //Modification du transform* 1-((_factor - 1) / 2)* (1-(_factor - 1) / 2)
        float transformFactor = 1 - _factor;
        //Debug.Log(transformFactor);
        objectTransform.offsetMin = new Vector2(-defaultPosition.x * transformFactor, -defaultPosition.y * transformFactor);
        objectTransform.offsetMax = new Vector2(defaultPosition.x * transformFactor, defaultPosition.y * transformFactor);
    }
    
    float transform_Factor(float t, float dt, float amplitude)
    {
        float a = 4 * amplitude / dt;
        if (t >= 0 && t < dt / 4) return t * a;
        else if (t >= dt/4 && t < dt/2) return 2 * amplitude - t * a;
        else if (t >= dt/2 && t < 3 * dt / 4) return - 2 * amplitude + t * a;
        else if (t >= 3 * dt / 4 && t < dt) return 4 * amplitude - t * a;
        else return 0;
    }


}
