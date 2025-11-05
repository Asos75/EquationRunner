using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public float Duration = 8.0f;

    public abstract void Activate(GameObject player);
}
