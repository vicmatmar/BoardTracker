using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using CentraliteDataUtils;

public partial class Page_boardEntry : System.Web.UI.Page
{
    static string _user_name;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataUtils.DBConnStr = "Data Source=rs01;Initial Catalog=ManufacturingStore_RAD;Integrated Security=True";

            // Check to see if it came from login page
            if (PreviousPage != null)
            {
                Page_login page_login = (Page_login)PreviousPage;
                if (page_login.UserName != null)
                {
                    _user_name = page_login.UserName;
                }
            }
            else
            {
                Server.Transfer("~/Page_login.aspx");
            }
            Textbox_serial.Focus();
        }
        else
        {
        }

    }

    protected void Textbox_serial_TextChanged(object sender, EventArgs e)
    {

        string serial_str = Textbox_serial.Text;
        DataTable t = new DataTable("Serial Info");
        try
        {
            BoardSerialNumber.Serial_Parts serial_parts = BoardSerialNumber.Parse(serial_str);

            t.Columns.Add(new DataColumn());
            t.Columns.Add(new DataColumn());

            DataRow r = t.NewRow();
            r[0] = "Serial";
            r[1] = serial_str;
            t.Rows.Add(r);

            r = t.NewRow();
            r[0] = "Operator";
            r[1] = _user_name;
            t.Rows.Add(r);

            CentraliteDataContext cx = DataUtils.DataContext;
            r = t.NewRow();
            r[0] = "Product";
            r[1] = String.Format(
                "ID = {0}, Description = {1}",
                serial_parts.Product_ID.ToString(),
                cx.Products.Where(d => d.Id == serial_parts.Product_ID).Select(d => d.Description).Single());
            t.Rows.Add(r);
            cx.Dispose();

            r = t.NewRow();
            r[0] = "Created";
            r[1] = string.Format(
                "Week = {0}, Year = {1}",
                serial_parts.Week_Year.Week.ToString(),
                serial_parts.Week_Year.Year.ToString());
            t.Rows.Add(r);

            r = t.NewRow();
            r[0] = "Number";
            r[1] = serial_parts.Number;
            t.Rows.Add(r);

            Textbox_serial.Text = "";

            using (CentraliteDataContext dc = DataUtils.DataContext)
            {
                IQueryable<BoardTracker> btracker =  dc.BoardTrackers.Where(c =>
                c.ProductId == serial_parts.Product_ID &&
                c.Week == serial_parts.Week_Year.Week &&
                c.Year == serial_parts.Week_Year.Year &&
                c.Number == serial_parts.Number
                );

                if(btracker.Any())
                {
                    int test = 1;
                }
            }
        }
        catch(Exception ex)
        {
            Label_Msg.Text = ex.Message;
            Label_Msg.Visible = true;

        }
        finally
        {
            /*
            GridView1.ShowHeader = false;
            GridView1.DataSource = t;
            GridView1.DataBind();
            GridView1.Visible = true;
            */
            GridView grid_parse_data = new GridView();
            grid_parse_data.ShowHeader = false;
            grid_parse_data.DataSource = t;
            grid_parse_data.DataBind();
            UpdatePanel1.ContentTemplateContainer.Controls.Add(grid_parse_data);

            Textbox_serial.Focus();
            UpdatePanel1.Update();
        }
    }
}
