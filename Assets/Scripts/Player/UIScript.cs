using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour
{

    [Header("Face Images")]
    public Sprite centerFace;
    public Sprite leftFace;
    public Sprite rightFace;

    [Header("UI Elements")]
    public Image faceImage;

    [Header("Animation Settings")]
    public float centerTime = 2f;
    public float sideTime = 1f;

    private enum FaceState { Center, Left, Right }
    private FaceState currentState = FaceState.Center;
    private float stateTimer = 0f;
    void Start()
    {
        // Start the face animation cycle
        StartCoroutine(FaceAnimationCycle());
    }

    IEnumerator FaceAnimationCycle()
    {
        while (true)
        {
            // Center state
            currentState = FaceState.Center;
            faceImage.sprite = centerFace;
            stateTimer = centerTime;
            while (stateTimer > 0)
            {
                stateTimer -= Time.deltaTime;
                yield return null;
            }

            // Left state
            currentState = FaceState.Left;
            faceImage.sprite = leftFace;
            stateTimer = sideTime;
            while (stateTimer > 0)
            {
                stateTimer -= Time.deltaTime;
                yield return null;
            }

            // Center state again
            currentState = FaceState.Center;
            faceImage.sprite = centerFace;
            stateTimer = centerTime;
            while (stateTimer > 0)
            {
                stateTimer -= Time.deltaTime;
                yield return null;
            }

            // Right state
            currentState = FaceState.Right;
            faceImage.sprite = rightFace;
            stateTimer = sideTime;
            while (stateTimer > 0)
            {
                stateTimer -= Time.deltaTime;
                yield return null;
            }
        }
    }
}
