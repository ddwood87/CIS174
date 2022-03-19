using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OlympicGames.Models;

namespace OlympicGames.Data
{
    public class OlympicSession
    {
        private const string TeamsKey = "teams";
        private const string CountKey = "teamcount";
        private const string GameKey = "game";
        private const string SportKey = "sport";
        //private string _activeGame;
        //private string _activeSport;
        private ISession _session { get; set; }
        public OlympicSession(ISession session)
        {
            _session = session;
        }
        public IEnumerable<Team> GetTeams() =>
            _session.GetObject<IEnumerable<Team>>(TeamsKey) ?? new List<Team>();

        public void SetTeams(IEnumerable<Team> teams)
        {
            _session.SetObject(TeamsKey, teams);
            _session.SetInt32(CountKey, teams.Count());
        }
        public int? GetMyTeamCount() => _session.GetInt32(CountKey);
        internal void SetActiveGame(string activeGame)
        {
            _session.SetString(GameKey, activeGame);
        }
        internal string GetActiveGame()
        {
            return _session.GetString(GameKey);
        }
        internal void SetActiveSport(string activeSport)
        {
            _session.SetString(SportKey, activeSport);
        }
        internal string GetActiveSport()
        {
            return _session.GetString(SportKey);
        }
        public void RemoveMyTeams()
        {
            _session.Remove(TeamsKey);
            _session.Remove(CountKey);
        }
    }
}
