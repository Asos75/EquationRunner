using UnityEngine;

public class GateController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.back * GameManager.Instance.speed * Time.deltaTime);

        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }
}
