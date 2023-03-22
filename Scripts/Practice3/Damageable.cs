using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> DamageGot;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Attacker>(out var attacker))
        {
            DamageGot?.Invoke(attacker.Damage);


        }
    }
}
