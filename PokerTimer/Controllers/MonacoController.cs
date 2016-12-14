using PokerTimer.DataAccess;
using PokerTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace PokerTimer.Controllers
{
    public class MonacoController : ApiController
    {
        [HttpGet]
        [ActionName("tournament")]
        public PokerJson GetTourInfo(long id)
        {
            var tournament = tblTournament.GetTournamentById(id);
            if (tournament == null)
            {
                return new PokerJson() { TournamentName = string.Format("Tournament #{0} does not exist", id) };
            }

            var blindlevels = tblBlindsSchedule.GetBlindsLevelByTournamentId(id);
            if (blindlevels.Count == 0)
            {
                return new PokerJson() { TournamentName = string.Format("Tournament #{0} does not have a blind schedule", id) };
            }

            var pokerJson = Utils.TimerCalculation.Run(tournament, blindlevels);
            return pokerJson;
        }        
    }
}
