using PokerTimer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerTimer
{
    public partial class Monaco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            var listTour = tblTournament.GetAllTournament();
            string html = string.Empty;            

            for (int i = 0; i < listTour.Count; i++)
            {
                string divLine = string.Format("<div class='tourline'><a href=\"timer.aspx?id={0}\">{1}</a></div>", listTour[i].Id, listTour[i].Name + " @ " + listTour[i].StartingTime.ToString("HH:mm"));
                html += divLine;
            }

            if (listTour.Count == 0)
            {
                html = string.Format("<div class='tourline'>There is no tournament.</div>");
            }

            menu.InnerHtml = html;
        }
    }
}