using rank.Lib.DataBase;
using Ranked;
using Ranked.Lib.Rank;
using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

namespace EventHandlers
{
    internal class PlayerEvent : IEventHandlerPlayerJoin, IEventHandler079LevelUp, IEventHandlerCheckEscape, IEventHandlerPocketDimensionDie, IEventHandlerPocketDimensionExit, IEventHandlerLure, IEventHandlerContain106, IEventHandlerRecallZombie, IEventHandlerPlayerDie, IEventHandlerGeneratorUnlock, IEventHandlerGeneratorInsertTablet, IEventHandlerGeneratorEjectTablet
    {
        private Main main;
        private IConfigFile cm = ConfigManager.Manager.Config;
        public PlayerEvent(Main main)
        {
            this.main = main;
        }


        public void On079LevelUp(Player079LevelUpEvent ev)
        {
            if(cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);
                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_079_levelup"));
            }
        }

        public void OnPlayerJoin(PlayerJoinEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true) || cm.GetBoolValue("rank_badge_enabled", true))
            {
                DBConnection db = new DBConnection(main);
                db.AddPlayer(ev.Player.SteamId);
                RankManagement.UpdateRank(ev.Player);
            }
        }

        public void OnCheckEscape(PlayerCheckEscapeEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                if (ev.AllowEscape)
                {
                    DBConnection db = new DBConnection(main);
                    if (ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD)
                    {
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_escape_classd"));

                    }
                    else if(ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)
                    {
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_escape_scient"));
                    }
                }
            }
        }

        public void OnPocketDimensionDie(PlayerPocketDimensionDieEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                var scps = PluginManager.Manager.Server.GetPlayers(Smod2.API.Role.SCP_106);

                foreach(Player scp in scps)
                {
                    db.AddPoint(scp.SteamId, main.GetConfigInt("rank_point_pd_die_106"));
                }

                switch (ev.Player.TeamRole.Team)
                {
                    case Smod2.API.Team.CLASSD:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_pd_die_classd"));
                        break;

                    case Smod2.API.Team.CHAOS_INSURGENCY:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_pd_die_ci"));
                        break;

                    case Smod2.API.Team.NINETAILFOX:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_pd_die_ntf"));
                        break;

                    case Smod2.API.Team.SCIENTIST:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_pd_die_scient"));
                        break;
                }
            }
        }

        public void OnPocketDimensionExit(PlayerPocketDimensionExitEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                var scps = PluginManager.Manager.Server.GetPlayers(Smod2.API.Role.SCP_106);

                foreach (Player scp in scps)
                {
                    db.AddPoint(scp.SteamId, main.GetConfigInt("rank_point_pd_exit_106"));
                }

                switch (ev.Player.TeamRole.Team)
                {
                    case Smod2.API.Team.CLASSD:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_pd_exit_classd"));
                        break;

                    case Smod2.API.Team.CHAOS_INSURGENCY:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_pd_exit_ci"));
                        break;

                    case Smod2.API.Team.NINETAILFOX:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_pd_exit_ntf"));
                        break;

                    case Smod2.API.Team.SCIENTIST:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_pd_exit_scient"));
                        break;
                }
            }
        }

        public void OnLure(PlayerLureEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                var scps = PluginManager.Manager.Server.GetPlayers(Smod2.API.Role.SCP_106);

                foreach (Player scp in scps)
                {
                    db.AddPoint(scp.SteamId, main.GetConfigInt("rank_point_lure_106"));
                }

                switch (ev.Player.TeamRole.Team)
                {
                    case Smod2.API.Team.CLASSD:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_lure_classd"));
                        break;

                    case Smod2.API.Team.CHAOS_INSURGENCY:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_lure_ci"));
                        break;

                    case Smod2.API.Team.NINETAILFOX:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_lure_ntf"));
                        break;

                    case Smod2.API.Team.SCIENTIST:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_lure_scient"));
                        break;
                }
            }
        }

        public void OnContain106(PlayerContain106Event ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                var scps = PluginManager.Manager.Server.GetPlayers(Smod2.API.Role.SCP_106);

                foreach (Player scp in scps)
                {
                    db.AddPoint(scp.SteamId, main.GetConfigInt("rank_contain106_106"));
                }

                switch (ev.Player.TeamRole.Team)
                {
                    case Smod2.API.Team.CLASSD:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_contain106_classd"));
                        break;

                    case Smod2.API.Team.CHAOS_INSURGENCY:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_contain106_ci"));
                        break;

                    case Smod2.API.Team.NINETAILFOX:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_contain106_ntf"));
                        break;

                    case Smod2.API.Team.SCIENTIST:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_contain106_scient"));
                        break;
                }
            }
        }

        public void OnRecallZombie(PlayerRecallZombieEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                if (ev.AllowRecall)
                {
                    DBConnection db = new DBConnection(main);
                    db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_recallzombie_049"));
                }
            }
        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                switch (ev.DamageTypeVar)
                {
                    case DamageType.DECONT:

                        switch (ev.Player.TeamRole.Team)
                        {
                            case Smod2.API.Team.CLASSD:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_classd_death_decont"));
                                break;

                            case Smod2.API.Team.CHAOS_INSURGENCY:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_decont"));
                                break;

                            case Smod2.API.Team.SCIENTIST:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_decont"));
                                break;

                            case Smod2.API.Team.NINETAILFOX:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_decont"));
                                break;

                            case Smod2.API.Team.SCP:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scp_death_decont"));
                                break;
                        }

                        return;

                    case DamageType.FALLDOWN:

                        switch (ev.Player.TeamRole.Team)
                        {
                            case Smod2.API.Team.CLASSD:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_classd_death_fall"));
                                break;

                            case Smod2.API.Team.CHAOS_INSURGENCY:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_fall"));
                                break;

                            case Smod2.API.Team.SCIENTIST:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_fall"));
                                break;

                            case Smod2.API.Team.NINETAILFOX:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_fall"));
                                break;

                            case Smod2.API.Team.SCP:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scp_death_fall"));
                                break;
                        }

                        return;

                    case DamageType.NUKE:

                        switch (ev.Player.TeamRole.Team)
                        {
                            case Smod2.API.Team.CLASSD:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_classd_death_nuke"));
                                break;

                            case Smod2.API.Team.CHAOS_INSURGENCY:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_nuke"));
                                break;

                            case Smod2.API.Team.SCIENTIST:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_nuke"));
                                break;

                            case Smod2.API.Team.NINETAILFOX:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_nuke"));
                                break;

                            case Smod2.API.Team.SCP:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scp_death_nuke"));
                                break;
                        }

                        return;

                    case DamageType.TESLA:
                        switch (ev.Player.TeamRole.Team)
                        {
                            case Smod2.API.Team.CLASSD:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_classd_death_tesla"));
                                break;

                            case Smod2.API.Team.CHAOS_INSURGENCY:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_tesla"));
                                break;

                            case Smod2.API.Team.SCIENTIST:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_tesla"));
                                break;

                            case Smod2.API.Team.NINETAILFOX:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_tesla"));
                                break;

                            case Smod2.API.Team.SCP:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scp_death_tesla"));
                                break;
                        }
                        return;

                    case DamageType.WALL:
                        switch (ev.Player.TeamRole.Team)
                        {
                            case Smod2.API.Team.CLASSD:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_classd_death_wall"));
                                break;

                            case Smod2.API.Team.CHAOS_INSURGENCY:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_wall"));
                                break;

                            case Smod2.API.Team.SCIENTIST:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_wall"));
                                break;

                            case Smod2.API.Team.NINETAILFOX:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_wall"));
                                break;

                            case Smod2.API.Team.SCP:
                                db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scp_death_wall"));
                                break;
                        }
                        return;

                }

                if (ev.Killer.TeamRole.Team == Smod2.API.Team.CLASSD)
                {
                    switch (ev.Player.TeamRole.Team)
                    {
                        case Smod2.API.Team.CLASSD:
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_classd_death_classd"));
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_classd_kill_classd"));
                            break;

                        case Smod2.API.Team.CHAOS_INSURGENCY:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_classd_kill_ci"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_classd"));
                            break;

                        case Smod2.API.Team.SCIENTIST:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_classd_kill_scient"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_classd"));
                            break;

                        case Smod2.API.Team.NINETAILFOX:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_classd_kill_ntf"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_classd"));
                            break;

                        case Smod2.API.Team.SCP:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_classd_kill_scp"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scp_death_classd"));
                            break;
                    }

                    return;

                }
                else if (ev.Killer.TeamRole.Team == Smod2.API.Team.CHAOS_INSURGENCY)
                {
                    switch (ev.Player.TeamRole.Team)
                    {
                        case Smod2.API.Team.CLASSD:
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_classd"));
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_classd_kill_ci"));
                            break;

                        case Smod2.API.Team.CHAOS_INSURGENCY:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_ci_kill_ci"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_ci"));
                            break;

                        case Smod2.API.Team.SCIENTIST:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_ci_kill_scient"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_ci"));
                            break;

                        case Smod2.API.Team.NINETAILFOX:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_ci_kill_ntf"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_ci"));
                            break;

                        case Smod2.API.Team.SCP:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_ci_kill_scp"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scp_death_ci"));
                            break;
                    }

                    return;
                }
                else if (ev.Killer.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                {
                    switch (ev.Player.TeamRole.Team)
                    {
                        case Smod2.API.Team.CLASSD:
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_classd_death_ntf"));
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_ntf_kill_classd"));
                            break;

                        case Smod2.API.Team.CHAOS_INSURGENCY:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_ntf_kill_ci"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_ntf"));
                            break;

                        case Smod2.API.Team.SCIENTIST:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_ntf_kill_scient"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_ntf"));
                            break;

                        case Smod2.API.Team.NINETAILFOX:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_ntf_kill_ntf"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_ntf"));
                            break;

                        case Smod2.API.Team.SCP:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_ntf_kill_scp"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scp_death_ntf"));
                            break;
                    }
                    return;
                }
                else if (ev.Killer.TeamRole.Team == Smod2.API.Team.SCIENTIST)
                {
                    switch (ev.Player.TeamRole.Team)
                    {
                        case Smod2.API.Team.CLASSD:
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_classd_death_scient"));
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_scient_kill_classd"));
                            break;

                        case Smod2.API.Team.CHAOS_INSURGENCY:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_scient_kill_ci"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_scient"));
                            break;

                        case Smod2.API.Team.SCIENTIST:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_scient_kill_scient"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_scient"));
                            break;

                        case Smod2.API.Team.NINETAILFOX:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_scient_kill_ntf"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_scient"));
                            break;

                        case Smod2.API.Team.SCP:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_scient_kill_scp"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scp_death_scient"));
                            break;
                    }
                    return;
                }
                else if (ev.Killer.TeamRole.Team == Smod2.API.Team.SCP)
                {
                    switch (ev.Player.TeamRole.Team)
                    {
                        case Smod2.API.Team.CLASSD:
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_classd_death_scp"));
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_scp_kill_classd"));
                            break;

                        case Smod2.API.Team.CHAOS_INSURGENCY:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_scp_kill_ci"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ci_death_scp"));
                            break;

                        case Smod2.API.Team.SCIENTIST:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_scp_kill_scient"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_scient_death_scp"));
                            break;

                        case Smod2.API.Team.NINETAILFOX:
                            db.AddPoint(ev.Killer.SteamId, main.GetConfigInt("rank_point_scp_kill_ntf"));
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_ntf_death_scp"));
                            break;
                    }
                    return;
                }
            }
        }

        public void OnGeneratorUnlock(PlayerGeneratorUnlockEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                switch (ev.Player.TeamRole.Team)
                {
                    case Smod2.API.Team.CLASSD:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_unlock_classd"));
                        break;

                    case Smod2.API.Team.CHAOS_INSURGENCY:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_unlock_ci"));
                        break;

                    case Smod2.API.Team.NINETAILFOX:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_unlock_ntf"));
                        break;

                    case Smod2.API.Team.SCIENTIST:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_unlock_scient"));
                        break;
                }
            }
        }

        public void OnGeneratorInsertTablet(PlayerGeneratorInsertTabletEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                DBConnection db = new DBConnection(main);

                switch (ev.Player.TeamRole.Team)
                {
                    case Smod2.API.Team.CLASSD:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_insert_classd"));
                        break;

                    case Smod2.API.Team.CHAOS_INSURGENCY:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_insert_ci"));
                        break;

                    case Smod2.API.Team.NINETAILFOX:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_insert_ntf"));
                        break;

                    case Smod2.API.Team.SCIENTIST:
                        db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_insert_scient"));
                        break;
                }
            }
        }

        public void OnGeneratorEjectTablet(PlayerGeneratorEjectTabletEvent ev)
        {
            if (cm.GetBoolValue("rank_enabled", true))
            {
                if (ev.Allow)
                {
                    DBConnection db = new DBConnection(main);

                    switch (ev.Player.TeamRole.Team)
                    {
                        case Smod2.API.Team.CLASSD:
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_eject_classd"));
                            break;

                        case Smod2.API.Team.CHAOS_INSURGENCY:
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_eject_ci"));
                            break;

                        case Smod2.API.Team.NINETAILFOX:
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_eject_ntf"));
                            break;

                        case Smod2.API.Team.SCIENTIST:
                            db.AddPoint(ev.Player.SteamId, main.GetConfigInt("rank_point_generator_eject_scient"));
                            break;
                    }
                }
            }
        }
    }
}