using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoEspera : InstruccionesFSM
{

    public override void Start(TorretaEstatica torreta)
    {
        //inicia el estado de espera
        Debug.Log("Inicio Estado de espera!");
    }


    public override void UpdateState(TorretaEstatica torreta)
    {
        //ejecución del estado de espera
    }
}
