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
                        break;


                }
            }
        }
    }
}
