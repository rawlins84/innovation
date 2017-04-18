using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardImporter;
using Game;

namespace CardImporterTest
{
    public class Common
    {
        public static string MessageOnFail(string failMessage, Card card)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(Common.GetCardInfo(card));
            builder.AppendLine(failMessage);
            return builder.ToString();
        }
        
        public static string GetCardInfo(Card c)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("####Card######");
            builder.AppendLine(c.Title);
            builder.AppendLine(c.Color);
            builder.AppendLine(c.Value.ToString());
            builder.AppendLine(string.Join(",", c.Icons));
            return builder.ToString();
        }
    }
}
