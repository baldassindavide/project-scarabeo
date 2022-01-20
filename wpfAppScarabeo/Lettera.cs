using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfAppScarabeo
{
    class Lettera
    {
        string lettera;
        int score;

        public Lettera()
        {
            score = 0;
        }

        public Lettera(string lettera, int score)
        {
            this.lettera = lettera;
            this.score = score;
        }

        public string getLettera()
        {
            return lettera;
        }

        public int getScore()
        {
            return score;
        }

        public void setLettera(string lettera)
        {
            this.lettera = lettera;
        }

        public void setScore(int score)
        {
            this.score = score;
        }

        public string toString()
        {
            return lettera;
        }
    }
}
