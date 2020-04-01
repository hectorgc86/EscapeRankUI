using System;

namespace EscapeRankUI.Modelos
{
    public class EscapeItemPair:Tuple<Sala, Sala>
    {
        public EscapeItemPair(Sala item1, Sala item2) : base(item1, item2 ?? CreateEmptyModel()) { }

        private static Sala CreateEmptyModel()
        {
            return new Sala { EsVisible = false };
        }

    }
   

}


