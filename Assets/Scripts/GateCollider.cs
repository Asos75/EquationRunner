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
                Destroy(gameObject);

                foreach (Transform child in collision.gameObject.transform)
                {
                    if (child.GetComponent<SphereCollider>() != null)
                    {
                        // Scale up by 10%
                        child.localScale *= 1.05f;
                        Debug.Log("Current scale: " + child.localScale);
                    }
                }
            }
            else
            {
                Debug.Log("Incorrect gate! Applying penalty");

                Destroy(gameObject);
                foreach (Transform child in collision.gameObject.transform)
                {
                    if (child.GetComponent<SphereCollider>() != null)
                    {
                        // Scale up by 10%
                        child.localScale -= Vector3.one * 0.33f;

                        if(child.localScale.x < 0.5f)
                        {
                            Debug.Log("Ass has shrunk too much! Game Over.");
                            Time.timeScale = 0;
                        }
                    }
                }

                
            }
        }

    }
}
