using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] namesArray = new string[0];
                int[] electionsArray = new int[0];
                int[] subterfugeArray = new int[0];

                ViewState.Add("Names", namesArray);
                ViewState.Add("Elections", electionsArray);
                ViewState.Add("Subterfuge", subterfugeArray);
            }
        }

        protected void assetButton_Click(object sender, EventArgs e)
        {
            string[] namesArray = (string[])ViewState["Names"];
            int[] electionsArray = (int[])ViewState["Elections"];
            int[] subterfugeArray = (int[])ViewState["Subterfuge"];

            int newLength = namesArray.Length + 1;

            Array.Resize(ref namesArray, newLength);
            Array.Resize(ref electionsArray, newLength);
            Array.Resize(ref subterfugeArray, newLength);

            int newIndex = namesArray.GetUpperBound(0);

            namesArray[newIndex] = nameTextBox.Text;
            electionsArray[newIndex] = int.Parse(electionsTextBox.Text);
            subterfugeArray[newIndex] = int.Parse(subterfugeTextBox.Text);

            ViewState["Names"] = namesArray;
            ViewState["Elections"] = electionsArray;
            ViewState["Subterfuge"] = subterfugeArray;

            resultLabel.Text =
                $"Total Elections Rigged: {electionsArray.Sum()}" +
                $"<br />Average Acts of Subterfuge per Asset: {subterfugeArray.Average():N2}" +
                $"<br />(Last Asset you Added: {namesArray[newIndex]})";

            nameTextBox.Text = "";
            electionsTextBox.Text = "";
            subterfugeTextBox.Text = "";
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}