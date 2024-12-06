using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstObjectManager : MonoBehaviour
{
    public GameObject Drum; // 0
    public GameObject Timpani; // 1
    public GameObject Cymbal; // 2
    //public GameObject Rainstick; // 3

    public enum InstObjects
    {
        Drum, Timpani, Cymbal, Rainstick
    }

    // Start is called before the first frame update
    void Start()
    {
        Drum.SetActive(false);
        Timpani.SetActive(false);
        Cymbal.SetActive(false);
        //Rainstick.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInstrument()
    {
        Drum.SetActive(false);
        Timpani.SetActive(false);
        Cymbal.SetActive(false);
        //Rainstick.SetActive(false);

        switch (GamePlayManager.GetInstrument())
        {
            case 0: Drum.SetActive(true); break;
            case 1: Timpani.SetActive(true); break;
            case 2: Cymbal.SetActive(true); break;
            //case 3: Rainstick.SetActive(true); break;
        }
    }
}
