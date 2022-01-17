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
        List<String> ListReceivedPackets;

        int localScore, enemyScore;
        String localIp, enemyIp;
        String localNick, enemyNick;
        Boolean inGame, turno;

        public DatiCondivisi()
        {
            gameField = new Lettera[17,17];
            listLettere = new List<Lettera>();
            listLettereSacchetto = new List<Lettera>();
            ListReceivedPackets = new List<String>();
        }

        public void addToMatrice(char lettera, int xPos, int yPos)
        {
            Lettera l = new Lettera(lettera, 0);
            gameField[xPos, yPos] = l;
        }

        public Boolean isInGame()
        {
            return inGame;
        }

        public List<String> getReceivedPackets()
        {
            return ListReceivedPackets;
        }

        public void setEnemyIp(String ip)
        {
            this.enemyIp = ip;
        }

        public void setEnemyNick(String nick)
        {
            enemyNick = nick;
        }
        public void addToEnemyScore(int score)
        {
            enemyScore += score;
        }

        public void setTurno(bool turno)
        {
            this.turno = turno;
        }

        public void addToSacchetto(Lettera l)
        {
            listLettereSacchetto.Add(l);
        }
    }
}
