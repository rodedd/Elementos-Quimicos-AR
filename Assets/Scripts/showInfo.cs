using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;


public class showInfo : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;

    private bool mShowInfo = false;
    private Rect UsosEstado = new Rect(1020, 620, 230, 75);
    // private Rect InfoElemento = new Rect(20, 20, 250, 150);
    private Rect NombreElemento = new Rect(0,0, 200, 200);
    private Rect InfoElemento = new Rect(200, 0, 540, 200);
    // private Rect InfoElectrones = new Rect(1040, 40, 200, 75);
    private Rect InfoElectrones = new Rect(740, 0, 540, 200);
    private Rect Ayuda = new Rect(1200, 80, 40, 40);

    public GUIStyle MiEstilo;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            mShowInfo = true;
        }
        else
        {
            mShowInfo = false;
        }
    }

    void OnGUI()
    {


        GUIStyle EstiloBoton = new GUIStyle(GUI.skin.button);
        EstiloBoton.fontSize = 30;

        GUIStyle EstiloInfo = new GUIStyle(GUI.skin.button);
        EstiloInfo.fontSize = 20;

        GUIStyle EstiloBotonAyuda = new GUIStyle(GUI.skin.button);
        EstiloBotonAyuda.fontSize = 40;

        if (mShowInfo)
        {

            // draw the GUI button
            GUI.backgroundColor = Color.gray;
            if (GUI.Button(UsosEstado, "Usos/\nEstado Natural", EstiloBoton))
            {
                // do something on button click 
                SceneManager.LoadScene("UsosEstado");
            }

            GUI.backgroundColor = Color.black;
            GUI.Box(NombreElemento, "CALCIO", MiEstilo);

            GUI.backgroundColor = Color.black;
            GUI.Box(InfoElemento, "No. Atómico: 20 \r\n " +
                    "Símbolo: Ca \r\n" +
                    "Peso Atómico: 40.078", MiEstilo);

            GUI.backgroundColor = Color.black;
            GUI.Box(InfoElectrones, "Configuración \r\nElectrónica \r\n" +
                "2 - 8 - 8 - 2", MiEstilo);

            GUI.backgroundColor = Color.gray;
            //GUI.Button(Ayuda, "(?)", EstiloBotonAyuda);

            if (GUI.Button(Ayuda, "(?)", EstiloBotonAyuda))
            {
                // do something on button click 
                SceneManager.LoadScene("Info");
            }

        }


    }

}