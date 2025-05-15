using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public Transform player;
    public int maxApples = 15;
    public float spawnRadius = 20f;
    public float minDistanceFromPlayer = 5f;
    public float minDistanceBetweenApples = 3f;

    private void Start()
    {
        GenerateApples();
    }

    // Función que usa LINQ (Where del Grupo 1) + Generator (Range)
    public void GenerateApples()
    {
        // GENERATOR: Crear posiciones candidatas usando Enumerable.Range
        var positions = Enumerable.Range(0, maxApples * 3) // Genera 3 veces más posiciones de las necesarias
            .Select(_ => Random.insideUnitSphere * spawnRadius + transform.position)
            .Where(pos => pos.y > 0.5f) // Asegurar que no estén bajo tierra

            // LINQ Grupo 1: Where para filtrar posiciones seguras
            .Where(pos => Vector3.Distance(pos, player.position) > minDistanceFromPlayer)

            // LINQ Grupo 1: Take para limitar la cantidad
            .Take(maxApples)

            // Eliminar posiciones muy cercanas entre sí
            .Aggregate(new List<Vector3>(), (list, pos) => {
                if (!list.Any() || list.All(existingPos => Vector3.Distance(existingPos, pos) > minDistanceBetweenApples))
                {
                    list.Add(pos);
                }
                return list;
            });

        foreach (var pos in positions)
        {
            Instantiate(applePrefab, pos, Quaternion.identity);
        }
    }
}
