using UnityEngine;
using UnityEngine.UIElements;

public class GateCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var isCorrect = gameObject.GetComponentInParent<BooleanHolder>()?.value ?? false;

            if (isCorrect)
            {
                Debug.Log("Correct gate passed through.");
                GameManager.Instance.AddScore(1);
                Destroy(gameObject);


            }
            else
            {
                Debug.Log("Incorrect gate! Applying penalty");
                GameManager.Instance.ReduceHealth(50);
                Destroy(gameObject);

            }
        }

    }
}
