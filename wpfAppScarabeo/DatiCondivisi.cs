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
            listLettereSacchetto = new List<Lettera>
            {
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),        
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("a",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("e",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("i",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("o",1),
                new Lettera("u",1),
                new Lettera("u",1),
                new Lettera("u",1),
                new Lettera("u",1),
                new Lettera("b",1),
                new Lettera("b",1),
                new Lettera("b",1),
                new Lettera("b",1),
                new Lettera("b",1),
                new Lettera("b",1),
                new Lettera("c",1),
                new Lettera("c",1),
                new Lettera("c",1),
                new Lettera("c",1),
                new Lettera("c",1),
                new Lettera("c",1),
                new Lettera("d",1),
                new Lettera("d",1),
                new Lettera("d",1),
                new Lettera("d",1),
                new Lettera("d",1),
                new Lettera("d",1),
                new Lettera("f",1),
                new Lettera("f",1),
                new Lettera("f",1),
                new Lettera("f",1),
                new Lettera("f",1),
                new Lettera("g",1),
                new Lettera("g",1),
                new Lettera("g",1),
                new Lettera("g",1),
                new Lettera("g",1),
                new Lettera("h",1),
                new Lettera("h",1),
                new Lettera("h",1),
                new Lettera("h",1),
                new Lettera("h",1),
                new Lettera("l",1),
                new Lettera("l",1),
                new Lettera("l",1),
                new Lettera("l",1),
                new Lettera("l",1),
                new Lettera("l",1),
                new Lettera("m",1),
                new Lettera("m",1),
                new Lettera("m",1),
                new Lettera("m",1),
                new Lettera("m",1),
                new Lettera("m",1),
                new Lettera("n",1),
                new Lettera("n",1),
                new Lettera("n",1),
                new Lettera("n",1),
                new Lettera("n",1),
                new Lettera("n",1),
                new Lettera("p",1),
                new Lettera("p",1),
                new Lettera("p",1),
                new Lettera("p",1),
                new Lettera("p",1),
                new Lettera("q",1),
                new Lettera("q",1),
                new Lettera("q",1),
                new Lettera("q",1),
                new Lettera("q",1),
                new Lettera("r",1),
                new Lettera("r",1),
                new Lettera("r",1),
                new Lettera("r",1),
                new Lettera("r",1),
                new Lettera("r",1),
                new Lettera("s",1),
                new Lettera("s",1),
                new Lettera("s",1),
                new Lettera("s",1),
                new Lettera("s",1),
                new Lettera("s",1),
                new Lettera("t",1),
                new Lettera("t",1),
                new Lettera("t",1),
                new Lettera("t",1),
                new Lettera("t",1),
                new Lettera("v",1),
                new Lettera("v",1),
                new Lettera("v",1),
                new Lettera("v",1),
                new Lettera("v",1),
                new Lettera("v",1),
                new Lettera("z",1),
                new Lettera("z",1),
                new Lettera("z",1),
                new Lettera("z",1),
                new Lettera("z",1),
            }; // riempito tutto con le lettere disponibili
            ListReceivedPackets = new List<String>();
        }

        public void addToMatrice(char lettera, int xPos, int yPos)
        {
            Lettera l = new Lettera(lettera.ToString(), 0);
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

        public List<Lettera> getListLettereSacchetto()
        {
            return listLettereSacchetto;
        }

        public void removeLetteraFromSacchetto(Lettera l)
        {
            listLettereSacchetto.Remove(l);
        }
    }
}
