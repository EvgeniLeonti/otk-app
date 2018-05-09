using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace otk
{
    public partial class DBManager
    {
        static DBManager defaultInstance = new DBManager();
        MobileServiceClient client;
        IMobileServiceTable<UserItem> table;

        private DBManager()
        {
            this.client = new MobileServiceClient(Constants.ApplicationURL);
            this.table = client.GetTable<UserItem>();
        }

        public static DBManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public async Task<ObservableCollection<UserItem>> GetData(bool syncItems = false)
        {
            try
            {
                IEnumerable<UserItem> items = await table
                    .ToEnumerableAsync();

                return new ObservableCollection<UserItem>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task SaveData(UserItem item)
        {
            await table.InsertAsync(item);
        }
    }
}
