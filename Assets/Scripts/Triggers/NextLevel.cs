using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;

public class NextLevel : MonoBehaviour
{
    private BoxCollider _col;

    void Start(){
        _col = gameObject.GetComponent<BoxCollider>();
        _col.enabled = false;
        EventsManager.instance.OnGetKey += OnGetKey;
    }

    private void OnGetKey(){
        _col.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene((int)Levels.Level_2);
        }
    }
}
