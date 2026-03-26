using UnityEngine;

public class DisableMouseInput : MonoBehaviour
{
    private static DisableMouseInput instance = new();
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;  

        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
