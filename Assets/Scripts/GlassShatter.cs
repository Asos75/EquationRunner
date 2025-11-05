using UnityEngine;

public class GlassClickShatter : MonoBehaviour
{
    [Header("References")]
    public GameObject wholeGlass;     // Unbroken glass
    public GameObject[] shards;       // Array of individual shard GameObjects

    [Header("Shatter Settings")]
    public float explosionForce = 300f;
    public float explosionRadius = 2f;
    public float upwardsModifier = 0.2f;
    public float shardLifetime = 10f;

    private bool shattered = false;

    void Start()
    {
        // make sure only the whole glass is visible at the start
        if (wholeGlass != null) wholeGlass.SetActive(true);
        foreach (var s in shards)
            if (s != null) s.SetActive(false);
    }

    void OnMouseDown()
    {
        if (shattered) return;
        shattered = true;
        Shatter();
    }

    void Shatter()
    {
        // hide the whole glass
        if (wholeGlass != null)
            wholeGlass.SetActive(false);

        // activate and explode each shard
        foreach (var shard in shards)
        {
            if (shard == null) continue;

            shard.SetActive(true);

            Rigidbody rb = shard.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(
                    explosionForce,
                    transform.position,
                    explosionRadius,
                    upwardsModifier,
                    ForceMode.Impulse
                );
            }

            // optional: destroy shards after a while
            Destroy(shard, shardLifetime);
        }
    }
}
