using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace Course_kepeer_1
{
   public  class Calc_info
    {
        public List<float> get_info()
        {
            string data = string.Empty;
            string url = "http://www.nbrb.by/statistics/rates/ratesDaily.asp?fromdate=";
            DateTime today = DateTime.Now;
            data = today.Date.ToShortDateString();
            url += data;
            string pattern_usd = @"1 USD</td>
            <td class=""curCours"">
                <div>(.*?)</div></td>";
            string pattern_eur = @"1 EUR</td>
            <td class=""curCours"">
                <div>(.*?)</div></td>";
            string pattern_pol = @"10 PLN</td>
            <td class=""curCours"">
                <div>(.*?)</div></td>";
            string pattern_rub = @"100 RUB</td>
            <td class=""curCours"">
                <div>(.*?)</div></td>";
            string pattern_gbp = @"1 GBP</td>
            <td class=""curCours"">
                <div>(.*?)</div></td>";
            string pattern_uah = @"100 UAH</td>
            <td class=""curCours"">
                <div>(.*?)</div></td>";
            string pattern_bgn = @"1 BGN</td>
            <td class=""curCours"">
                <div>(.*?)</div></td>";
            WebClient wc = new WebClient();
            String Response = wc.DownloadString(url);
            string Rate_usd = Regex.Match(Response, pattern_usd).Groups[1].Value;
            string Rate_eur = Regex.Match(Response, pattern_eur).Groups[1].Value;
            string Rate_pol = Regex.Match(Response, pattern_pol).Groups[1].Value;
            string Rate_bgn = Regex.Match(Response, pattern_bgn).Groups[1].Value;
            string Rate_rub = Regex.Match(Response, pattern_rub).Groups[1].Value;
            string Rate_gbp = Regex.Match(Response, pattern_gbp).Groups[1].Value;
            string Rate_uah = Regex.Match(Response, pattern_uah).Groups[1].Value;
            Rate_eur = Rate_eur.Replace(',', '.');
            Rate_pol = Rate_pol.Replace(',', '.');
            Rate_rub = Rate_rub.Replace(',', '.');
            Rate_uah = Rate_uah.Replace(',', '.');
            Rate_gbp = Rate_gbp.Replace(',', '.');
            Rate_usd = Rate_usd.Replace(',', '.');
            Rate_bgn = Rate_bgn.Replace(',', '.');
            float usd = float.Parse(Rate_usd);
            float eur = float.Parse(Rate_eur);
            float pol = float.Parse(Rate_pol);
            float bgn = float.Parse(Rate_bgn);
            float rub = float.Parse(Rate_rub);
            float gbp = float.Parse(Rate_gbp);
            float uah = float.Parse(Rate_uah);
            List<float> countr = new List<float>();
            countr.Add(usd);
            countr.Add(eur);
            countr.Add(pol);
            countr.Add(bgn);
            countr.Add(rub);
            countr.Add(gbp);
            countr.Add(uah);
            return countr;
        }
        
    }
}
