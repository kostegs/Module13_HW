using UnityEngine;

public class VectorCalculations : MonoBehaviour
{
    public Vector3 CalculateMovingVector(float sideDirection, float forwardDirection)
    {
        Vector3 sideVector = new Vector3(sideDirection, 0, 0);
        Vector3 forwardVector = new Vector3(0, 0, forwardDirection);

        return sideVector + forwardVector;
    }
}
