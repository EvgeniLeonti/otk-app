using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace otk
{
    public class Challenge
    {
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected dynamic Data { get; set; }
    }

    public class SecretCode : Challenge
    {
        public SecretCode (String data)
        {
            base.Id = 1;
            base.Name = "Secret Code";
            base.Data = data;
        }
        public void Draw()
        {
            // draw 5 random strings
        }

        public String ToJsonString()
        {
            return "{name: \"" + Name + "\", data: \"" + Data + "\"}";
        }
    }

    public class SecretTable : Challenge
    {
        public SecretTable(Array data)
        {
            base.Id = 2;
            base.Name = "Secret Table";
            base.Data = data;
        }
        public void Draw()
        {
            // draw 5 random strings
        }

        public string ToJsonString()
        {
            return "{name: \"" + Name + "\", data: \"" + Data + "\"}";
        }
    }



    public partial class SetChallenge : ContentPage
    {
        private DBManager manager;

        public SetChallenge()
        {
            InitializeComponent();
            manager = DBManager.DefaultManager;
        }


        async void Challenge1Clicked(object sender, EventArgs e)
        {
            var secretCode = new SecretCode(Challenge1Input.Text);
            var userItem = new UserItem() { UserName = "Jenya", ChallengeData = secretCode.ToJsonString() };
            await manager.SaveData(userItem);
            Challenge1Input.Text = string.Empty;
        }

        async void Challenge2Clicked(object sender, EventArgs e)
        {
            var secretCode = new SecretCode(Challenge2Input.Text);
            var userItem = new UserItem() { UserName = "Jenya", ChallengeData = secretCode.ToJsonString() };
            await manager.SaveData(userItem);
            Challenge2Input.Text = string.Empty;
        }

    }
}


