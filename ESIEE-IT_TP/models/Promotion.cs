using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESIEE_IT_TP.models
{
    public class Promotion
    {
        public string Code { get; }
        public float TauxReduction { get; }

        public Promotion(string code, float taux)
        {
            Code = code;
            TauxReduction = taux;
        }

        public float appliquer(float montant)
        {
            return montant * (1 - TauxReduction);
        }
    }

}
