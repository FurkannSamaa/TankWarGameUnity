using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 1.2f; 

    private void Awake()
    {
        Destroy(gameObject,life);
    }
    
   

}
