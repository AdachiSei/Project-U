using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    List<GameObject> _enemy = new List<GameObject>();

    void Start()
    {
        StartCoroutine(Generator());
    }

    void Update()
    {
        
    }


    IEnumerator Generator()
    {
        
        yield return new WaitForSeconds(0f);
    }
}
