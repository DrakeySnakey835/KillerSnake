using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviourPun, IPunObservable
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    public List<Transform> bodySegments = new List<Transform>();
    public GameObject bodyPrefab;
    public int initialSize = 3;

    void Start()
    {
        bodySegments.Add(transform);

        for (int i = 0; i < initialSize; i++)
        {
            Grow();
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            Move();
            if (Input.GetAxis("Horizontal") != 0)
            {
                Rotate();
            }
        }
    }

    void Move()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -horizontal * rotationSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        for (int i = bodySegments.Count - 1; i > 0; i--)
        {
            bodySegments[i].position = bodySegments[i - 1].position;
        }
    }

    public void Grow()
    {
        GameObject newSegment = Instantiate(bodyPrefab);
        newSegment.transform.position = bodySegments[bodySegments.Count - 1].position;
        bodySegments.Add(newSegment.transform);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
