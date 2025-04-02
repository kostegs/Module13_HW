using UnityEngine;

public class Mover : MonoBehaviour
{
    public void DoMove(Rigidbody rigidbody, Vector3 direction, int speed)
    {
        if(direction != Vector3.zero)        
            rigidbody.AddForce(direction * speed, ForceMode.Acceleration);        
    }
}