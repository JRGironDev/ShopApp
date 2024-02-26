using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services;

    public interface INavegacionService
    {

    Task GoToAsync(string uri);
    Task GoToAsync(string uri, IDictionary<string, object> parameters);

    }

