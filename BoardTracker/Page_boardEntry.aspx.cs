using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Page_boardEntry : System.Web.UI.Page
{
    string _user_name;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (PreviousPage != null)
            {
                Page_login page_login = (Page_login)PreviousPage;
                if (page_login.UserName != null)
                {
                    _user_name = page_login.UserName;
                    Label_username.Text = "You are logged in as: " + _user_name;
                    Textbox_serial.Focus();
                }
            }
            else
            {
                Server.Transfer("~/Page_login.aspx");
            }
        }
    }

    protected void Textbox_serial_TextChanged(object sender, EventArgs e)
    {
        Label1.Text = Textbox_serial.Text;
        UpdatePanel1.Update();
    }
}
