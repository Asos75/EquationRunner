using UnityEngine;

public class GateController : MonoBehaviour
{

    public float gateSpeed = 20.0f;


    void Update()
    {
        transform.Translate(Vector3.back * gateSpeed * Time.deltaTime);

        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }
}
