using UnityEngine;

namespace Runner
{
    public class Spikes : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
                player.TakeDamage();
        }
    }
}
