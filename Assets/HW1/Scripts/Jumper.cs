using UnityEngine;

public class Jumper : MonoBehaviour
{
    public void DoJump(Rigidbody rigidbody, Vector3 jumpVector, int jumpPower)
    {
        if(jumpVector != Vector3.zero)
            rigidbody.AddForce(jumpVector * jumpPower, ForceMode.Impulse);
    }
}
