using System;                      // Importa le funzionalità per la gestione del tempo (DateTime)
using UnityEngine;                // Importa il namespace base di Unity

public class ClockScript : MonoBehaviour
{
    // Riferimenti alle lancette dell'orologio nella scena
    public Transform hourHand;    // Lancetta delle ore
    public Transform minuteHand;  // Lancetta dei minuti
    public Transform secondHand;  // Lancetta dei secondi (opzionale)

    // Se true, usa l'ora reale del sistema. Altrimenti, usa un orario fisso
    public bool useSystemTime = true;

    // Valori per l'orario fisso (usati se useSystemTime è false)
    public int fixedHour = 10;
    public int fixedMinute = 0;
    public int fixedSecond = 0;

    void Update()
    {
        DateTime time;

        // Sceglie se usare l'orario reale o quello fisso
        if (useSystemTime)
        {
            time = DateTime.Now;  // Ottiene l'ora corrente del sistema
        }
        else
        {
            // Crea un'istanza di DateTime con l'orario desiderato (solo l'ora è importante qui)
            time = new DateTime(1, 1, 1, fixedHour, fixedMinute, fixedSecond);
        }

        // Calcola l'angolo della lancetta delle ore:
        // (ora in formato 12h + frazione dei minuti) * 30 gradi (360°/12h)
        float hourAngle = (time.Hour % 12 + time.Minute / 60f) * 30f;

        // Calcola l'angolo della lancetta dei minuti:
        // (minuti + frazione dei secondi) * 6 gradi (360°/60m)
        float minuteAngle = (time.Minute + time.Second / 60f) * 6f;

        // Calcola l'angolo della lancetta dei secondi (ogni secondo = 6°)
        float secondAngle = time.Second * 6f;

        // Ruota la lancetta delle ore (in senso orario, quindi negativo)
        if (hourHand != null)
            hourHand.localRotation = Quaternion.Euler(hourAngle, 0, 0);

        // Ruota la lancetta dei minuti
        if (minuteHand != null)
            minuteHand.localRotation = Quaternion.Euler(minuteAngle, 0, 0);

        // Ruota la lancetta dei secondi (se presente)
        if (secondHand != null)
            secondHand.localRotation = Quaternion.Euler(secondAngle, 0, 0);

        /*
        // Ruota la lancetta delle ore (in senso orario, quindi negativo)
        if (hourHand != null)
            hourHand.localRotation = Quaternion.Euler(0, 0, -hourAngle);

        // Ruota la lancetta dei minuti
        if (minuteHand != null)
            minuteHand.localRotation = Quaternion.Euler(0, 0, -minuteAngle);

        // Ruota la lancetta dei secondi (se presente)
        if (secondHand != null)
            secondHand.localRotation = Quaternion.Euler(0, 0, -secondAngle);
        */
    }
}
