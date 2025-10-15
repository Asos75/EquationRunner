using UnityEngine;

public class GateFrameColision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected on Gate Frame.");
            Time.timeScale = 0;
        }

    }

}
