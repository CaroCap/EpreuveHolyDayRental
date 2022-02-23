using HolidayRental.BLL.Entities;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace HoliDayRental.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }
        public bool IsConnected { get { return _session.GetString(nameof(User)) != null; } }

        public MembreBLL User
        {
            set
            {
                _session.SetString(nameof(User), JsonSerializer.Serialize(value));
            }
            get
            {
                return JsonSerializer.Deserialize<MembreBLL>(_session.Get(nameof(User)));
            }
        }

    }
}
