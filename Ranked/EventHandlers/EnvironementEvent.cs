using System.Linq;
using rank.Lib.DataBase;
using Ranked;
using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

namespace EventHandlers
{
    internal class EnvironementEvent : IEventHandlerLCZDecontaminate, IEventHandlerGeneratorFinish, IEventHandlerWarheadStartCountdown, IEventHandlerWarheadStopCountdown
    {
        private Main main;
        private IConfigFile cm = ConfigManager.Manager.Config;
        public EnvironementEvent(Main main)
        {
            this.main = main;
        }

        public void OnDecontaminate()
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                var alive = PluginManager.Manager.Server.GetPlayers().Where(palive => palive.TeamRole.Team != Smod2.API.Team.SPECTATOR);
                var dead = PluginManager.Manager.Server.GetPlayers().Where(palive => palive.TeamRole.Team == Smod2.API.Team.SPECTATOR);

                foreach (Player p in alive)
                {
                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_decont_alive"));
                }

                foreach (Player p in dead)
                {
                    db.AddPoint(p.SteamId, main.GetConfigInt("rank_point_decont_spec"));
                }
            }
        }

        public void OnGeneratorFinish(GeneratorFinishEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                var ntfs = PluginManager.Manager.Server.GetPlayers().Where(palive => palive.TeamRole.Team == Smod2.API.Team.NINETAILFOX || palive.TeamRole.Team == Smod2.API.Team.SCIENTIST);
                var scps = PluginManager.Manager.Server.GetPlayers().Where(palive => palive.TeamRole.Team == Smod2.API.Team.SCP);

                foreach(Player ntf in ntfs)
                {
                    db.AddPoint(ntf.SteamId, main.GetConfigInt("rank_point_generator_finish_ntf"));
                }

                foreach (Player scp in scps)
                {
                    db.AddPoint(scp.SteamId, main.GetConfigInt("rank_point_generator_finish_scp"));
                }
            }
        }

        public void OnStartCountdown(WarheadStartEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                switch (ev.Activator.TeamRole.Team)
                {
                    case Smod2.API.Team.CLASSD:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_start_classd"));
                        break;

                    case Smod2.API.Team.CHAOS_INSURGENCY:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_start_ci"));
                        break;

                    case Smod2.API.Team.NINETAILFOX:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_start_ntf"));
                        break;

                    case Smod2.API.Team.SCIENTIST:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_start_scient"));
                        break;

                    case Smod2.API.Team.SCP:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_start_scp"));
                        break;
                }
            }
        }

        public void OnStopCountdown(WarheadStopEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                switch (ev.Activator.TeamRole.Team)
                {
                    case Smod2.API.Team.CLASSD:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_stop_classd"));
                        break;

                    case Smod2.API.Team.CHAOS_INSURGENCY:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_stop_ci"));
                        break;

                    case Smod2.API.Team.NINETAILFOX:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_stop_ntf"));
                        break;

                    case Smod2.API.Team.SCIENTIST:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_stop_scient"));
                        break;

                    case Smod2.API.Team.SCP:
                        db.AddPoint(ev.Activator.SteamId, main.GetConfigInt("rank_point_nuke_stop_scp"));
                        break;
                }
            }
        }
    }
}