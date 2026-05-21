using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            transform.position = new Vector3(0f, 0f, 0f);
        }
        else
        {
            transform.position = new Vector3(50f, 0f, 50f);
        }
    }






}
