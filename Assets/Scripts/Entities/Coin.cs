using UnityEngine;

namespace Runner.Entity
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                GameModel.Instance.AddCoin();
                gameObject.SetActive(false);
            }
        }
    }
}
