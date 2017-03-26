using UnityEngine;


public class GameInitial {
[RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(360, 640, false, 60);
    }
}
