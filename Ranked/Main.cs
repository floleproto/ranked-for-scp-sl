using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranked.Lib.Rank;
using Smod2;
using Smod2.Attributes;

namespace Ranked
{
    [PluginDetails(author = "Flo - Fan", configPrefix = "rank", description = "A ranked plugin for SCP SL server", id = "flo.rank", langFile = "ranked", name = "Ranked", SmodMajor = 3, SmodMinor = 4, SmodRevision = 2, version = "0.0.1")]

    public class Main : Plugin
    {
        public static Rank rankconfigs;

        public override void OnDisable()
        {
            this.Info("Plugin disabled.");
        }

        public override void OnEnable()
        {
            this.Info($"Plugin enabled. Version : {this.Details.version}. Plugin created by {this.Details.author}");

            rankconfigs = RankManagement.GetConfig();
        }

        public override void Register()
        {

        // EventHandlers

            this.AddEventHandlers(new EventHandlers.PlayerEvent(this));
            this.AddEventHandlers(new EventHandlers.EnvironementEvent(this));
            this.AddEventHandlers(new EventHandlers.ServerEvent(this));

            // Config

            AddConfig(new Smod2.Config.ConfigSetting("rank_enabled", true, true, "Enable the plugin or not"));

            // SQL

            AddConfig(new Smod2.Config.ConfigSetting("rank_sql_ipaddress", "127.0.0.1", true, "Enter the IP Address of the database"));
            AddConfig(new Smod2.Config.ConfigSetting("rank_sql_username", "root", true, "Enter the username of the database"));
            AddConfig(new Smod2.Config.ConfigSetting("rank_sql_password", string.Empty, true, "Enter the password of the database"));
            AddConfig(new Smod2.Config.ConfigSetting("rank_sql_database", "scpsl", true, "Enter the name of the database"));
            AddConfig(new Smod2.Config.ConfigSetting("rank_sql_table", "rp", true, "Enter the name of the table where the data will be stored"));

            // Kills

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_kill_classd", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_kill_ci", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_kill_ntf", 3, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_kill_scient", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_kill_scp", 4, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_kill_classd", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_kill_ci", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_kill_ntf", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_kill_scient", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_kill_scp", 3, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_kill_classd", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_kill_ci", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_kill_ntf", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_kill_scient", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_kill_scp", 3, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_kill_classd", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_kill_ci", 3, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_kill_ntf", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_kill_scient", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_kill_scp", 3, true, ""));

            // Deaths

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_classd", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_ci", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_ntf", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_scient", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_scp", 0, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_tesla", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_fall", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_wall", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_decont", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_classd_death_nuke", -2, true, ""));


            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_classd", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_ci", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_ntf", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_scient", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_scp", -1, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_tesla", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_fall", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_wall", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_decont", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ci_death_nuke", -2, true, ""));


            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_classd", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_ci", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_ntf", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_scient", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_scp",-1, true, ""));


            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_tesla", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_fall", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_wall", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_decont", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_ntf_death_nuke", -2, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_classd", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_ci", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_ntf", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_scient", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_scp", -1, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_tesla", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_fall", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_wall", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_decont", -2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_scient_death_nuke", -2, true, ""));

            // Generator

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_unlock_classd", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_unlock_ci", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_unlock_ntf", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_unlock_scient", 2, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_insert_classd", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_insert_ci", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_insert_ntf", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_insert_scient", 2, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_eject_classd", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_eject_ci", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_eject_ntf", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_eject_scient", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_eject_scp", 1, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_finish_scp", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_generator_finish_ntf", 1, true, ""));

            // Win

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_mtf_mtf", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_mtf_scient", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_mtf_spectator", -2, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_scp_scp", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_scp_spectator", -2, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_scpci_scp", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_scpci_ci", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_scpci_spectator", -2, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_ci_ci", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_ci_classd", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_win_ci_spectator", -2, true, ""));

            // Nuke

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_start_classd", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_start_ci", 1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_start_ntf", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_start_scient", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_start_scp", 0, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_stop_classd", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_stop_ci", 0, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_stop_ntf", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_stop_scient", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_nuke_stop_scp", 2, true, ""));

            // Recall Zombie

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_recallzombie_049", 1, true, ""));

            // Contain 106

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_contain106_classd", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_contain106_ci", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_contain106_ntf", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_contain106_scient", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_contain106_106", -1, true, ""));

            // Lure

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_lure_classd", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_lure_ci", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_lure_ntf", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_lure_scient", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_lure_106", -1, true, ""));

            // Pocket Dimension

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_die_classd", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_die_ci", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_die_ntf", -1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_die_scient",-1, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_die_106", 1, true, ""));

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_exit_classd", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_exit_ci", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_exit_ntf", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_exit_scient", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_pd_exit_106", -1, true, ""));

            // LCZ Decontamination

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_decont_alive", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_decont_spec", 0, true, ""));

            // Escape

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_escape_classd", 2, true, ""));
            AddConfig(new Smod2.Config.ConfigSetting("rank_point_escape_scient", 2, true, ""));

            // 079

            AddConfig(new Smod2.Config.ConfigSetting("rank_point_079_levelup", 1, true, ""));


            // Commands
        }
    }
}
