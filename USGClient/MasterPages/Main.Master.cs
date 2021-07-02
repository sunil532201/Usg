using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.MasterPages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkDefaultCSS.Href = ConfigurationManager.AppSettings["BaseURL"] + "Resources/Shared/stylesheets/dnndefault/7.0.0/default.css?cdv=347";
            lnkSearchSkinObjectPreviewCSS.Href = ConfigurationManager.AppSettings["BaseURL"] + "Resources/Search/SearchSkinObjectPreview.css?cdv=347";
            lnkPortalCSS.Href = ConfigurationManager.AppSettings["BaseURL"] + "Portals/[USG]/portal.css?cdv=347";
            lnkBaseCSS.Href = ConfigurationManager.AppSettings["BaseURL"] + "Portals/_default/skins/porto/USGInner.base.css?cdv=347";
            lnkThemeCSS.Href = ConfigurationManager.AppSettings["BaseURL"] + "Portals/_default/skins/porto/USGInner.theme.css?cdv=347";
            lnkFavicon.Href = ConfigurationManager.AppSettings["BaseURL"] + "Portals/[USG]/favicon.ico?ver=2017-10-05-223419-567";

            lnkLogout.Visible = Context.User.Identity.IsAuthenticated;
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}