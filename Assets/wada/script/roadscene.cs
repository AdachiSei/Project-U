using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class roadscene : MonoBehaviour
{
    [SerializeField, Header("scene名を入れてください")] string _scene = default; 
    public void NextGameScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
