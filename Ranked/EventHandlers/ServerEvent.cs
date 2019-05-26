using System.Linq;
using rank.Lib.DataBase;
using Ranked;
using Ranked.Lib.Rank;
using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

namespace EventHandlers
{
    internal class ServerEvent : IEventHandlerWaitingForPlayers, IEventHandlerRoundEnd
    {
        private Main main;

        public ServerEvent(Main main)
        {
            this.main = main;
        }

        public void OnRoundEnd(RoundEndEvent ev)
        {
            if (ConfigManager.Manager.Config.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);
                switch (ev.Status)
                {
                    case Smod2.API.ROUND_END_STATUS.CI_VICTORY:
                        foreach(Player p in PluginManager.Manager.Server.GetPlayers())
                        {
                            switch (p.TeamRole.Team)
                            {
                                case Smod2.API.Team.CLASSD:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_ci_classd"));
                                    break;

                                case Smod2.API.Team.CHAOS_INSURGENCY:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_ci_ci"));
                                    break;

                                case Smod2.API.Team.SPECTATOR:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_ci_spectator"));
                                    break;
                            }
                        }

                        return;

                    case Smod2.API.ROUND_END_STATUS.MTF_VICTORY:

                        foreach (Player p in PluginManager.Manager.Server.GetPlayers())
                        {
                            switch (p.TeamRole.Team)
                            {
                                case Smod2.API.Team.NINETAILFOX:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_mtf_mtf"));
                                    break;

                                case Smod2.API.Team.SCIENTIST:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_mtf_scient"));
                                    break;

                                case Smod2.API.Team.SPECTATOR:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_mtf_spectator"));
                                    break;
                            }
                        }

                        return;

                    case Smod2.API.ROUND_END_STATUS.SCP_CI_VICTORY:

                        foreach (Player p in PluginManager.Manager.Server.GetPlayers())
                        {
                            switch (p.TeamRole.Team)
                            {
                                case Smod2.API.Team.SCP:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_scpci_scp"));
                                    break;

                                case Smod2.API.Team.CHAOS_INSURGENCY:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_scpci_ci"));
                                    break;

                                case Smod2.API.Team.SPECTATOR:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_scpci_spectator"));
                                    break;
                            }
                        }

                        return;

                    case Smod2.API.ROUND_END_STATUS.SCP_VICTORY:

                        foreach (Player p in PluginManager.Manager.Server.GetPlayers())
                        {
                            switch (p.TeamRole.Team)
                            {
                                case Smod2.API.Team.SCP:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_scp_scp"));
                                    break;

                                case Smod2.API.Team.SPECTATOR:
                                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_win_scp_spectator"));
                                    break;
                            }
                        }

                        return;
                }
            }
        }

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {
            if (ConfigManager.Manager.Config.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);
                db.AddTable();
                Main.rankconfigs = RankManagement.GetConfig();
            }
        }
    }
}