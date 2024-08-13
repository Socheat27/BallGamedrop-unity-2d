using UnityEngine;
using static Music;

public class MoveBall : MonoBehaviour
{
    public Transform[] targetPositions; 
    private float speed = 1000f; 
    public void MoveToObjectPosition(int roadIndex)
    {
        if (targetPositions != null && roadIndex >= 0 && roadIndex < targetPositions.Length)
        {
            Vector3 targetPosition = targetPositions[roadIndex].position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            music.Musics[1].Play();
        }
        else
        {
            Debug.LogError("Invalid target positions or road index!");
        }
    }
}
