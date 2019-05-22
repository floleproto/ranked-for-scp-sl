using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rank.Lib.DataBase;
using Smod2;
using Smod2.API;

namespace Ranked.Lib.Rank
{

    public partial class Rank
    {
        [JsonProperty("ranks")]
        public RankElement[] Ranks { get; set; }
    }

    public partial class RankElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("cover")]
        public bool Cover { get; set; }

        [JsonProperty("point_min")]
        public long PointMin { get; set; }

        [JsonProperty("point_max")]
        public long PointMax { get; set; }
    }

    public class RankManagement
    {
        public static Rank GetConfig()
        {
            string file = PluginManager.Manager.Server.GetAppFolder() + Path.DirectorySeparatorChar + "Ranked" + Path.DirectorySeparatorChar + "rank_config.json";
            if (File.Exists(file))
            {
                using(StreamReader sr = new StreamReader(file))
                {
                    string json = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<Rank>(json);
                }
            }
            else
            {

                string[] defaultConfig = new string[] { "{","\"ranks\": [","{","\"name\": \"Example 1\",","\"color\": \"red\",","\"cover\": true,","\"point_min\": 1,","\"point_max\": 50","},","{","\"name\": \"Example 2\",","\"color\": \"lime\",","\"cover\": false,","\"point_min\": 51,","\"point_max\": 100","}","]","}"};

                if(!Directory.Exists(PluginManager.Manager.Server.GetAppFolder() + Path.DirectorySeparatorChar + "Ranked")) { Directory.CreateDirectory(PluginManager.Manager.Server.GetAppFolder() + Path.DirectorySeparatorChar + "Ranked");  }

                using(StreamWriter sw = new StreamWriter(file))
                {
                    foreach(string txt in defaultConfig)
                    {
                        sw.WriteLine(txt);
                    }
                }

                return new Rank();
            }
        }

        public static void UpdateRank(Player p)
        {
            DBConnection db = new DBConnection(new Main());
            int point = db.GetPoint(p.SteamId);
            if(Main.rankconfigs.Ranks.Any())
            {
                foreach (RankElement rc in Main.rankconfigs.Ranks)
                {
                    if (point <= rc.PointMax && point >= rc.PointMin)
                    {
                        if (p.GetRankName() != null)
                        {
                            p.SetRank(rc.Color, rc.Name, null);
                            break;
                        }
                        else
                        {
                            if (rc.Cover == true)
                            {
                                p.SetRank(rc.Name, rc.Color, p.GetRankName());
                                break;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            
        }
    }
}
