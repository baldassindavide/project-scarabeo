using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfAppScarabeo
{
    class DatiCondivisi
    {
        int port, IP;

        Lettera[,] gameField; //matrice, campo di gioco

        List<Lettera> listLettere;
        List<Lettera> listLettereSacchetto;

        int localScore, enemyScore;
        String localNick, enemyNick;
        Boolean inGame, turno;

        public DatiCondivisi()
        {
            gameField = new Lettera[17,17];
            listLettere = new List<Lettera>();
            listLettereSacchetto = new List<Lettera>();
        }

        public Boolean isInGame()
        {
            return inGame;
        }
    }
}
