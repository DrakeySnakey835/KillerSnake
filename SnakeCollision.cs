using Photon.Pun;
using UnityEngine;

public class SnakeCollision : MonoBehaviourPun
{
    private SnakeMovement snakeMovement;

    void Start()
    {
        snakeMovement = GetComponent<SnakeMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (photonView.IsMine && other.CompareTag("SnakeBody") && other.transform != snakeMovement.bodySegments[1])
        {
            GameManager.Instance.GameOver();
        }
    }
}
