using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Declaração das variáveis
    public GameObject[] target;
    Rigidbody rb;

    int index = 0;
    float speed = 5;
    float distance;
    Vector3 direction;

    // Pega o component RigidBody
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Calcula a distância entre o target e o objeto
        distance = (Vector3.Distance(target[index].transform.position, transform.position));

        // Se a distância for maior ou igual a 1, calcula a direção do objeto para o target
        if (distance >= 1)
        {
            direction = target[index].transform.position - transform.position;
        }
        else
        {
            // Muda a cor do target quando a distância for menor que 1, (quando estiver perto do target)
            target[index].GetComponent<Renderer>().material.color = Color.yellow;

            // Se o index for menor que o número de target, ele acrescenta 1 ao index (próximo target)  
            if (index < target.Length - 1)
            {
                index++;
            }

            // Caso o contrário fica calculando a posição do último target
            else
            {
                direction = target[index].transform.position - transform.position;
            }
        }

        // Normaliza o vetor direção
        direction.Normalize();
    }

    // Coloca uma velocidade ao objeto em direção ao target
    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}