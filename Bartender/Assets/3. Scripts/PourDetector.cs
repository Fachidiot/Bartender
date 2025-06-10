using UnityEngine;

public class PourDetector : MonoBehaviour
{
    [SerializeField] private float pourThreshold = 45;
    [SerializeField] private Transform origin;
    [SerializeField] private GameObject streamPrefab;

    private bool isPouring = false;
    private Stream currentStream;

    private void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
                StartPour();
            else
                EndPour();
        }
    }

    private void StartPour()
    {
        print("Start");

        currentStream = CreateStream();
        currentStream.Begin();
    }

    private void EndPour()
    {
        print("Stop");

        currentStream.End();
        currentStream = null;
    }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);

        return streamObject.GetComponent<Stream>();
    }
}
