using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PokerTimer.Models;
using System.Collections.Specialized;
using System.Globalization;
using PokerTimer.DataAccess;

namespace PokerTimer
{
    public partial class AddTournament : System.Web.UI.Page
    {
        private string tournamentName = string.Empty;
        private int startingChips = 0;
        private int rebuy = 0;
        private int addon = 0;
        private DateTime startingTime;
        private int totalOfLevels = 0;
        private int levelTimeLength = 0;
        private int breakAfterLevel = 0;
        private int breakTime = 0;

        private bool GetInt(string key, NameValueCollection form, ref int result)
        {
            try
            {
                string value = form[key].Trim();
                result =  int.Parse(value);
                return true;
            }
            catch { }
            return false;
        }

        private bool GetString(string key, NameValueCollection form, ref string result)
        {
            try
            {
                result = form[key].Trim();
                return true;
            }
            catch { }
            return false;
        }

        private bool GetDateTime(string key, NameValueCollection form, ref DateTime dt)
        {
            try
            {
                string dateStr = form[key].Trim();
                dt = DateTime.ParseExact(dateStr, "dd/MM/yyyy - HH:mm", CultureInfo.InvariantCulture);
                return true;
            }
            catch { }
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTotalOfLevels.Attributes.Add("onchange", "validateTotalOfLevels()");
                txtStartingTime.Attributes.Add("placeholder", "dd/MM/yyyy - HH:mm");
            }
            else
            {
                string errorMsg = string.Empty;
                List<BlindsLevel> levels = new List<BlindsLevel>();
                NameValueCollection form = Request.Form;
                if (!GetString("txtName", form, ref tournamentName)) errorMsg = "Tên tournament không được rỗng";
                if (!GetInt("txtStartingChips", form, ref startingChips)) errorMsg = "Starting Chips rỗng hoặc không phải là số";
                if (!GetInt("txtRebuy", form, ref rebuy)) errorMsg = "Rebuy rỗng hoặc không phải là số";
                if (!GetInt("txtAddon", form, ref addon)) errorMsg = "Addon rỗng hoặc không phải là số";
                if (!GetDateTime("txtStartingTime", form, ref startingTime))
                {
                    errorMsg = "StartingTime rỗng hoặc không đúng định dạng";
                }
                if (!GetInt("txtTotalOfLevels", form, ref totalOfLevels)) errorMsg = "Total of levels rỗng hoặc không phải là số";
                if (!GetInt("txtLevelTimeLength", form, ref levelTimeLength)) errorMsg = "Level time length rỗng hoặc không phải là số";
                if (!GetInt("txtBreakLevelRange", form, ref breakAfterLevel)) errorMsg = "Break after level rỗng hoặc không phải là số";
                if (!GetInt("txtBreakTime", form, ref breakTime)) errorMsg = "BreakTime rỗng hoặc không phải là số";
                BlindData[] datas = new BlindData[totalOfLevels];
                for (int i = 0; i < totalOfLevels; i++)
                {
                    datas[i] = new BlindData();
                    int small = -1, big = -1, ante = -1;
                    if (!GetInt("small_" + i.ToString(), form, ref small)) errorMsg = string.Format("Tham số Small (Level {0}) rỗng hoặc không phải là số", i + 1);
                    if (!GetInt("big_" + i.ToString(), form, ref big)) errorMsg = string.Format("Tham số Big (Level {0}) rỗng hoặc không phải là số", i + 1);
                    if (!GetInt("ante_" + i.ToString(), form, ref ante)) errorMsg = string.Format("Tham số Ante (Level {0}) rỗng hoặc không phải là số", i + 1);
                    datas[i].Small = small; datas[i].Big = big; datas[i].Ante = ante;
                }
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    string cRefreshParent = "<script language='javascript'>" +
                                        "  alert('" + errorMsg + "');</script>";
                    string cRefreshParentKey = "RefreshParentKey";
                    if (!this.Page.ClientScript.IsClientScriptBlockRegistered(cRefreshParentKey))
                    {
                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                        cRefreshParentKey, cRefreshParent);
                    }
                    return;
                }
                else
                {
                    Tournament tour = new Tournament();
                    tour.Id = -1;
                    tour.Name = tournamentName;
                    tour.StartingChips = startingChips;
                    tour.Rebuy = rebuy;
                    tour.Addon = addon;
                    tour.StartingTime = startingTime;
                    tour.IsStopped = false;
                    tour.LastStage = 0;
                    tour.LastStageTime = 0;
                    tour.PrizePool = 0;
                    tour.TotalPlayers = 0;
                    tour.UpdateTime = DateTime.Now;
                    int tourId = tblTournament.Add(tour);

                    if (totalOfLevels > 0)
                    {
                        BlindsLevel level = new BlindsLevel();
                        level.Stage = 0; level.Ante = 0; level.BigBlind = 0; level.SmallBlind = 0;
                        level.TournamentId = tour.Id;
                        int currentStage = 0;
                        for (int i = 1; i <= totalOfLevels; i++)
                        {

                        }
                    }
                }
            }
        }
    }

    internal class BlindData
    {
        public int Small { get; set; }
        public int Big { get; set; }
        public int Ante { get; set; }
    }

}