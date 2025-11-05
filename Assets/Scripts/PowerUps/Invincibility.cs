using UnityEngine;

public class Invincibility : PowerUp
{
    public override void Activate(GameObject player)
    {
        GameManager.Instance.StartCoroutine(GameManager.Instance.InvincibilityRoutine(Duration));
    }

    void Update()
    {
        transform.Rotate(0, 60f * Time.deltaTime, 0);
        transform.Translate(Vector3.back * GameManager.Instance.speed * Time.deltaTime, Space.World);

        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Invincibility Collected");
            Activate(other.gameObject);
            Destroy(gameObject);
        }
    }
}
