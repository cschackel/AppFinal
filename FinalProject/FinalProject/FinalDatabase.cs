using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FinalProject
{
    public class FinalDatabase
    {

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public FinalDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(StargazingJournalEntry).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(StargazingJournalEntry)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<StargazingJournalEntry>> GetItemsAsync()
        {
            return Database.Table<StargazingJournalEntry>().ToListAsync();
        }
        /*
        public Task<List<Final>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<StargazingJournalEntry>("SELECT * FROM [StargazingJournalEntry] WHERE [Done] = 0");
        }
        */
        public Task<StargazingJournalEntry> GetItemAsync(int id)
        {
            return Database.Table<StargazingJournalEntry>().Where(i => i.JournalID == id).FirstOrDefaultAsync();
        }

        public void DeleteAllEntries()
        {
            Database.ExecuteAsync("DELETE FROM StargazingJournalEntry");
            //Database.ExecuteAsync("DROP TABLE [IF EXISTS] StargazingJournalEntry");
    }

        public Task<int> SaveItemAsync(StargazingJournalEntry item)
        {
            if (item.JournalID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(StargazingJournalEntry item)
        {
            return Database.DeleteAsync(item);
        }

    }
}
