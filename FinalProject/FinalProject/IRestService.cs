using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public interface IRestService
    {
        Task<List<APIImage>> getPhotoListForDay(String date);

        Task<APIImage> getPhotoByDateID(String date, String id);
    }
}
