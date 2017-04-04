using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initPositionRole();
        }
    }

    private void initPositionRole()
    {
        positionRole.Items.Clear();
        positionRole.Enabled = true;
        positionRole.Items.Add("Analyst");
        positionRole.Items.Add("Designer");
        positionRole.Items.Add("Developer");
    }

    protected void workerButton_CheckedChanged(object sender, EventArgs e)
    {
        initPositionRole();
    }

    protected void bossButton_CheckedChanged(object sender, EventArgs e)
    {
        positionRole.Items.Clear();
        positionRole.Enabled = true;
        positionRole.Items.Add("General Manager");
        positionRole.Items.Add("Project Manager");
    }

    protected void vpButton_CheckedChanged(object sender, EventArgs e)
    {
        positionRole.Items.Clear();
        positionRole.Enabled = true;
        positionRole.Items.Add("VP Sales");
        positionRole.Items.Add("VP Marketing");
        positionRole.Items.Add("VP Production");
        positionRole.Items.Add("VP Human Resources");
    }

    protected void presidentButton_CheckedChanged(object sender, EventArgs e)
    {
        positionRole.Items.Clear();
        positionRole.Enabled = false;
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        String position = "";

        if (workerButton.Checked)
            position = "Worker";
        if (bossButton.Checked)
            position = "Manager";
        if (vpButton.Checked)
            position = "Vice President";
        if (presidentButton.Checked)
            position = "President";

        infoLabel.Text = "Employee:&nbsp" + firstName.Text + "&nbsp" +
            lastName.Text + "&nbsp&nbsp&nbsp&nbspId:&nbsp" +
            employeeID.Text + "&nbsp&nbsp&nbsp&nbspPosition:&nbsp" +
            position;
    }

    protected void clearButton_Click(object sender, EventArgs e)
    {
        firstName.Text = "";
        lastName.Text = "";
        employeeID.Text = "";
        workerButton.Checked = true;
        bossButton.Checked = false;
        vpButton.Checked = false;
        presidentButton.Checked = false;
        initPositionRole();
        infoLabel.Text = "";
    }
}
