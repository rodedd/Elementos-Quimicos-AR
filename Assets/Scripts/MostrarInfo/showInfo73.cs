using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;


public class showInfo73 : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;

    private bool mShowInfo = false;
    //private Rect UsosEstado = new Rect(1020, 620, 230, 75);
    // private Rect InfoElemento = new Rect(20, 20, 250, 200);

    private Rect InfoElemento = new Rect(0, 0, 410, 180);
    private Rect InfoElectrones = new Rect(410, 0, 410, 180);
    private Rect NombreElemento = new Rect(820, 0, 204, 180);

    private Rect Ayuda = new Rect(857, 35, 130, 35);
    private Rect UsosEstado = new Rect(837, 90, 170, 60);

    private Rect Salir = new Rect(900, 710, 100, 35);

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

        MiEstilo.fontSize = 26;
        MiEstilo.normal.textColor = Color.white;

        GUIStyle EstiloBoton = new GUIStyle(GUI.skin.button);
        EstiloBoton.fontSize = 30;

        //GUIStyle EstiloInfo = new GUIStyle(GUI.skin.button);
        //EstiloInfo.fontSize = 20;

        GUIStyle EstiloBotonAyuda = new GUIStyle(GUI.skin.button);
        EstiloBotonAyuda.fontSize = 16;

        GUIStyle EstiloBotonSalir = new GUIStyle(GUI.skin.button);
        EstiloBotonAyuda.fontSize = 16;

        if (mShowInfo)
        {

            // draw the GUI button
            //GUI.backgroundColor = Color.gray;
            /* if (GUI.Button(UsosEstado, "Usos/\nEstado Natural", EstiloBoton))
            {
                // do something on button click 
                SceneManager.LoadScene("UsosEstado");
            } */



            GUI.backgroundColor = Color.black;
            GUI.Box(InfoElemento, "TANTALIO \r\n\r\n" +
                    "Símbolo: Ta \r\n" +
                    "Número Atómico: 73 \r\n" +
                    "Peso Atómico: 180.95", MiEstilo);

            GUI.backgroundColor = Color.black;
            GUI.Box(InfoElectrones, "Configuración \r\nElectrónica: \r\n" +
                "[Xe] 4f\u00b9\u2074 5d\u00b3 6s\u00b2", MiEstilo);

            GUI.backgroundColor = Color.black;
            GUI.Box(NombreElemento, "", MiEstilo);


            GUI.backgroundColor = Color.white;
            if (GUI.Button(Ayuda, "¿Qué es esto?", EstiloBotonAyuda))
            {
                // do something on button click 
                SceneManager.LoadScene("Info");
            }

            GUI.backgroundColor = Color.white;
            if (GUI.Button(UsosEstado, "Usos //\r\n" +
                "Estado Natural", EstiloBotonAyuda))
            {
                // do something on button click 
                SceneManager.LoadScene("73_Tantalo");
            }

            GUI.backgroundColor = Color.red;
            if (GUI.Button(Salir, "SALIR", EstiloBotonSalir))
            {
                Application.Quit();
            }

        }


    }

}