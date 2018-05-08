using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace otk
{
    public partial class SetChallenge : ContentPage
    {
        private DBManager manager;

        public SetChallenge()
        {
            InitializeComponent();
            manager = DBManager.DefaultManager;
        }


        async void OnInsertClicked(object sender, EventArgs e)
        {
            var challengeName = challenge.Text;
            await manager.SaveData(challengeName);
            challenge.Text = string.Empty;
        }
    }
}


