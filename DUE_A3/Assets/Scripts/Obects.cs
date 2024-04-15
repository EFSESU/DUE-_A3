using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obects : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider o)
    {
        if (o.tag=="Player")
        {
            this.gameObject.SetActive(false);
            GameCtrl.Instance.AddObjsCount();
         
        }
    }
}
