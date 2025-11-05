using System;
using UnityEngine;
using TMPro;


public class GateSpawner : MonoBehaviour
{

    public GameObject gatePrefab;
    public GameObject equationPrefab;

    public float spawnInterval = 12.0f;
    private float gateSpeed = 20f;
  
    public float laneXOffset = 5.0f;
    public float spawnZ = 125.0f;

    private float timer = 0f;

    private bool addSubEnabled = true;
    private bool mulDivEnabled = false;

    private PathMover pathMover;


    void Start()
    {
        timer = spawnInterval;
        addSubEnabled = PlayerPrefs.GetInt("AddSubEnabled", 1) == 1;
        mulDivEnabled = PlayerPrefs.GetInt("MulDivEnabled", 1) == 1;

        PathMover[] movers = FindObjectsByType<PathMover>(FindObjectsSortMode.None);
        foreach (PathMover mover in movers)
        {
            Transform parent = mover.transform.parent;
            if (parent != null && parent.gameObject.activeInHierarchy)
            {
                pathMover = mover;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * GameManager.Instance.speed / 20f; 
        if (timer >= spawnInterval)
        {
            var (equation, answer) = EquationGenerator.GenerateEquation(1, 10, addSubEnabled, mulDivEnabled, 1);

            timer = 0f;

            int correctGate = UnityEngine.Random.Range(0, 2);

            gateSpeed = Mathf.Min(gateSpeed + 2f, 80f);
            spawnInterval = Mathf.Min(spawnInterval + 0.02f, 20f);
            if (pathMover != null)
                pathMover.SpeedChanged(gateSpeed);
            GameManager.Instance.speed = gateSpeed;

            if (correctGate == 0)
            {
                SpawnGate(Color.blue, -laneXOffset, UnityEngine.Random.Range(1, 50).ToString(), false);
                SpawnGate(Color.red, laneXOffset, answer.ToString(), true);
            }
            else
            {
                SpawnGate(Color.blue, -laneXOffset, answer.ToString(), true);
                SpawnGate(Color.red, laneXOffset, UnityEngine.Random.Range(1, 50).ToString(), false);
            }
            SpawnEquationText(equation);
        }
    }

    void SpawnGate(Color color, float laneXOffset, string text, bool isCorrect)
    {

        Vector3 pos = new Vector3(laneXOffset, 0.5f, spawnZ);
        GameObject gate = Instantiate(gatePrefab, pos, Quaternion.identity);

        var renderer = gate.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            // Clone the material so we don�t affect other instances
            renderer.material = new Material(renderer.material);
            renderer.material.color = color;
        }

        var textMesh = gate.GetComponentInChildren<TMP_Text>();
        if (textMesh != null)
        {
            textMesh.text = text;
        }

        var booleanHolder = gate.GetComponent<BooleanHolder>();
        if (booleanHolder != null)
        {
            booleanHolder.value = isCorrect;
        }
    }

    void SpawnEquationText(string equation)
    {

        Vector3 pos = new Vector3(0, 10.0f, spawnZ);
        GameObject equationText = Instantiate(equationPrefab, pos, Quaternion.identity);

        var textMesh = equationText.GetComponentInChildren<TMP_Text>();
        if (textMesh != null)
        {
            textMesh.text = equation;
        }
    }
}
