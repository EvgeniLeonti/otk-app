using System;
using System.Linq;
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

            var grid = new Grid
            {
                BackgroundColor = BackgroundColor,
                ColumnSpacing = 1,
                RowSpacing = 1
            };
            for (var i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(50)});
            }

            for (var i = 0; i < 3; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(50)});
            }

            //< BoxView x: Name = "cell1" Color = "#000000" Grid.Row = "0" Grid.Column = "0" />

            Point[] blackCells =
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(0, 2),
                new Point(1, 1),
                new Point(2, 1)
            };

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var color = Color.White;
                    if (blackCells.Contains(new Point(i, j)))
                    {
                        color = Color.Black;
                    }
                    BoxView boxView = new BoxView {Color = color};
                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                    boxView.GestureRecognizers.Add(tapGestureRecognizer);
                    tapGestureRecognizer.Tapped += (s, e) => {
                        Challenge2Input.Text = "Cell" + i + j + " clicked";
                    };
                    grid.Children.Add(boxView, j, i);
                }
            }
                



            var frame = new Frame
            {
                Content = grid
            };

            Challenge2InputMatrix.Children.Add(frame);


            //
            //            var tapGestureRecognizer = new TapGestureRecognizer();
            //            cell1.GestureRecognizers.Add(tapGestureRecognizer);
            //            tapGestureRecognizer.Tapped += (s, e) => {
            //                Challenge2Input.Text = "Cell clicked";
            //            };
            //
            //            BoxView boxView = new BoxView
            //            {
            //                Color = Color.Black
            //            };
            //            
            //            Matrix.Children.Add(new BoxView ());

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


