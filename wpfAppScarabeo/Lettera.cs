using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfAppScarabeo
{
    class Lettera
    {
        char lettera;
        int score;

        public Lettera()
        {
            score = 0;
        }

        public Lettera(char lettera, int score)
        {
            this.lettera = lettera;
            this.score = score;
        }

        public char getLettera()
        {
            return lettera;
        }

        public int getScore()
        {
            return score;
        }

        public void setLettera(char lettera)
        {
            this.lettera = lettera;
        }

        public void setScore(int score)
        {
            this.score = score;
        }
    }
}
