using UnityEngine;

public class DeactivateInBuild : MonoBehaviour
{
#if !UNITY_EDITOR
    void Start()
    {
        gameObject.SetActive(false);   
    }
#else
    [SerializeField] private bool deactivate;
    void Start()
    {
        gameObject.SetActive(!deactivate);
    }
#endif
}
