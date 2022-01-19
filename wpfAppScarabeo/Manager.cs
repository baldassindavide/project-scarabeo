using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace wpfAppScarabeo
{
    class Manager
    {
        private DatiCondivisi dati;

        public Manager()
        {
            dati = new DatiCondivisi();
        }
        public Manager(DatiCondivisi dati)
        {
            this.dati = dati;
        }

        public void managerActions()
        {
            int counter = 0; // tiene conto dei pacchetti da leggere
            while(dati.isInGame())
            {
                int size = dati.getReceivedPackets().Count;
                String pacchetto = dati.getReceivedPackets()[counter];
                String[] campi = pacchetto.Split(';');

                switch (campi[0])
                {
                    case "C":
                        dati.setEnemyIp(campi[1]);
                        dati.setEnemyNick(campi[2]);
                        break;

                    case "P":
                        dati.setTurno(true); // passa turno al nemico
                        dati.addToEnemyScore(int.Parse(campi[campi.Length-1]));
                        break;
                    case "LIN":
                        for (int i = 1; i < campi.Length; i++)
                        {
                            Lettera l = new Lettera(campi[i][0].ToString(),10);
                            dati.addToSacchetto(l);
                        }
                        break;
                    case "LOUT":
                        for (int i = 1; i < campi.Length; i++)
                            MessageBox.Show("");
                        break;
                }
                counter++;
            }
        }
    }
}
