using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public bool hasDraged = false;
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

}
