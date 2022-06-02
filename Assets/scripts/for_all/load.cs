using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public void AMobile()
    {
        SceneManager.LoadScene(2);
    }
    public void AComputer()
    {
        SceneManager.LoadScene(1);
    }
}
