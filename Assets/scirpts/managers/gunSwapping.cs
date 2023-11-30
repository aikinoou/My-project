using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSwapping : MonoBehaviour
{
    [SerializeField] public int gunNumber;
    public void GunSwap1()
    {
        gunNumber = 1;
    }
    
    public void GunSwap2()
    {
        gunNumber = 2;
    }
    
    public void GunSwap3()
    {
        gunNumber = 3;
    }
    
    public void GunSwap4()
    {
        gunNumber = 4;
    }

}
