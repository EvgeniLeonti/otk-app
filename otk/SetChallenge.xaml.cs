using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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

            var grid = new Grid
            {
                BackgroundColor = Color.Black,
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

            Point[] blackCells =
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(0, 2),
                new Point(1, 1),
                new Point(2, 1)
            };
            BoxView[] arrayOfBoxes = new BoxView[9];
            int[] arrayOfBits = new int[9];
            TapGestureRecognizer[] tapRecognizers = new TapGestureRecognizer[9];
            var counter = 0;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var counter1 = counter;
                    var color = Color.White;
                    if (blackCells.Contains(new Point(i, j)))
                    {
                        color = Color.Black;
                        arrayOfBits[counter1] = 1;
                    }
                    arrayOfBoxes[counter] = new BoxView { Color = color };
                    tapRecognizers[counter] = new TapGestureRecognizer();
                    arrayOfBoxes[counter].GestureRecognizers.Add(tapRecognizers[counter]);
                    
                    tapRecognizers[counter].Tapped += (s, e) =>
                    {
                        arrayOfBoxes[counter1].Color = arrayOfBoxes[counter1].Color == Color.Black ? Color.White : Color.Black;
                        arrayOfBits[counter1] = 1 - arrayOfBits[counter1];
                        var result = string.Join("", arrayOfBits.Select(x => x.ToString()).ToArray());
                        Challenge2Input.Text = result;
                    };
                    grid.Children.Add(arrayOfBoxes[counter], j, i);
                    counter++;
                }
            }
            var defaultGrid = string.Join("", arrayOfBits.Select(x => x.ToString()).ToArray());
            Challenge2Input.Text = defaultGrid;
            var frame = new Frame
            {
                Content = grid,
                OutlineColor = Color.Black,
                Padding = new Thickness(0, 0, 0, 0),
                CornerRadius = 1
            };

            Challenge2InputMatrix.Children.Add(frame);
        }


        async void Challenge1Clicked(object sender, EventArgs e)
        {
            var userItem = new UserItem() { UserId = 1, Challenge1 = Challenge1Input.Text };
            await manager.SaveData(userItem);
            Challenge1Input.Text = string.Empty;
        }

        async void Challenge2Clicked(object sender, EventArgs e)
        {
            var userItem = new UserItem() { UserId = 1, Challenge2 = Challenge2Input.Text };
            await manager.SaveData(userItem);
            Challenge2Input.Text = string.Empty;
        }

    }
}


