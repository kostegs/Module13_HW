using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private ParticleSystem _effect;

    private void Update()
        => transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _effect.transform.position = transform.position;
            _effect.Play();
            this.gameObject.SetActive(false);
        }       
    }
}
