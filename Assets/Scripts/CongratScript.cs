using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    public GameObject parent;

    [SerializeField]
    private List<string> TextToDisplay = new();

    [SerializeField]
    private float RotatingSpeed = 15f;

    private int CurrentText = 0;

    private float TimeToNextText = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = TextToDisplay[0];

        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        parent.transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime);
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;

            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }
            Text.text = TextToDisplay[CurrentText];
        }
    }
}