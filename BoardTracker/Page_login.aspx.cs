using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Page_login : System.Web.UI.Page
{
    string _user_name;
    public string UserName { get { return _user_name; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.PreviousPage != null) { }

    }

    protected void DropDownList_userName_Load(object sender, EventArgs e)
    {
        using (ManufacturingDataDataContext cx = new ManufacturingDataDataContext())
        {
            if (!IsPostBack)
            {
                DropDownList_userName.DataSource = cx.Testers.Where(d => d.Active == true);
                DropDownList_userName.DataTextField = "Name";
                DropDownList_userName.DataBind();
            }
        }
    }


    protected void Button_login_Click(object sender, EventArgs e)
    {
        string username = DropDownList_userName.Text;
        string pin_str = TextBox_pin.Text;

        using (ManufacturingDataDataContext cx = new ManufacturingDataDataContext())
        {
            var q = cx.Testers.Where(d => d.Name == username && d.Pin == null);
            if (pin_str != "")
            {
                int pin_num = Convert.ToInt32(pin_str);
                q = cx.Testers.Where(d => d.Name == username && d.Pin == pin_num);
            }

            if (q.Any())
            {
                //Session["user_name"] = username;
                //Response.Redirect("BoardEntry.aspx");
                _user_name = DropDownList_userName.Text;
                Server.Transfer("~/Page_boardEntry.aspx");
            }
            else
            {
                Label_msg.Text = "Invalid user/pin combination";
            }
        }
    }
}
