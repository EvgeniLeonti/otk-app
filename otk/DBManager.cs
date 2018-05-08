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
        IMobileServiceTable<String> table;

        private DBManager()
        {
            this.client = new MobileServiceClient(Constants.ApplicationURL);
            this.table = client.GetTable<String>();
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

        public async Task<ObservableCollection<String>> GetData(bool syncItems = false)
        {
            try
            {
                IEnumerable<String> items = await table
                    .ToEnumerableAsync();

                return new ObservableCollection<String>(items);
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

        public async Task SaveData(String item)
        {
            await table.InsertAsync(item);
        }
    }
}
