using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiDong : MonoBehaviour
{
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int InitDiDong(){
        gameObject.GetComponentInChildren<DiShu>().init();
        return ID;
    }
}
