using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int countSphereInMap = 0;
    public static bool startLvl = true;
    [SerializeField]
    Text textFps;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    void Start()
    {
        
    }

    #region FPS
    int fps = 0;
    float currentTime = 0;
    void CalculateFPS()
    {
        currentTime += Time.deltaTime;
        fps++;
        if (currentTime >= 1)
        {
            currentTime -= 1;
            textFps.text = "fps: " + fps;
            fps = 0;
        }
    }
    #endregion
    void Update()
    {
        CalculateFPS();
    }
}
