using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
        => transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);

    private void OnTriggerEnter(Collider other)
        => this.gameObject.SetActive(false); 
}
