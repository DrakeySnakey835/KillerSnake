using UnityEngine;

public class Food : MonoBehaviour
{
    public int tokenValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SnakeMovement>().Grow();
            CurrencyManager.Instance.AddTokens(tokenValue);
            Destroy(gameObject);
        }
    }
}
