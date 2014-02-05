using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hemliga_talet.Model;

namespace Hemliga_talet
{
    public partial class Default : System.Web.UI.Page
    {
        protected SecretNumber SecretNumber
        {
            get
            {
                return Session["SecretNumber"] as SecretNumber;
            }
            set
            {
                Session["SecretNumber"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GuessTextBox.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (SecretNumber == null)
                {
                    SecretNumber = new SecretNumber();
                }

                var guess = int.Parse(GuessTextBox.Text);

                switch (SecretNumber.MakeGuess(guess))
                {
                    case Outcome.Indefinite:
                        break;
                    case Outcome.Low:
                        GuessLabel.Text = "För lågt";
                        break;
                    case Outcome.High:
                        GuessLabel.Text = "För högt";
                        break;
                    case Outcome.Correct:
                        GuessLabel.Text = String.Format("Grattis du klarade det på {0} försök", SecretNumber.Count);
                        Panel1.Enabled = false;
                        ResetButton.Visible = true;
                        break;
                    case Outcome.NoMoreGuesses:
                        GuessLabel.Text = String.Format("Du har slut på gissningar och det hemliga talet var {0}", SecretNumber.Number);
                        Panel1.Enabled = false;
                        ResetButton.Visible = true;
                        break;
                    case Outcome.PreviousGuess:
                        GuessLabel.Text = String.Format("Du har redan gissat på {0}", guess);
                        break;
                    default:
                        break;
                }
                PreviousLabel.Text = String.Join(" ", SecretNumber.PreviousGuesses);
                PlaceHolder1.Visible = true;
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
            GuessTextBox.Focus();
        }
    }
}