using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Declara��o das vari�veis
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
        // Calcula a dist�ncia entre o target e o objeto
        distance = (Vector3.Distance(target[index].transform.position, transform.position));

        // Se a dist�ncia for maior ou igual a 1, calcula a dire��o do objeto para o target
        if (distance >= 1)
        {
            direction = target[index].transform.position - transform.position;
        }
        else
        {
            // Muda a cor do target quando a dist�ncia for menor que 1, (quando estiver perto do target)
            target[index].GetComponent<Renderer>().material.color = Color.yellow;

            // Se o index for menor que o n�mero de target, ele acrescenta 1 ao index (pr�ximo target)  
            if (index < target.Length - 1)
            {
                index++;
            }

            // Caso o contr�rio fica calculando a posi��o do �ltimo target
            else
            {
                direction = target[index].transform.position - transform.position;
            }
        }

        // Normaliza o vetor dire��o
        direction.Normalize();
    }

    // Coloca uma velocidade ao objeto em dire��o ao target
    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}