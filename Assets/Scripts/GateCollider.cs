using UnityEngine;
using UnityEngine.UIElements;

public class GateCollider : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public bool once = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && once)
        {
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;
            var isCorrect = gameObject.GetComponentInParent<BooleanHolder>()?.value ?? false;

            if (isCorrect)
            {
                Debug.Log("Correct gate passed through.");

                em.enabled = true;
                collisionParticleSystem.Play();

                GameManager.Instance.AddScore(1);
                once = false;
                Invoke(nameof(DestroyObject), dur - 2.85f);
            }
            else
            {
                Debug.Log("Incorrect gate! Applying penalty");
                GameManager.Instance.ReduceHealth(50);
                Destroy(gameObject);

            }
        }

    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
